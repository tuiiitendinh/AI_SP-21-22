using System.Drawing;
namespace AI
{
    partial class Main
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
        ///
        private void InitializeComponent()
        {
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation1 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rd_Dijkstra = new System.Windows.Forms.RadioButton();
            this.rd_Kruskal = new System.Windows.Forms.RadioButton();
            this.rd_Prim = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textOpen = new System.Windows.Forms.TextBox();
            this.textClose = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textG = new System.Windows.Forms.TextBox();
            this.textPrev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.la_Chiphi = new System.Windows.Forms.Label();
            this.g_HuongDan = new System.Windows.Forms.GroupBox();
            this.g_Source = new System.Windows.Forms.GroupBox();
            this.rTB_Source = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Tao = new System.Windows.Forms.Button();
            this.btn_ReadFile = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.g_Source.SuspendLayout();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackColor = System.Drawing.Color.White;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(479, 98);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(833, 626);
            this.gViewer1.TabIndex = 0;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = false;
            this.gViewer1.Transform = planeTransformation1;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            this.gViewer1.Load += new System.EventHandler(this.gViewer1_Load);
            this.gViewer1.Click += new System.EventHandler(this.gViewer1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rd_Dijkstra
            // 
            this.rd_Dijkstra.AutoSize = true;
            this.rd_Dijkstra.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Dijkstra.Location = new System.Drawing.Point(221, 33);
            this.rd_Dijkstra.Margin = new System.Windows.Forms.Padding(4);
            this.rd_Dijkstra.Name = "rd_Dijkstra";
            this.rd_Dijkstra.Size = new System.Drawing.Size(104, 32);
            this.rd_Dijkstra.TabIndex = 2;
            this.rd_Dijkstra.TabStop = true;
            this.rd_Dijkstra.Text = "Dijkstra";
            this.rd_Dijkstra.UseVisualStyleBackColor = true;
            this.rd_Dijkstra.CheckedChanged += new System.EventHandler(this.rd_Dijkstra_CheckedChanged);
            // 
            // rd_Kruskal
            // 
            this.rd_Kruskal.AutoSize = true;
            this.rd_Kruskal.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Kruskal.Location = new System.Drawing.Point(103, 35);
            this.rd_Kruskal.Margin = new System.Windows.Forms.Padding(4);
            this.rd_Kruskal.Name = "rd_Kruskal";
            this.rd_Kruskal.Size = new System.Drawing.Size(100, 32);
            this.rd_Kruskal.TabIndex = 2;
            this.rd_Kruskal.TabStop = true;
            this.rd_Kruskal.Text = "Kruskal";
            this.rd_Kruskal.UseVisualStyleBackColor = true;
            this.rd_Kruskal.CheckedChanged += new System.EventHandler(this.rd_Kruskal_CheckedChanged);
            // 
            // rd_Prim
            // 
            this.rd_Prim.AutoSize = true;
            this.rd_Prim.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rd_Prim.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Prim.Location = new System.Drawing.Point(8, 37);
            this.rd_Prim.Margin = new System.Windows.Forms.Padding(4);
            this.rd_Prim.Name = "rd_Prim";
            this.rd_Prim.Size = new System.Drawing.Size(76, 32);
            this.rd_Prim.TabIndex = 2;
            this.rd_Prim.TabStop = true;
            this.rd_Prim.Text = "Prim";
            this.rd_Prim.UseVisualStyleBackColor = true;
            this.rd_Prim.CheckedChanged += new System.EventHandler(this.rd_Prim_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_Dijkstra);
            this.groupBox1.Controls.Add(this.rd_Kruskal);
            this.groupBox1.Controls.Add(this.rd_Prim);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(479, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(335, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // textOpen
            // 
            this.textOpen.BackColor = System.Drawing.Color.White;
            this.textOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOpen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOpen.ForeColor = System.Drawing.Color.Black;
            this.textOpen.Location = new System.Drawing.Point(8, 85);
            this.textOpen.Margin = new System.Windows.Forms.Padding(4);
            this.textOpen.Name = "textOpen";
            this.textOpen.ReadOnly = true;
            this.textOpen.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textOpen.Size = new System.Drawing.Size(158, 32);
            this.textOpen.TabIndex = 7;
            this.textOpen.TextChanged += new System.EventHandler(this.textOpen_TextChanged);
            // 
            // textClose
            // 
            this.textClose.BackColor = System.Drawing.Color.White;
            this.textClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClose.ForeColor = System.Drawing.Color.Black;
            this.textClose.Location = new System.Drawing.Point(274, 94);
            this.textClose.Margin = new System.Windows.Forms.Padding(4);
            this.textClose.Name = "textClose";
            this.textClose.ReadOnly = true;
            this.textClose.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textClose.Size = new System.Drawing.Size(158, 32);
            this.textClose.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Open";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Close";
            // 
            // textG
            // 
            this.textG.BackColor = System.Drawing.Color.White;
            this.textG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textG.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textG.ForeColor = System.Drawing.Color.Black;
            this.textG.Location = new System.Drawing.Point(8, 183);
            this.textG.Margin = new System.Windows.Forms.Padding(4);
            this.textG.Name = "textG";
            this.textG.ReadOnly = true;
            this.textG.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textG.Size = new System.Drawing.Size(158, 32);
            this.textG.TabIndex = 11;
            // 
            // textPrev
            // 
            this.textPrev.BackColor = System.Drawing.Color.White;
            this.textPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPrev.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrev.ForeColor = System.Drawing.Color.Black;
            this.textPrev.Location = new System.Drawing.Point(274, 183);
            this.textPrev.Margin = new System.Windows.Forms.Padding(4);
            this.textPrev.Name = "textPrev";
            this.textPrev.ReadOnly = true;
            this.textPrev.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textPrev.Size = new System.Drawing.Size(158, 32);
            this.textPrev.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Prev";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textOpen);
            this.groupBox2.Controls.Add(this.textPrev);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textG);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textClose);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1321, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(493, 283);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Argument";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1603, -129);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(361, 27);
            this.textBox1.TabIndex = 8;
            // 
            // la_Chiphi
            // 
            this.la_Chiphi.AutoSize = true;
            this.la_Chiphi.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_Chiphi.Location = new System.Drawing.Point(849, 15);
            this.la_Chiphi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.la_Chiphi.Name = "la_Chiphi";
            this.la_Chiphi.Size = new System.Drawing.Size(124, 37);
            this.la_Chiphi.TabIndex = 17;
            this.la_Chiphi.Text = "Distance";
            // 
            // g_HuongDan
            // 
            this.g_HuongDan.BackColor = System.Drawing.Color.White;
            this.g_HuongDan.Location = new System.Drawing.Point(1329, 319);
            this.g_HuongDan.Margin = new System.Windows.Forms.Padding(4);
            this.g_HuongDan.Name = "g_HuongDan";
            this.g_HuongDan.Padding = new System.Windows.Forms.Padding(4);
            this.g_HuongDan.Size = new System.Drawing.Size(481, 406);
            this.g_HuongDan.TabIndex = 18;
            this.g_HuongDan.TabStop = false;
            this.g_HuongDan.Enter += new System.EventHandler(this.g_HuongDan_Enter);
            // 
            // g_Source
            // 
            this.g_Source.Controls.Add(this.rTB_Source);
            this.g_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_Source.Location = new System.Drawing.Point(17, 89);
            this.g_Source.Margin = new System.Windows.Forms.Padding(4);
            this.g_Source.Name = "g_Source";
            this.g_Source.Padding = new System.Windows.Forms.Padding(4);
            this.g_Source.Size = new System.Drawing.Size(454, 532);
            this.g_Source.TabIndex = 19;
            this.g_Source.TabStop = false;
            // 
            // rTB_Source
            // 
            this.rTB_Source.BackColor = System.Drawing.Color.White;
            this.rTB_Source.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTB_Source.Location = new System.Drawing.Point(8, 9);
            this.rTB_Source.Margin = new System.Windows.Forms.Padding(4);
            this.rTB_Source.Name = "rTB_Source";
            this.rTB_Source.ReadOnly = true;
            this.rTB_Source.Size = new System.Drawing.Size(434, 522);
            this.rTB_Source.TabIndex = 0;
            this.rTB_Source.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1321, 290);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Step";
            // 
            // btn_Tao
            // 
            this.btn_Tao.AutoSize = true;
            this.btn_Tao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_Tao.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Tao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tao.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tao.ForeColor = System.Drawing.Color.White;
            this.btn_Tao.Location = new System.Drawing.Point(219, 15);
            this.btn_Tao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.Size = new System.Drawing.Size(226, 66);
            this.btn_Tao.TabIndex = 20;
            this.btn_Tao.Text = "Create Matrix";
            this.btn_Tao.UseVisualStyleBackColor = false;
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // btn_ReadFile
            // 
            this.btn_ReadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_ReadFile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_ReadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadFile.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReadFile.ForeColor = System.Drawing.Color.White;
            this.btn_ReadFile.Location = new System.Drawing.Point(25, 13);
            this.btn_ReadFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReadFile.Name = "btn_ReadFile";
            this.btn_ReadFile.Size = new System.Drawing.Size(177, 68);
            this.btn_ReadFile.TabIndex = 1;
            this.btn_ReadFile.Text = "Read File";
            this.btn_ReadFile.UseVisualStyleBackColor = false;
            this.btn_ReadFile.Click += new System.EventHandler(this.btn_ReadFile_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_Next.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Next.ForeColor = System.Drawing.Color.Black;
            this.btn_Next.Image = global::AI.Properties.Resources.next_button3;
            this.btn_Next.Location = new System.Drawing.Point(269, 638);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(154, 69);
            this.btn_Next.TabIndex = 5;
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(79)))));
            this.btn_Run.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Run.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Run.ForeColor = System.Drawing.Color.White;
            this.btn_Run.Image = global::AI.Properties.Resources.start_button;
            this.btn_Run.Location = new System.Drawing.Point(1158, 15);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(154, 68);
            this.btn_Run.TabIndex = 3;
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_Previous.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Previous.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Previous.ForeColor = System.Drawing.Color.Black;
            this.btn_Previous.Image = global::AI.Properties.Resources.previos_button1;
            this.btn_Previous.Location = new System.Drawing.Point(48, 638);
            this.btn_Previous.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(154, 69);
            this.btn_Previous.TabIndex = 6;
            this.btn_Previous.UseVisualStyleBackColor = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1849, 736);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Tao);
            this.Controls.Add(this.g_Source);
            this.Controls.Add(this.g_HuongDan);
            this.Controls.Add(this.la_Chiphi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ReadFile);
            this.Controls.Add(this.gViewer1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Theory";
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.g_Source.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.Button btn_ReadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton rd_Dijkstra;
        private System.Windows.Forms.RadioButton rd_Kruskal;
        private System.Windows.Forms.RadioButton rd_Prim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.TextBox textOpen;
        private System.Windows.Forms.TextBox textClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textG;
        private System.Windows.Forms.TextBox textPrev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label la_Chiphi;
        private System.Windows.Forms.GroupBox g_HuongDan;
        private System.Windows.Forms.GroupBox g_Source;
        private System.Windows.Forms.RichTextBox rTB_Source;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Tao;
    }
}