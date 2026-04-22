using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSimulationV._2
{
    /// <summary>
    /// Stores the position and heading of a singular slime agent
    /// </summary>
    internal class SlimeAgent
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float heading { get; set; } // radians

        /// <summary>
        /// Stores wheather the agent has found food or is searching for it
        /// </summary>
        public bool IsSearching { get; set; } = true;

        // Maybe will add that ants after a set ammount of time
        // will convert to other type to prevent death loops
        public int TimeSearchingHome { get; set; } = 0;

        /// <summary>
        /// Slime agent constructor
        /// </summary>
        /// <param name="x">The x coordinate of the agent</param>
        /// <param name="y">The y coordinate of the agent</param>
        /// <param name="angle">The angle in RADIANS of the heading of the agent</param>
        public SlimeAgent(float x, float y, float angle)
        {
            X = x;
            Y = y;
            heading = angle;
            IsSearching = true;
        }
    }
}
