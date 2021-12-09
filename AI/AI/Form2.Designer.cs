
namespace AI
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.so_dinh = new System.Windows.Forms.Label();
            this.roundedButtonNew3 = new AI.RoundedButtonNew();
            this.roundedButtonNew2 = new AI.RoundedButtonNew();
            this.roundedButtonNew1 = new AI.RoundedButtonNew();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of vetices";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(13, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 0);
            this.textBox1.TabIndex = 7;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(110, 65);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(246, 56);
            this.trackBar1.SmallChange = 0;
            this.trackBar1.TabIndex = 13;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(26, 139);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1602, 676);
            this.panel1.TabIndex = 15;
            // 
            // so_dinh
            // 
            this.so_dinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.so_dinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.so_dinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.so_dinh.Location = new System.Drawing.Point(373, 65);
            this.so_dinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.so_dinh.Name = "so_dinh";
            this.so_dinh.Size = new System.Drawing.Size(58, 39);
            this.so_dinh.TabIndex = 16;
            this.so_dinh.Text = "sodinh";
            // 
            // roundedButtonNew3
            // 
            this.roundedButtonNew3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.roundedButtonNew3.BorderSize = 2;
            this.roundedButtonNew3.ControlText = "Save";
            this.roundedButtonNew3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.roundedButtonNew3.FlatAppearance.BorderSize = 0;
            this.roundedButtonNew3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonNew3.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.roundedButtonNew3.ForeColor = System.Drawing.Color.White;
            this.roundedButtonNew3.Location = new System.Drawing.Point(1228, 37);
            this.roundedButtonNew3.Name = "roundedButtonNew3";
            this.roundedButtonNew3.Radius = 19;
            this.roundedButtonNew3.Size = new System.Drawing.Size(277, 84);
            this.roundedButtonNew3.TabIndex = 21;
            this.roundedButtonNew3.TabStop = false;
            this.roundedButtonNew3.Text = "Save";
            this.roundedButtonNew3.Click += new System.EventHandler(this.roundedButtonNew3_Click);
            // 
            // roundedButtonNew2
            // 
            this.roundedButtonNew2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.roundedButtonNew2.BorderSize = 2;
            this.roundedButtonNew2.ControlText = "Ramdom Weights";
            this.roundedButtonNew2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.roundedButtonNew2.FlatAppearance.BorderSize = 0;
            this.roundedButtonNew2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonNew2.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.roundedButtonNew2.ForeColor = System.Drawing.Color.White;
            this.roundedButtonNew2.Location = new System.Drawing.Point(867, 37);
            this.roundedButtonNew2.Name = "roundedButtonNew2";
            this.roundedButtonNew2.Radius = 19;
            this.roundedButtonNew2.Size = new System.Drawing.Size(278, 84);
            this.roundedButtonNew2.TabIndex = 20;
            this.roundedButtonNew2.TabStop = false;
            this.roundedButtonNew2.Text = "Ramdom Weights";
            this.roundedButtonNew2.Click += new System.EventHandler(this.roundedButtonNew2_Click);
            // 
            // roundedButtonNew1
            // 
            this.roundedButtonNew1.BackColor = System.Drawing.Color.White;
            this.roundedButtonNew1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.roundedButtonNew1.BorderSize = 2;
            this.roundedButtonNew1.ControlText = "Create Matrix";
            this.roundedButtonNew1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.roundedButtonNew1.FlatAppearance.BorderSize = 0;
            this.roundedButtonNew1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonNew1.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.roundedButtonNew1.ForeColor = System.Drawing.Color.White;
            this.roundedButtonNew1.Location = new System.Drawing.Point(513, 37);
            this.roundedButtonNew1.Name = "roundedButtonNew1";
            this.roundedButtonNew1.Radius = 19;
            this.roundedButtonNew1.Size = new System.Drawing.Size(288, 84);
            this.roundedButtonNew1.TabIndex = 18;
            this.roundedButtonNew1.TabStop = false;
            this.roundedButtonNew1.Text = "Create Matrix";
            this.roundedButtonNew1.UseVisualStyleBackColor = false;
            this.roundedButtonNew1.Click += new System.EventHandler(this.roundedButtonNew1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1684, 828);
            this.Controls.Add(this.roundedButtonNew3);
            this.Controls.Add(this.roundedButtonNew2);
            this.Controls.Add(this.roundedButtonNew1);
            this.Controls.Add(this.so_dinh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Graph";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label so_dinh;
        private RoundedButtonNew roundedButtonNew1;
        private RoundedButtonNew roundedButtonNew2;
        private RoundedButtonNew roundedButtonNew3;
    }
}
