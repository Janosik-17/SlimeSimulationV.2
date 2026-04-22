using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSimulationV._2
{
    /// <summary>
    /// Stores 2D pheromone grid useb by the simulation. 
    /// Handles diffusion, decay and 'smelling' 
    /// </summary>
    internal class PheromoneField
    {
        // The field which stores the current pheromone values
        private float[,] current;

        // Field used for the DiffuseAndDecay function 
        private float[,] next;

        /// <summary>
        /// Width of the Pheromone field
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of the Pheromone field
        /// </summary>
        public int Height { get; }

        // Indexer for the Pheromone field returns 
        // the value of the pheromone at [x, y] of the current field
        public float this[int x, int y] => current[x, y];

        /// <summary>
        /// Constructor of the Pheromone field
        /// </summary>
        /// <param name="Width">Width of the pheromone field in pixels</param>
        /// <param name="Height">Height of the pheromone field in pixels</param>
        public PheromoneField(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;

            this.current = new float[Width, Height];
            this.next = new float[Width, Height];
        }

        /// <summary>
        /// "Smells" the pheromone trail at a given coordinate
        /// </summary>
        /// <param name="x">X coordinate in the pheromone field</param>
        /// <param name="y">Y coordinate in the pheromone field</param>
        /// <returns>Value of the pheromone at [x,y] of field</returns>
        public float Smell(float x, float y)
        {
            int ix = (int)x;
            int iy = (int)y;
            if (ix < 0 || ix >= Width || iy < 0 || iy >= Height) return 0f;
            return current[ix, iy];
        }

        /// <summary>
        /// Increases the value of the pheromone trail ("Deposits") at a given location
        /// by a given ammount
        /// </summary>
        /// <param name="x">X coordinate in the pheromone field</param>
        /// <param name="y">Y coordinate in the pheromone field</param>
        /// <param name="ammount">The ammount by which the value of the pheromone is increased</param>
        public void Deposit(float x, float y, float ammount)
        {
            int cx = (int)x;
            int cy = (int)y;

            // Holds the maximum value lover than 255
            current[cx, cy] = Math.Min(255, current[cx, cy] + ammount);
        }

        /// <summary>
        /// Applies a simple 3x3 box blur to all pixels in pheromone field and dereases their value
        /// Uses a Parallel.For loop to speed up the process for larger simulations
        /// </summary>
        /// <param name="decayRate">Decay rate of the pheromone from (0, 1)</param>
        public void DiffuseAndDecay(float decayRate)
        {
            // 1. Compute blurred + decayed values into the NEXT buffer
            Parallel.For(1, Width - 1, x =>
            {
                for (int y = 1; y < Height - 1; y++)
                {
                    float sum = current[x, y] * 0.6f;
                    sum += current[x - 1, y] * 0.1f;
                    sum += current[x + 1, y] * 0.1f;
                    sum += current[x, y - 1] * 0.1f;
                    sum += current[x, y + 1] * 0.1f;
                    sum += current[x - 1, y - 1] * 0.025f;
                    sum += current[x + 1, y - 1] * 0.025f;
                    sum += current[x - 1, y + 1] * 0.025f;
                    sum += current[x + 1, y + 1] * 0.025f;

                    next[x, y] = Math.Min(255, sum * decayRate);
                }
            });




            // 2. Copy the NEW values back to the main field - old
            //Parallel.For(1, Width, x =>
            //{
            //    for (int y = 0; y < Height; y++)
            //    {
            //        current[x, y] = next[x, y];
            //    }
            //});

            // New method, works because next is overwritten each step
            (current, next) = (next, current);
        }

        /// <summary>
        /// Sets the values of both the pheromone fields to 0
        /// </summary>
        public void ClearPheromones()
        {
            Array.Clear(current, 0, current.Length);
            Array.Clear(next, 0, next.Length);
        }
    }
}
