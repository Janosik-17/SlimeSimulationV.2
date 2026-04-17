namespace SlimeSimulationV._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            simTimer = new System.Windows.Forms.Timer(components);
            btnStart = new Button();
            pictureBox1 = new PictureBox();
            btnClear = new Button();
            btnSeed = new Button();
            labMode = new Label();
            labSeed = new Label();
            radButtonSlime = new RadioButton();
            radButtonFood = new RadioButton();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // simTimer
            // 
            simTimer.Interval = 16;
            simTimer.Tick += simTimer_Tick;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(830, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 600);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(830, 52);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseCompatibleTextRendering = true;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSeed
            // 
            btnSeed.Location = new Point(830, 297);
            btnSeed.Name = "btnSeed";
            btnSeed.Size = new Size(112, 34);
            btnSeed.TabIndex = 3;
            btnSeed.Text = "Seed Slime";
            btnSeed.UseVisualStyleBackColor = true;
            btnSeed.Click += btnSeed_Click;
            // 
            // labMode
            // 
            labMode.AutoSize = true;
            labMode.Location = new Point(30, 35);
            labMode.Name = "labMode";
            labMode.Size = new Size(120, 25);
            labMode.TabIndex = 5;
            labMode.Text = "Placing Mode";
            // 
            // labSeed
            // 
            labSeed.AutoSize = true;
            labSeed.Location = new Point(830, 269);
            labSeed.Name = "labSeed";
            labSeed.Size = new Size(208, 25);
            labSeed.TabIndex = 6;
            labSeed.Text = "Place big slime in middle";
            // 
            // radButtonSlime
            // 
            radButtonSlime.AutoSize = true;
            radButtonSlime.Checked = true;
            radButtonSlime.Location = new Point(30, 63);
            radButtonSlime.Name = "radButtonSlime";
            radButtonSlime.Size = new Size(80, 29);
            radButtonSlime.TabIndex = 7;
            radButtonSlime.TabStop = true;
            radButtonSlime.Text = "Slime";
            radButtonSlime.UseVisualStyleBackColor = true;
            radButtonSlime.CheckedChanged += radButtonSlime_CheckedChanged;
            // 
            // radButtonFood
            // 
            radButtonFood.AutoSize = true;
            radButtonFood.Location = new Point(30, 98);
            radButtonFood.Name = "radButtonFood";
            radButtonFood.Size = new Size(138, 29);
            radButtonFood.TabIndex = 8;
            radButtonFood.Text = "Food Source";
            radButtonFood.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radButtonFood);
            groupBox1.Controls.Add(labMode);
            groupBox1.Controls.Add(radButtonSlime);
            groupBox1.Location = new Point(830, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 153);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 646);
            Controls.Add(groupBox1);
            Controls.Add(labSeed);
            Controls.Add(btnSeed);
            Controls.Add(btnClear);
            Controls.Add(pictureBox1);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer simTimer;
        private Button btnStart;
        private PictureBox pictureBox1;
        private Button btnClear;
        private Button btnSeed;
        private Label labMode;
        private Label labSeed;
        private RadioButton radButtonSlime;
        private RadioButton radButtonFood;
        private GroupBox groupBox1;
    }
}
