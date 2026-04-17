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

        public Form1()
        {
            InitializeComponent();

            // Sets the renderer to output to pictureBox1
            renderer = new SimRenderer(pictureBox1, WIDTH, HEIGHT);

            // Initial render - to display a black screen
            renderer.Render(sim.Field, sim.FoodSources);
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

            renderer.Render(sim.Field, sim.FoodSources);
        }

        // Starts and stops the simulation + hides the buttons which are not accessible
        // when the simulation is running
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!simTimer.Enabled)
            {
                simTimer.Start();
                // isRunning = true;
                btnStart.Text = "Stop";
                btnClear.Visible = false;
                groupBox1.Visible = false;
            }
            else if (simTimer.Enabled)
            {
                simTimer.Stop();
                // isRunning = false;
                btnStart.Text = "Start";
                btnClear.Visible = true;
                groupBox1.Visible = true;
            }
        }

        // Main timer method performs one Step function and renders the image
        // currently runs on aprox. 60 fps
        private void simTimer_Tick(object sender, EventArgs e)
        {
            sim.Step();
            renderer.Render(sim.Field, sim.FoodSources);
        }

        // Clears everything in the picture box
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!simTimer.Enabled)
            {
                sim.ClearAll();
                renderer.Render(sim.Field, sim.FoodSources);
            }
        }

        // Places a large blob of slime agents in the middle of the Picture Box
        private void btnSeed_Click(object sender, EventArgs e)
        {
            sim.AddSlimeBlob(400, 300, 90, 400);
            renderer.Render(sim.Field, sim.FoodSources);
        }

        // Switches the food/slime mode
        private void radButtonSlime_CheckedChanged(object sender, EventArgs e)
        {
            if (slimeMode)
            {
                slimeMode = false;
                // Debug.WriteLine("Food Mode");
            }
            else
            {
                slimeMode = true;
                // Debug.WriteLine("Slime Mode");
            }
        }
    }
}
