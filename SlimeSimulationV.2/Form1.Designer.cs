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
            labelSmellDistance = new Label();
            label = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            upDownSmellDistance = new NumericUpDown();
            upDownSmellAngle = new NumericUpDown();
            upDownSlimeSpeed = new NumericUpDown();
            upDownTurningSpeed = new NumericUpDown();
            upDownPathRandom = new NumericUpDown();
            upDownDepositAmount = new NumericUpDown();
            upDownEmisionRate = new NumericUpDown();
            upDownDecayRate = new NumericUpDown();
            btnSaveSettings = new Button();
            btnLoadSettings = new Button();
            upDownFoodNutrition = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            checkBoxFoodForever = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upDownSmellDistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownSmellAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownSlimeSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownTurningSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownPathRandom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownDepositAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownEmisionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownDecayRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownFoodNutrition).BeginInit();
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
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            btnSeed.Location = new Point(958, 52);
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
            labMode.Location = new Point(30, 25);
            labMode.Name = "labMode";
            labMode.Size = new Size(120, 25);
            labMode.TabIndex = 5;
            labMode.Text = "Placing Mode";
            // 
            // labSeed
            // 
            labSeed.AutoSize = true;
            labSeed.Location = new Point(958, 24);
            labSeed.Name = "labSeed";
            labSeed.Size = new Size(208, 25);
            labSeed.TabIndex = 6;
            labSeed.Text = "Place big slime in middle";
            // 
            // radButtonSlime
            // 
            radButtonSlime.AutoSize = true;
            radButtonSlime.Checked = true;
            radButtonSlime.Location = new Point(30, 55);
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
            radButtonFood.Location = new Point(30, 86);
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
            groupBox1.Size = new Size(331, 134);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // labelSmellDistance
            // 
            labelSmellDistance.AutoSize = true;
            labelSmellDistance.Location = new Point(931, 305);
            labelSmellDistance.Name = "labelSmellDistance";
            labelSmellDistance.Size = new Size(127, 25);
            labelSmellDistance.TabIndex = 18;
            labelSmellDistance.Text = "Smell Distance";
            labelSmellDistance.TextAlign = ContentAlignment.TopRight;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(911, 342);
            label.Name = "label";
            label.Size = new Size(147, 25);
            label.TabIndex = 19;
            label.Text = "Smell Angle (rad)";
            label.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(948, 379);
            label1.Name = "label1";
            label1.Size = new Size(110, 25);
            label1.TabIndex = 20;
            label1.Text = "Slime Speed";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(931, 416);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 21;
            label2.Text = "Turning Speed";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(904, 453);
            label3.Name = "label3";
            label3.Size = new Size(154, 25);
            label3.TabIndex = 22;
            label3.Text = "Path Randomness";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(842, 490);
            label4.Name = "label4";
            label4.Size = new Size(216, 25);
            label4.TabIndex = 23;
            label4.Text = "Pheromone Dep. Amount";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(897, 527);
            label5.Name = "label5";
            label5.Size = new Size(161, 25);
            label5.TabIndex = 24;
            label5.Text = "Food Emision Rate";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(958, 562);
            label6.Name = "label6";
            label6.Size = new Size(100, 25);
            label6.TabIndex = 25;
            label6.Text = "Decay Rate";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // upDownSmellDistance
            // 
            upDownSmellDistance.Location = new Point(1067, 303);
            upDownSmellDistance.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            upDownSmellDistance.Name = "upDownSmellDistance";
            upDownSmellDistance.Size = new Size(93, 31);
            upDownSmellDistance.TabIndex = 26;
            // 
            // upDownSmellAngle
            // 
            upDownSmellAngle.DecimalPlaces = 2;
            upDownSmellAngle.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            upDownSmellAngle.Location = new Point(1067, 340);
            upDownSmellAngle.Maximum = new decimal(new int[] { 627, 0, 0, 131072 });
            upDownSmellAngle.Name = "upDownSmellAngle";
            upDownSmellAngle.Size = new Size(93, 31);
            upDownSmellAngle.TabIndex = 27;
            // 
            // upDownSlimeSpeed
            // 
            upDownSlimeSpeed.DecimalPlaces = 1;
            upDownSlimeSpeed.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            upDownSlimeSpeed.Location = new Point(1067, 377);
            upDownSlimeSpeed.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            upDownSlimeSpeed.Name = "upDownSlimeSpeed";
            upDownSlimeSpeed.Size = new Size(93, 31);
            upDownSlimeSpeed.TabIndex = 28;
            // 
            // upDownTurningSpeed
            // 
            upDownTurningSpeed.DecimalPlaces = 1;
            upDownTurningSpeed.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            upDownTurningSpeed.Location = new Point(1067, 414);
            upDownTurningSpeed.Maximum = new decimal(new int[] { 31, 0, 0, 65536 });
            upDownTurningSpeed.Name = "upDownTurningSpeed";
            upDownTurningSpeed.Size = new Size(93, 31);
            upDownTurningSpeed.TabIndex = 29;
            // 
            // upDownPathRandom
            // 
            upDownPathRandom.DecimalPlaces = 2;
            upDownPathRandom.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            upDownPathRandom.Location = new Point(1067, 451);
            upDownPathRandom.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            upDownPathRandom.Name = "upDownPathRandom";
            upDownPathRandom.Size = new Size(93, 31);
            upDownPathRandom.TabIndex = 30;
            // 
            // upDownDepositAmount
            // 
            upDownDepositAmount.DecimalPlaces = 1;
            upDownDepositAmount.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            upDownDepositAmount.Location = new Point(1067, 488);
            upDownDepositAmount.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            upDownDepositAmount.Name = "upDownDepositAmount";
            upDownDepositAmount.Size = new Size(93, 31);
            upDownDepositAmount.TabIndex = 31;
            // 
            // upDownEmisionRate
            // 
            upDownEmisionRate.Location = new Point(1067, 525);
            upDownEmisionRate.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            upDownEmisionRate.Name = "upDownEmisionRate";
            upDownEmisionRate.Size = new Size(93, 31);
            upDownEmisionRate.TabIndex = 32;
            // 
            // upDownDecayRate
            // 
            upDownDecayRate.DecimalPlaces = 2;
            upDownDecayRate.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            upDownDecayRate.Location = new Point(1067, 560);
            upDownDecayRate.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            upDownDecayRate.Name = "upDownDecayRate";
            upDownDecayRate.Size = new Size(93, 31);
            upDownDecayRate.TabIndex = 33;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(830, 242);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(150, 34);
            btnSaveSettings.TabIndex = 34;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnLoadSettings
            // 
            btnLoadSettings.Location = new Point(1011, 242);
            btnLoadSettings.Name = "btnLoadSettings";
            btnLoadSettings.Size = new Size(150, 34);
            btnLoadSettings.TabIndex = 35;
            btnLoadSettings.Text = "Load Settings";
            btnLoadSettings.UseVisualStyleBackColor = true;
            btnLoadSettings.Click += btnLoadSettings_Click;
            // 
            // upDownFoodNutrition
            // 
            upDownFoodNutrition.Location = new Point(1067, 597);
            upDownFoodNutrition.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            upDownFoodNutrition.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            upDownFoodNutrition.Name = "upDownFoodNutrition";
            upDownFoodNutrition.Size = new Size(93, 31);
            upDownFoodNutrition.TabIndex = 36;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(929, 599);
            label7.Name = "label7";
            label7.Size = new Size(129, 25);
            label7.TabIndex = 37;
            label7.Text = "Food Nutrition";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(872, 635);
            label8.Name = "label8";
            label8.Size = new Size(186, 25);
            label8.TabIndex = 39;
            label8.Text = "Food Does Not Perish\r\n";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // checkBoxFoodForever
            // 
            checkBoxFoodForever.AutoSize = true;
            checkBoxFoodForever.Location = new Point(1100, 638);
            checkBoxFoodForever.Name = "checkBoxFoodForever";
            checkBoxFoodForever.Size = new Size(22, 21);
            checkBoxFoodForever.TabIndex = 40;
            checkBoxFoodForever.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 687);
            Controls.Add(checkBoxFoodForever);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(upDownFoodNutrition);
            Controls.Add(btnLoadSettings);
            Controls.Add(btnSaveSettings);
            Controls.Add(upDownDecayRate);
            Controls.Add(upDownEmisionRate);
            Controls.Add(upDownDepositAmount);
            Controls.Add(upDownPathRandom);
            Controls.Add(upDownTurningSpeed);
            Controls.Add(upDownSlimeSpeed);
            Controls.Add(upDownSmellAngle);
            Controls.Add(upDownSmellDistance);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label);
            Controls.Add(labelSmellDistance);
            Controls.Add(groupBox1);
            Controls.Add(labSeed);
            Controls.Add(btnSeed);
            Controls.Add(btnClear);
            Controls.Add(pictureBox1);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Slime Simulation V.2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)upDownSmellDistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownSmellAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownSlimeSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownTurningSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownPathRandom).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownDepositAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownEmisionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownDecayRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownFoodNutrition).EndInit();
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
        private Label labelSmellDistance;
        private Label label;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown upDownSmellDistance;
        private NumericUpDown upDownSmellAngle;
        private NumericUpDown upDownSlimeSpeed;
        private NumericUpDown upDownTurningSpeed;
        private NumericUpDown upDownPathRandom;
        private NumericUpDown upDownDepositAmount;
        private NumericUpDown upDownEmisionRate;
        private NumericUpDown upDownDecayRate;
        private Button btnSaveSettings;
        private Button btnLoadSettings;
        private NumericUpDown upDownFoodNutrition;
        private Label label7;
        private RadioButton radButtonFoodForever;
        private Label label8;
        private CheckBox checkBoxFoodForever;
    }
}
