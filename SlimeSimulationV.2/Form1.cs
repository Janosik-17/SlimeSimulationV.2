using System.Diagnostics;
using System.Drawing.Imaging;

namespace SlimeSimulationV._2
{
    public partial class Form1 : Form
    {
        // Resolution of the simulation
        private const int WIDTH = 800;
        private const int HEIGHT = 600;

        // Mode switching var, and 
        private bool slimeMode = true;

        // initialization of the sim and renderer
        private SlimeSimulation sim = new SlimeSimulation(WIDTH, HEIGHT);
        private SimRenderer renderer;

        // List of buttons to disable when the simulation is running
        private Control[] _stopOnlyControls { get; set; }

        public Form1()
        {
            InitializeComponent();

            // Creates the list once the controlls are initialized
            _stopOnlyControls = new Control[]
            {
                btnClear,
                btnSaveSettings,
                btnLoadSettings,
                radButtonFood,
                radButtonSlime,
                upDownDecayRate,
                upDownDepositAmount,
                upDownEmisionRate,
                upDownPathRandom,
                upDownSlimeSpeed,
                upDownSmellAngle,
                upDownSmellDistance,
                upDownTurningSpeed
            };

            // Sets the renderer to output to pictureBox1
            renderer = new SimRenderer(pictureBox1, WIDTH, HEIGHT);

            // Initial render - to display a black screen
            renderer.Render(sim.FoodTrail,sim.HomeTrail, sim.FoodSources);
            
            // Initializes the presets folder
            SettingsManager.InitializePresetsFolder();


            // Set the values in Form1 to the default settings
            upDownSmellDistance.Value = (decimal)sim.currentSettings.SmellDistance;
            upDownSmellAngle.Value = (decimal)sim.currentSettings.SmellAngle;
            upDownSlimeSpeed.Value = (decimal)sim.currentSettings.SlimeSpeed;
            upDownTurningSpeed.Value = (decimal)sim.currentSettings.TurningSpeed;
            upDownPathRandom.Value = (decimal)sim.currentSettings.WigglyPathCoeff;
            upDownDepositAmount.Value = (decimal)sim.currentSettings.DepositPheromoneAmount;
            upDownEmisionRate.Value = (decimal)sim.currentSettings.FoodEmissionStrength;
            upDownDecayRate.Value = (decimal)sim.currentSettings.DecayRate;
        }

        // WIRING OF THE BUTTONS IN THE WIN FORM

        // Places either a slime blob or a food source based on mode
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (simTimer.Enabled) return;

            float mx = (float)e.X;
            float my = (float)e.Y;

            if (slimeMode)
            {
                sim.AddSlimeBlob(mx, my, 20, 20);
            }
            else
            {
                sim.AddFood(mx, my);
            }

            renderer.Render(sim.FoodTrail,sim.HomeTrail, sim.FoodSources);
        }

        // Starts and stops the simulation + hides the buttons which are not accessible
        // when the simulation is running
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!simTimer.Enabled)
            {
                simTimer.Start();

                btnStart.Text = "Stop";

                // Save the settings to currentSettings
                sim.currentSettings.SmellDistance = (float)upDownSmellDistance.Value;
                sim.currentSettings.SmellAngle = (float)upDownSmellAngle.Value;
                sim.currentSettings.SlimeSpeed = (float)upDownSlimeSpeed.Value;
                sim.currentSettings.TurningSpeed = (float)upDownTurningSpeed.Value;
                sim.currentSettings.WigglyPathCoeff = (float)upDownPathRandom.Value;
                sim.currentSettings.DepositPheromoneAmount = (float)upDownDepositAmount.Value;
                sim.currentSettings.FoodEmissionStrength = (float)upDownEmisionRate.Value;
                sim.currentSettings.DecayRate = (float)upDownDecayRate.Value;

                foreach (var control in _stopOnlyControls)
                {
                    control.Enabled = false;
                }
            }
            else if (simTimer.Enabled)
            {
                simTimer.Stop();

                btnStart.Text = "Start";

                foreach (var control in _stopOnlyControls)
                {
                    control.Enabled = true;
                }
            }
        }

        // Main timer method performs one Step function and renders the image
        // currently runs on aprox. 60 fps
        private void simTimer_Tick(object sender, EventArgs e)
        {
            sim.Step();
            renderer.Render(sim.FoodTrail,sim.HomeTrail, sim.FoodSources);
        }

        // Clears everything in the picture box
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!simTimer.Enabled)
            {
                sim.ClearAll();
                renderer.Render(sim.FoodTrail,sim.HomeTrail, sim.FoodSources);
            }
        }

        // Places a large blob of slime agents in the middle of the Picture Box
        private void btnSeed_Click(object sender, EventArgs e)
        {
            sim.AddSlimeBlob(400, 300, 90, 100);
            renderer.Render(sim.FoodTrail, sim.HomeTrail, sim.FoodSources);
        }

        // Switches the food/slime mode
        private void radButtonSlime_CheckedChanged(object sender, EventArgs e)
        {
            if (slimeMode)
            {
                slimeMode = false;
            }

            else
            {
                slimeMode = true;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                SettingsManager.Save(sim.currentSettings, dialog.FileName);
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sim.currentSettings = SettingsManager.Load(dialog.FileName);

                // Update form values
                upDownSmellDistance.Value = (decimal)sim.currentSettings.SmellDistance;
                upDownSmellAngle.Value = (decimal)sim.currentSettings.SmellAngle;
                upDownSlimeSpeed.Value = (decimal)sim.currentSettings.SlimeSpeed;
                upDownTurningSpeed.Value = (decimal)sim.currentSettings.TurningSpeed;
                upDownPathRandom.Value = (decimal)sim.currentSettings.WigglyPathCoeff;
                upDownDepositAmount.Value = (decimal)sim.currentSettings.DepositPheromoneAmount;
                upDownEmisionRate.Value = (decimal)sim.currentSettings.FoodEmissionStrength;
                upDownDecayRate.Value = (decimal)sim.currentSettings.DecayRate;
            }
        }
    }
}
