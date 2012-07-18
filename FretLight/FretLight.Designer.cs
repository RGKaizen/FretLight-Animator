namespace FretLight
{
    partial class FretLight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FretLight));
            this.FretBoard = new System.Windows.Forms.Panel();
            this.LatencyBar = new System.Windows.Forms.TrackBar();
            this.AddFrameButton = new System.Windows.Forms.Button();
            this.RemoveFrameButton = new System.Windows.Forms.Button();
            this.RulesListbox = new System.Windows.Forms.ListBox();
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayButton = new System.Windows.Forms.Button();
            this.LatencyLabel = new System.Windows.Forms.Label();
            this.CurrentFrameLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GuitarCommFlag = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LatencyBar)).BeginInit();
            this.SuspendLayout();
            // 
            // FretBoard
            // 
            this.FretBoard.BackColor = System.Drawing.SystemColors.Control;
            this.FretBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FretBoard.BackgroundImage")));
            this.FretBoard.Location = new System.Drawing.Point(16, 12);
            this.FretBoard.Name = "FretBoard";
            this.FretBoard.Size = new System.Drawing.Size(954, 133);
            this.FretBoard.TabIndex = 6;
            this.FretBoard.Click += new System.EventHandler(this.FretBoard_Click);
            this.FretBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.FretBoard_Paint);
            // 
            // LatencyBar
            // 
            this.LatencyBar.Location = new System.Drawing.Point(361, 157);
            this.LatencyBar.Maximum = 1000;
            this.LatencyBar.Minimum = 100;
            this.LatencyBar.Name = "LatencyBar";
            this.LatencyBar.Size = new System.Drawing.Size(276, 45);
            this.LatencyBar.TabIndex = 8;
            this.LatencyBar.TickFrequency = 1000;
            this.LatencyBar.Value = 250;
            this.LatencyBar.Scroll += new System.EventHandler(this.Latency_Scroll);
            // 
            // AddFrameButton
            // 
            this.AddFrameButton.Location = new System.Drawing.Point(1067, 11);
            this.AddFrameButton.Name = "AddFrameButton";
            this.AddFrameButton.Size = new System.Drawing.Size(71, 20);
            this.AddFrameButton.TabIndex = 10;
            this.AddFrameButton.Text = "Add";
            this.AddFrameButton.UseVisualStyleBackColor = true;
            this.AddFrameButton.Click += new System.EventHandler(this.addRule);
            // 
            // RemoveFrameButton
            // 
            this.RemoveFrameButton.Location = new System.Drawing.Point(1067, 37);
            this.RemoveFrameButton.Name = "RemoveFrameButton";
            this.RemoveFrameButton.Size = new System.Drawing.Size(71, 20);
            this.RemoveFrameButton.TabIndex = 11;
            this.RemoveFrameButton.Text = "Remove";
            this.RemoveFrameButton.UseVisualStyleBackColor = true;
            this.RemoveFrameButton.Click += new System.EventHandler(this.removeRule);
            // 
            // RulesListbox
            // 
            this.RulesListbox.FormattingEnabled = true;
            this.RulesListbox.Location = new System.Drawing.Point(985, 12);
            this.RulesListbox.Name = "RulesListbox";
            this.RulesListbox.Size = new System.Drawing.Size(76, 134);
            this.RulesListbox.TabIndex = 14;
            this.RulesListbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RulesListbox_MouseDoubleClick);
            // 
            // FrameTimer
            // 
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(643, 161);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 15;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // LatencyLabel
            // 
            this.LatencyLabel.AutoSize = true;
            this.LatencyLabel.Location = new System.Drawing.Point(272, 161);
            this.LatencyLabel.Name = "LatencyLabel";
            this.LatencyLabel.Size = new System.Drawing.Size(57, 13);
            this.LatencyLabel.TabIndex = 16;
            this.LatencyLabel.Text = "Latency: 250";
            // 
            // CurrentFrameLabel
            // 
            this.CurrentFrameLabel.AutoSize = true;
            this.CurrentFrameLabel.Location = new System.Drawing.Point(154, 161);
            this.CurrentFrameLabel.Name = "CurrentFrameLabel";
            this.CurrentFrameLabel.Size = new System.Drawing.Size(42, 13);
            this.CurrentFrameLabel.TabIndex = 17;
            this.CurrentFrameLabel.Text = "Frame: ";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1067, 75);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(71, 22);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Save Rules";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GuitarCommFlag
            // 
            this.GuitarCommFlag.AutoSize = true;
            this.GuitarCommFlag.Checked = true;
            this.GuitarCommFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GuitarCommFlag.Location = new System.Drawing.Point(16, 165);
            this.GuitarCommFlag.Name = "GuitarCommFlag";
            this.GuitarCommFlag.Size = new System.Drawing.Size(94, 17);
            this.GuitarCommFlag.TabIndex = 19;
            this.GuitarCommFlag.Text = "Send to Guitar";
            this.GuitarCommFlag.UseVisualStyleBackColor = true;
            this.GuitarCommFlag.CheckedChanged += new System.EventHandler(this.GuitarCommFlag_CheckedChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(734, 161);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 20;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(1067, 103);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(71, 22);
            this.LoadButton.TabIndex = 21;
            this.LoadButton.Text = "Load Rules";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // FretLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 196);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.GuitarCommFlag);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CurrentFrameLabel);
            this.Controls.Add(this.LatencyLabel);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.RulesListbox);
            this.Controls.Add(this.RemoveFrameButton);
            this.Controls.Add(this.AddFrameButton);
            this.Controls.Add(this.LatencyBar);
            this.Controls.Add(this.FretBoard);
            this.Name = "FretLight";
            this.Text = "FretLight Animator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FretLight_FormClosed);
            this.Load += new System.EventHandler(this.FretLight_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LatencyBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FretBoard;
        private System.Windows.Forms.TrackBar LatencyBar;
        private System.Windows.Forms.Button AddFrameButton;
        private System.Windows.Forms.Button RemoveFrameButton;
        private System.Windows.Forms.ListBox RulesListbox;
        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label LatencyLabel;
        private System.Windows.Forms.Label CurrentFrameLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox GuitarCommFlag;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button LoadButton;

    }
}

