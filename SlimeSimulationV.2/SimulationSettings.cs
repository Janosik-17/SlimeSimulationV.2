using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeSimulationV._2
{
    /// <summary>
    /// Stores the simulation settings of the simulation
    /// </summary>
    internal class SimulationSettings
    {
        public float DecayRate { get; set; } = 0.9f;
        public float SmellDistance { get; set; } = 20f;
        public float SmellAngle { get; set; } = 2f;
        public float SlimeSpeed { get; set; } = 1.0f;
        public float TurningSpeed { get; set; } = 0.4f;
        public float WigglyPathCoeff { get; set; } = 0.05f;
        public float DepositPheromoneAmount { get; set; } = 4f;
        public float FoodEmissionStrength { get; set; } = 200f;
    }
}
