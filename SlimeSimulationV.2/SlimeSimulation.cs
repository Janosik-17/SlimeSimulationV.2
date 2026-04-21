using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SlimeSimulationV._2
{
    /// <summary>
    /// Handles the logic behind the simulation, adding/removing food sources 
    /// and new slime agents
    /// </summary>
    internal class SlimeSimulation
    {
        // One public RNG class to use in the whole program
        public Random RNG { get; } = new Random();

        /// <summary>
        /// Pheromone trail laid by ants returning home - guides other towards food
        /// </summary>
        public PheromoneField FoodTrail { get; }

        /// <summary>
        /// Pheromone trail laid by ants searching for food - guides others towards home
        /// </summary>
        public PheromoneField HomeTrail { get; }

        /// <summary>
        /// List of all the food sources stored as PointF`s
        /// </summary>
        public List<PointF> FoodSources { get; set; }

        /// <summary>
        /// List of all the slime agents
        /// </summary>
        public List<SlimeAgent> Agents { get; set; }

        // Initializes the settings class for the simulation
        public SimulationSettings currentSettings { get; set; }

        /// <summary>
        /// Slime Simulation constructor
        /// </summary>
        /// <param name="width">Width of the simulation in pixels</param>
        /// <param name="height">Height of the simulation in pixels</param>
        public SlimeSimulation(int width, int height)
        {
            FoodTrail = new PheromoneField(width, height);
            HomeTrail = new PheromoneField(width, height);
            FoodSources = new List<PointF>();
            Agents = new List<SlimeAgent>();
            currentSettings = new SimulationSettings();
        }

        /// <summary>
        /// Primary method of Slime Simulation 
        /// emits trail from food, moves agents, deposits pheromones, diffuses the trail
        /// in that order
        /// </summary>
        /// <remarks>DOES NOT REDRAW THE BITMAP IMAGE ANYMORE</remarks>
        public void Step()
        {
            // Emit trail - hive emits the home trail, other food emits the food trial
            if (FoodSources.Count > 0)
            {
                var hive = FoodSources[0];

                // Deposits a random blob around food source
                for (int i = 0; i < 40; i++)
                {
                    float angle = (float)(RNG.NextDouble() * Math.PI * 2);
                    float dist = (float)(RNG.NextDouble() * 8);

                    float posX = hive.X + (float)Math.Cos(angle) * dist;
                    float posY = hive.Y + (float)Math.Sin(angle) * dist;

                    if (posX >= 0 && posX < 800 && posY >= 0 && posY < 600)
                    {
                        HomeTrail.Deposit(posX, posY, currentSettings.FoodEmissionStrength);
                    }
                }
            }
            // Deposits the food trial for all other food sources
            foreach (var oat in FoodSources.Skip(1))
            {
                for (int i = 0; i < 40; i++)
                {
                    float angle = (float)(RNG.NextDouble() * Math.PI * 2);
                    float dist = (float)(RNG.NextDouble() * 8);

                    float posX = oat.X + (float)Math.Cos(angle) * dist;
                    float posY = oat.Y + (float)Math.Sin(angle) * dist;

                    if (posX >= 0 && posX < 800 && posY >= 0 && posY < 600)
                    {
                        FoodTrail.Deposit(posX, posY, currentSettings.FoodEmissionStrength);
                    }
                }
            }            

            // Update and move slimes
            foreach (var slime in Agents)
            {
                // Sets which trail the agent should follow
                PheromoneField trailToFollow;

                if (slime.IsSearching)
                {
                    trailToFollow = FoodTrail;
                }
                else
                {
                    trailToFollow = HomeTrail;
                }

                var angleCenter = slime.heading;
                var angleRight = slime.heading - currentSettings.SmellAngle / 2;
                var angleLeft = slime.heading + currentSettings.SmellAngle / 2;

                var smellCenter = trailToFollow.Smell(
                    slime.X + (float)Math.Cos(angleCenter) * currentSettings.SmellDistance,
                    slime.Y + (float)Math.Sin(angleCenter) * currentSettings.SmellDistance
                    );

                var smellRight = trailToFollow.Smell(
                    slime.X + (float)Math.Cos(angleRight) * currentSettings.SmellDistance,
                    slime.Y + (float)Math.Sin(angleRight) * currentSettings.SmellDistance
                    );

                var smellLeft = trailToFollow.Smell(
                    slime.X + (float)Math.Cos(angleLeft) * currentSettings.SmellDistance,
                    slime.Y + (float)Math.Sin(angleLeft) * currentSettings.SmellDistance
                    );

                if (smellLeft > smellRight && smellLeft > smellCenter)
                {
                    slime.heading += currentSettings.TurningSpeed;
                }
                else if (smellRight > smellLeft && smellRight > smellCenter)
                {
                    slime.heading -= currentSettings.TurningSpeed;
                }

                // Random wiggle
                slime.heading += (float)((RNG.NextDouble() - 0.5) * currentSettings.WigglyPathCoeff);

                float newX = slime.X + (float)Math.Cos(slime.heading) * currentSettings.SlimeSpeed;
                float newY = slime.Y + (float)Math.Sin(slime.heading) * currentSettings.SlimeSpeed;

                // Wrapping - food trail and home trail has the same width and height
                if (newX < 0) { newX = FoodTrail.Width - 1; }
                else if (newX >= FoodTrail.Width) { newX = 0; }
                if (newY < 0) { newY = FoodTrail.Height - 1; }
                else if (newY >= FoodTrail.Height) { newY = 0; }

                // Sets the definitive new position
                slime.X = newX;
                slime.Y = newY;

                // Chose which trail to deposit
                PheromoneField trailToDeposit;

                if (slime.IsSearching)
                {
                    trailToDeposit = HomeTrail;
                }          
                else       
                {          
                    trailToDeposit = FoodTrail;
                }

                trailToDeposit.Deposit(slime.X, slime.Y, currentSettings.DepositPheromoneAmount);

                // Deposit pheromones - deprecated
                //int ix = (int)slime.X;
                //int iy = (int)slime.Y;
                //if (ix >= 0 && ix < FoodTrail.Width && iy >= 0 && iy < FoodTrail.Height)
                //{
                //    FoodTrail.Deposit(ix, iy, currentSettings.DepositPheromoneAmount);
                //}
                
                // Check if slime has reached a food source
                if (slime.IsSearching)
                {
                    // Skips the home food source
                    foreach (var food in FoodSources.Skip(1))
                    {
                        // Checks the distance between the slime and the food source
                        if (Math.Abs(slime.X - food.X) < 8f && (Math.Abs(slime.Y - food.Y)) < 8f)
                        {
                            // Flips the searching swith and turns the slime around 
                            slime.IsSearching = false;
                            slime.heading += (float)Math.PI;
                            break;
                        }
                    }
                }
                // Check if slime has reached home - if home doesnt exist it keeps running around
                else if (FoodSources.Count > 0)
                {
                    var hive = FoodSources[0];
                    if (Math.Abs(slime.X - hive.X) < 8f && (Math.Abs(slime.Y - hive.Y)) < 8f)
                    {
                        // Flips the searching swith and turns the slime around 
                        slime.IsSearching = true;
                        slime.heading += (float)Math.PI;
                        break;
                    }
                }
            }
            // Diffuse and decay trail
            FoodTrail.DiffuseAndDecay(currentSettings.DecayRate);
            HomeTrail.DiffuseAndDecay(currentSettings.DecayRate);            
        }

        /// <summary>
        /// Deposits the "ammount" number of slimes in a circle around a point
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="radius">Radius of the slime blob</param>
        /// <param name="ammount">The total ammount of new agents to be added</param>
        public void AddSlimeBlob(float x, float y, int radius, int ammount)
        {
            // Deposits the 'ammount' number of slimes
            for (int i = 0; i < ammount; i++)
            {
                float angle = (float)(RNG.NextDouble() * Math.PI * 2);
                float dist = (float)(RNG.NextDouble() * radius);

                float posX = x + (float)Math.Cos(angle) * dist;
                float posY = y + (float)Math.Sin(angle) * dist;

                Agents.Add(new SlimeAgent(posX, posY, angle));

                if (posX >= 0 && posX < 800 && posY >= 0 && posY < 600)
                {
                    FoodTrail.Deposit(posX, posY, 25);
                }
            }
        }

        /// <summary>
        /// Adds a new food source
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public void AddFood(float x, float y)
        {
            FoodSources.Add(new PointF(x, y));
        }

        /// <summary>
        /// Clears the entire simulation, e.g. the pheromone fields,
        /// the slime agents and the food sources
        /// </summary>
        public void ClearAll()
        {
            FoodTrail.ClearPheromones();
            HomeTrail.ClearPheromones();
            Agents.Clear();
            FoodSources.Clear();
        }
    }
}
