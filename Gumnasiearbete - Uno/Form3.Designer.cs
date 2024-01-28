namespace Gumnasiearbete___Uno
{
    partial class Form3
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
            this.rbtnRed = new System.Windows.Forms.RadioButton();
            this.rbtnGreen = new System.Windows.Forms.RadioButton();
            this.rbtnYellow = new System.Windows.Forms.RadioButton();
            this.rbtnBlue = new System.Windows.Forms.RadioButton();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnRed
            // 
            this.rbtnRed.AutoSize = true;
            this.rbtnRed.Location = new System.Drawing.Point(148, 23);
            this.rbtnRed.Name = "rbtnRed";
            this.rbtnRed.Size = new System.Drawing.Size(45, 17);
            this.rbtnRed.TabIndex = 0;
            this.rbtnRed.TabStop = true;
            this.rbtnRed.Text = "Red";
            this.rbtnRed.UseVisualStyleBackColor = true;
            this.rbtnRed.CheckedChanged += new System.EventHandler(this.RbtnRed_CheckedChanged);
            // 
            // rbtnGreen
            // 
            this.rbtnGreen.AutoSize = true;
            this.rbtnGreen.Location = new System.Drawing.Point(288, 23);
            this.rbtnGreen.Name = "rbtnGreen";
            this.rbtnGreen.Size = new System.Drawing.Size(54, 17);
            this.rbtnGreen.TabIndex = 1;
            this.rbtnGreen.TabStop = true;
            this.rbtnGreen.Text = "Green";
            this.rbtnGreen.UseVisualStyleBackColor = true;
            this.rbtnGreen.CheckedChanged += new System.EventHandler(this.RbtnGreen_CheckedChanged);
            // 
            // rbtnYellow
            // 
            this.rbtnYellow.AutoSize = true;
            this.rbtnYellow.Location = new System.Drawing.Point(288, 114);
            this.rbtnYellow.Name = "rbtnYellow";
            this.rbtnYellow.Size = new System.Drawing.Size(56, 17);
            this.rbtnYellow.TabIndex = 3;
            this.rbtnYellow.TabStop = true;
            this.rbtnYellow.Text = "Yellow";
            this.rbtnYellow.UseVisualStyleBackColor = true;
            this.rbtnYellow.CheckedChanged += new System.EventHandler(this.RbtnYellow_CheckedChanged);
            // 
            // rbtnBlue
            // 
            this.rbtnBlue.AutoSize = true;
            this.rbtnBlue.Location = new System.Drawing.Point(148, 114);
            this.rbtnBlue.Name = "rbtnBlue";
            this.rbtnBlue.Size = new System.Drawing.Size(46, 17);
            this.rbtnBlue.TabIndex = 2;
            this.rbtnBlue.TabStop = true;
            this.rbtnBlue.Text = "Blue";
            this.rbtnBlue.UseVisualStyleBackColor = true;
            this.rbtnBlue.CheckedChanged += new System.EventHandler(this.RbtnBlue_CheckedChanged);
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Location = new System.Drawing.Point(148, 159);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(225, 31);
            this.btnChooseColor.TabIndex = 4;
            this.btnChooseColor.Text = "Choose color";
            this.btnChooseColor.UseVisualStyleBackColor = true;
            this.btnChooseColor.Click += new System.EventHandler(this.BtnChooseColor_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 252);
            this.Controls.Add(this.btnChooseColor);
            this.Controls.Add(this.rbtnYellow);
            this.Controls.Add(this.rbtnBlue);
            this.Controls.Add(this.rbtnGreen);
            this.Controls.Add(this.rbtnRed);
            this.Name = "Form3";
            this.Text = "Choose your color";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnRed;
        private System.Windows.Forms.RadioButton rbtnGreen;
        private System.Windows.Forms.RadioButton rbtnYellow;
        private System.Windows.Forms.RadioButton rbtnBlue;
        private System.Windows.Forms.Button btnChooseColor;
    }
}