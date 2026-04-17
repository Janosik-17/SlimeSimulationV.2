using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlimeSimulationV._2
{
    /// <summary>
    /// Handles the rendering of the pheromone field and the food sources 
    /// into a Bitmap which is then displayed in a picture box
    /// </summary>
    internal class SimRenderer
    {
        private Bitmap bitmap;
        private PictureBox target;

        /// <summary>
        /// SimRenderer constructor, sets the target PictureBox and creates
        /// a new Bitmap
        /// </summary>
        /// <param name="pictureBox">The target picture box</param>
        /// <param name="width">Width of the simulation in pixels</param>
        /// <param name="height">Height of the simulation in pixels</param>
        public SimRenderer(PictureBox pictureBox, int width, int height)
        {
            target = pictureBox;
            bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// Renders the pheromone field directly to the Bitmap using LockBits, 
        /// converts the pheromone intesity into a cyan-green colour by scaling
        /// each RGB channel directly
        /// </summary>
        /// <param name="field">The Pheromone field from which to read the values</param>
        /// <param name="foodSources">Food source positions, rendered as yellow circles</param>
        /// <remarks>
        /// Uses an <c>unsafe</c> code block with a <c>byte*</c> pointer into
        /// the bitmaps pixel buffer. Uses a B, G, R, A colour layout. 
        /// </remarks>
        public void Render(PheromoneField field, List<PointF> foodSources)
        {
            // Fast pixel writing with LockBits
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, field.Width, field.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int stride = data.Stride;

                for (int y = 0; y < field.Height; y++)
                {
                    for (int x = 0; x < field.Width; x++)
                    {
                        int offset = y * stride + x * 4;
                        byte intensity = (byte)Math.Min(255, (int)field[x, y]);

                        ptr[offset + 0] = (byte)Math.Min(255, (int)intensity);              // Blue
                        ptr[offset + 1] = (byte)Math.Min(255, (int)(intensity * 1.15f));    // Green
                        ptr[offset + 2] = (byte)Math.Min(255, (int)(intensity * 0.6f));     // Red
                        ptr[offset + 3] = 255;                                              // Alpha
                    }
                }
            }

            bitmap.UnlockBits(data);

            // Draw food sources on top (yellow circles)
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var food in foodSources)
                {
                    g.FillEllipse(Brushes.Yellow, food.X - 6, food.Y - 6, 12, 12);
                }
            }

            // Show on screen
            target.Image = bitmap;
        }
    }    
}
