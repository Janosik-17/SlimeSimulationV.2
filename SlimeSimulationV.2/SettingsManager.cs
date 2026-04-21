using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Path to the presets folder
        private static readonly string PresetsFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "presets");

        /// <summary>
        /// Creates a presents folder if it already doesnt exist
        /// </summary>
        public static void InitializePresetsFolder()
        {
            if (!Directory.Exists(PresetsFolder))
                Directory.CreateDirectory(PresetsFolder);
            Debug.WriteLine(PresetsFolder);

            // SPYTAT SA NA HODINE !!!!!!!!!!

            // Write the default preset if it doesn't already exist
            // so the user can modify it without losing the original
            //string defaultPath = Path.Combine(PresetsFolder, "defaultDualTrail.json");
            //if (!File.Exists(defaultPath))
            //{
            //    // Read the embedded resource from the assembly
            //    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //    string resourceName = "SlimeSimulationV._2.Resources.defaultDualTrail.json";

            //    using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
            //    using StreamReader reader = new StreamReader(stream);
            //    string json = reader.ReadToEnd();
            //    File.WriteAllText(defaultPath, json);
            //}
        }

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

        /// <summary>
        /// Saves some settings to presets folder without opening the file dialog window
        /// </summary>
        /// <param name="name">Name of the preset</param>
        /// <param name="settings">The Simulation Settings to save</param>
        public static void SaveWithoutDialog(string name, SimulationSettings settings)
        {
            string path = Path.Combine(PresetsFolder, $"{name}.json");
            Save(settings, path);
        }

        /// <summary>
        /// Loads a settings json from the presets folder
        /// </summary>
        /// <param name="name">Name of the preset to load</param>
        /// <returns>Simulation settings from the file</returns>
        public static SimulationSettings LoadWithoutDialog(string name)
        {
            string path = Path.Combine(PresetsFolder, $"{name}.json");
            return Load(path);
        }
    }
}
