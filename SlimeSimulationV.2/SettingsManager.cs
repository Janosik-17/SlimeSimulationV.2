using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SlimeSimulationV._2
{
    /// <summary>
    /// Manages the the serialization and deserialization of the settings class
    /// </summary>
    internal class SettingsManager
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true  // makes the JSON human-readable
        };

        /// <summary>
        /// Serializes the settings into a JSON file
        /// </summary>
        /// <param name="settings">The target settings.</param>
        /// <param name="path">Path to the to JSON file.</param>
        public static void Save(SimulationSettings settings, string path)
        {
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Deserializes a JSON file into a new settings object
        /// </summary>
        /// <param name="path">Path to the target JSON file.</param>
        /// <returns>A new <c>SimulationSettings</c> object.</returns>
        public static SimulationSettings Load(string path)
        {
            if (!File.Exists(path))            
                return new SimulationSettings();
            
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<SimulationSettings>(json)
                ?? new SimulationSettings();
        }
    }
}
