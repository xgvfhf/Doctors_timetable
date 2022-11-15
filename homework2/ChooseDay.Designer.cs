
namespace homework2
{
    partial class ChooseDay
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
            this.Monday = new System.Windows.Forms.Button();
            this.Tuesday = new System.Windows.Forms.Button();
            this.Wednesday = new System.Windows.Forms.Button();
            this.Thursday = new System.Windows.Forms.Button();
            this.Friday = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Monday
            // 
            this.Monday.Location = new System.Drawing.Point(66, 77);
            this.Monday.Name = "Monday";
            this.Monday.Size = new System.Drawing.Size(75, 23);
            this.Monday.TabIndex = 0;
            this.Monday.Text = "14.11";
            this.Monday.UseVisualStyleBackColor = true;
            this.Monday.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tuesday
            // 
            this.Tuesday.Location = new System.Drawing.Point(208, 77);
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.Size = new System.Drawing.Size(75, 23);
            this.Tuesday.TabIndex = 1;
            this.Tuesday.Text = "15.11";
            this.Tuesday.UseVisualStyleBackColor = true;
            this.Tuesday.Click += new System.EventHandler(this.button1_Click);
            // 
            // Wednesday
            // 
            this.Wednesday.Location = new System.Drawing.Point(356, 77);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Size = new System.Drawing.Size(75, 23);
            this.Wednesday.TabIndex = 2;
            this.Wednesday.Text = "16.11";
            this.Wednesday.UseVisualStyleBackColor = true;
            this.Wednesday.Click += new System.EventHandler(this.button1_Click);
            // 
            // Thursday
            // 
            this.Thursday.Location = new System.Drawing.Point(494, 77);
            this.Thursday.Name = "Thursday";
            this.Thursday.Size = new System.Drawing.Size(75, 23);
            this.Thursday.TabIndex = 3;
            this.Thursday.Text = "17.11";
            this.Thursday.UseVisualStyleBackColor = true;
            this.Thursday.Click += new System.EventHandler(this.button1_Click);
            // 
            // Friday
            // 
            this.Friday.Location = new System.Drawing.Point(637, 77);
            this.Friday.Name = "Friday";
            this.Friday.Size = new System.Drawing.Size(75, 23);
            this.Friday.TabIndex = 4;
            this.Friday.Text = "18.11";
            this.Friday.UseVisualStyleBackColor = true;
            this.Friday.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose the day of visit";
            // 
            // ChooseDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 133);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Friday);
            this.Controls.Add(this.Thursday);
            this.Controls.Add(this.Wednesday);
            this.Controls.Add(this.Tuesday);
            this.Controls.Add(this.Monday);
            this.Name = "ChooseDay";
            this.Text = "ChooseDay";
            this.Load += new System.EventHandler(this.ChooseDay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Monday;
        private System.Windows.Forms.Button Tuesday;
        private System.Windows.Forms.Button Wednesday;
        private System.Windows.Forms.Button Thursday;
        private System.Windows.Forms.Button Friday;
        private System.Windows.Forms.Label label1;
    }
}