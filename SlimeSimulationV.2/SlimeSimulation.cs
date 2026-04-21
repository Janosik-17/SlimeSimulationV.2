using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// The primary pheromone field used by the simulation
        /// </summary>
        public PheromoneField Field { get; }

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
            Field = new PheromoneField(width, height);
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
            // Emit food trail
            foreach (var oat in FoodSources)
            {
                int fx = (int)oat.X;
                int fy = (int)oat.Y;
                //if (fx >= 0 && fx < Field.Width && fy >= 0 && fy < Field.Height)
                //{
                //    Field.Deposit(fx, fy, currentSettings.FoodEmissionStrength);
                //}
                for (int i = 0; i < 50; i++)
                {
                    float angle = (float)(RNG.NextDouble() * Math.PI * 2);
                    float dist = (float)(RNG.NextDouble() * 10);

                    float posX = fx + (float)Math.Cos(angle) * dist;
                    float posY = fy + (float)Math.Sin(angle) * dist;

                    // Agents.Add(new SlimeAgent(posX, posY, angle));

                    if (posX >= 0 && posX < 800 && posY >= 0 && posY < 600)
                    {
                        Field.Deposit(posX, posY, currentSettings.FoodEmissionStrength);
                    }
                }
            }

            // Update and move slimes
            foreach (var slime in Agents)
            {
                var angleCenter = slime.heading;
                var angleRight = slime.heading - currentSettings.SmellAngle / 2;
                var angleLeft = slime.heading + currentSettings.SmellAngle / 2;

                var smellCenter = Field.Smell(
                    slime.X + (float)Math.Cos(angleCenter) * currentSettings.SmellDistance,
                    slime.Y + (float)Math.Sin(angleCenter) * currentSettings.SmellDistance
                    );

                var smellRight = Field.Smell(
                    slime.X + (float)Math.Cos(angleRight) * currentSettings.SmellDistance,
                    slime.Y + (float)Math.Sin(angleRight) * currentSettings.SmellDistance
                    );

                var smellLeft = Field.Smell(
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

                // Wrapping
                if (newX < 0) { newX = Field.Width - 1; }
                else if (newX >= Field.Width) { newX = 0; }
                else if (newY < 0) { newY = Field.Height - 1; }
                else if (newY >= Field.Height) { newY = 0; }

                // Sets the definitive new position
                slime.X = newX;
                slime.Y = newY;

                // Deposit pheromones
                int ix = (int)slime.X;
                int iy = (int)slime.Y;
                if (ix >= 0 && ix < Field.Width && iy >= 0 && iy < Field.Height)
                {
                    Field.Deposit(ix, iy, currentSettings.DepositPheromoneAmount);
                }           
            }

            // Diffuse and decay trail
            Field.DiffuseAndDecay(currentSettings.DecayRate);

            // Redraw(); ADD INTO TICK TIMER LOOP
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

            for (int i = 0; i < ammount; i++)
            {
                float angle = (float)(RNG.NextDouble() * Math.PI * 2);
                float dist = (float)(RNG.NextDouble() * radius);

                float posX = x + (float)Math.Cos(angle) * dist;
                float posY = y + (float)Math.Sin(angle) * dist;

                Agents.Add(new SlimeAgent(posX, posY, angle));

                if (posX >= 0 && posX < 800 && posY >= 0 && posY < 600)
                {
                    Field.Deposit(posX, posY, 25);
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
            Field.ClearPheromones();
            Agents.Clear();
            FoodSources.Clear();
        }

    }
}
