using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSimulationV._2
{
    internal class FoodSource
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public int nutrition { get; set; }

        public FoodSource(float x, float y, int _nutrition)
        {
            X = x;
            Y = y;
            nutrition = _nutrition;
        }
    }
}
