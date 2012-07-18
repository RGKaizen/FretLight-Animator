namespace FretLight
{
    partial class RuleBuilderGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleBuilderGUI));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartFrameField = new System.Windows.Forms.TextBox();
            this.EndFrameField = new System.Windows.Forms.TextBox();
            this.FretBoard = new System.Windows.Forms.Panel();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StartPointField = new System.Windows.Forms.TextBox();
            this.EndPointField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.RuleTypeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting Frame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ending Frame";
            // 
            // StartFrameField
            // 
            this.StartFrameField.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StartFrameField.Location = new System.Drawing.Point(97, 9);
            this.StartFrameField.Name = "StartFrameField";
            this.StartFrameField.Size = new System.Drawing.Size(24, 20);
            this.StartFrameField.TabIndex = 2;
            // 
            // EndFrameField
            // 
            this.EndFrameField.Location = new System.Drawing.Point(97, 35);
            this.EndFrameField.Name = "EndFrameField";
            this.EndFrameField.Size = new System.Drawing.Size(24, 20);
            this.EndFrameField.TabIndex = 3;
            // 
            // FretBoard
            // 
            this.FretBoard.BackColor = System.Drawing.SystemColors.Control;
            this.FretBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FretBoard.BackgroundImage")));
            this.FretBoard.Location = new System.Drawing.Point(19, 65);
            this.FretBoard.Name = "FretBoard";
            this.FretBoard.Size = new System.Drawing.Size(954, 133);
            this.FretBoard.TabIndex = 7;
            this.FretBoard.Click += new System.EventHandler(this.FretBoard_Click);
            this.FretBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.FretBoard_Paint);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(268, 35);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(76, 20);
            this.ConfirmButton.TabIndex = 8;
            this.ConfirmButton.Text = "Ok";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Starting Point";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "EndingPoint";
            // 
            // StartPointField
            // 
            this.StartPointField.Location = new System.Drawing.Point(211, 9);
            this.StartPointField.Name = "StartPointField";
            this.StartPointField.ReadOnly = true;
            this.StartPointField.Size = new System.Drawing.Size(38, 20);
            this.StartPointField.TabIndex = 11;
            // 
            // EndPointField
            // 
            this.EndPointField.Location = new System.Drawing.Point(210, 35);
            this.EndPointField.Name = "EndPointField";
            this.EndPointField.ReadOnly = true;
            this.EndPointField.Size = new System.Drawing.Size(39, 20);
            this.EndPointField.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(306, 9);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(124, 20);
            this.NameBox.TabIndex = 14;
            // 
            // RuleTypeBox
            // 
            this.RuleTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RuleTypeBox.FormattingEnabled = true;
            this.RuleTypeBox.Items.AddRange(new object[] {
            "Basic",
            "Conway"});
            this.RuleTypeBox.Location = new System.Drawing.Point(445, 8);
            this.RuleTypeBox.Name = "RuleTypeBox";
            this.RuleTypeBox.Size = new System.Drawing.Size(121, 21);
            this.RuleTypeBox.TabIndex = 17;
            this.RuleTypeBox.SelectedIndexChanged += new System.EventHandler(this.RuleTypeBox_SelectedIndexChanged);
            // 
            // RuleBuilderGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 209);
            this.Controls.Add(this.RuleTypeBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EndPointField);
            this.Controls.Add(this.StartPointField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.FretBoard);
            this.Controls.Add(this.EndFrameField);
            this.Controls.Add(this.StartFrameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RuleBuilderGUI";
            this.Text = "Rule Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StartFrameField;
        private System.Windows.Forms.TextBox EndFrameField;
        private System.Windows.Forms.Panel FretBoard;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TextBox StartPointField;
        private System.Windows.Forms.TextBox EndPointField;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.ComboBox RuleTypeBox;
    }
}