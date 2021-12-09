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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation11 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
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
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.la_Chiphi = new System.Windows.Forms.Label();
            this.g_Source = new System.Windows.Forms.GroupBox();
            this.rTB_Source = new System.Windows.Forms.RichTextBox();
            this.btn_ReadFile = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Tao = new System.Windows.Forms.Button();
            this.rTB_HuongDan = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.g_Source.SuspendLayout();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            resources.ApplyResources(this.gViewer1, "gViewer1");
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
            this.gViewer1.LooseOffsetForRouting = 0.25D;
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
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = false;
            this.gViewer1.Transform = planeTransformation11;
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
            resources.ApplyResources(this.rd_Dijkstra, "rd_Dijkstra");
            this.rd_Dijkstra.Name = "rd_Dijkstra";
            this.rd_Dijkstra.TabStop = true;
            this.rd_Dijkstra.UseVisualStyleBackColor = true;
            this.rd_Dijkstra.CheckedChanged += new System.EventHandler(this.rd_Dijkstra_CheckedChanged);
            // 
            // rd_Kruskal
            // 
            resources.ApplyResources(this.rd_Kruskal, "rd_Kruskal");
            this.rd_Kruskal.Name = "rd_Kruskal";
            this.rd_Kruskal.TabStop = true;
            this.rd_Kruskal.UseVisualStyleBackColor = true;
            this.rd_Kruskal.CheckedChanged += new System.EventHandler(this.rd_Kruskal_CheckedChanged);
            // 
            // rd_Prim
            // 
            resources.ApplyResources(this.rd_Prim, "rd_Prim");
            this.rd_Prim.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rd_Prim.Name = "rd_Prim";
            this.rd_Prim.TabStop = true;
            this.rd_Prim.UseVisualStyleBackColor = true;
            this.rd_Prim.CheckedChanged += new System.EventHandler(this.rd_Prim_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_Dijkstra);
            this.groupBox1.Controls.Add(this.rd_Kruskal);
            this.groupBox1.Controls.Add(this.rd_Prim);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textOpen
            // 
            this.textOpen.BackColor = System.Drawing.Color.White;
            this.textOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOpen.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.textOpen, "textOpen");
            this.textOpen.Name = "textOpen";
            this.textOpen.ReadOnly = true;
            this.textOpen.TextChanged += new System.EventHandler(this.textOpen_TextChanged);
            // 
            // textClose
            // 
            this.textClose.BackColor = System.Drawing.Color.White;
            this.textClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textClose.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.textClose, "textClose");
            this.textClose.Name = "textClose";
            this.textClose.ReadOnly = true;
            this.textClose.TextChanged += new System.EventHandler(this.textClose_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textG
            // 
            this.textG.BackColor = System.Drawing.Color.White;
            this.textG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textG.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.textG, "textG");
            this.textG.Name = "textG";
            this.textG.ReadOnly = true;
            // 
            // textPrev
            // 
            this.textPrev.BackColor = System.Drawing.Color.White;
            this.textPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPrev.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.textPrev, "textPrev");
            this.textPrev.Name = "textPrev";
            this.textPrev.ReadOnly = true;
            this.textPrev.TextChanged += new System.EventHandler(this.textPrev_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textOpen);
            this.groupBox2.Controls.Add(this.textPrev);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textG);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textClose);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // la_Chiphi
            // 
            resources.ApplyResources(this.la_Chiphi, "la_Chiphi");
            this.la_Chiphi.Name = "la_Chiphi";
            this.la_Chiphi.Click += new System.EventHandler(this.la_Chiphi_Click);
            // 
            // g_Source
            // 
            this.g_Source.Controls.Add(this.rTB_Source);
            resources.ApplyResources(this.g_Source, "g_Source");
            this.g_Source.Name = "g_Source";
            this.g_Source.TabStop = false;
            this.g_Source.Enter += new System.EventHandler(this.g_Source_Enter);
            // 
            // rTB_Source
            // 
            this.rTB_Source.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.rTB_Source, "rTB_Source");
            this.rTB_Source.Name = "rTB_Source";
            this.rTB_Source.ReadOnly = true;
            // 
            // btn_ReadFile
            // 
            this.btn_ReadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_ReadFile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btn_ReadFile, "btn_ReadFile");
            this.btn_ReadFile.ForeColor = System.Drawing.Color.White;
            this.btn_ReadFile.Name = "btn_ReadFile";
            this.btn_ReadFile.UseVisualStyleBackColor = false;
            this.btn_ReadFile.Click += new System.EventHandler(this.btn_ReadFile_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_Next.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btn_Next, "btn_Next");
            this.btn_Next.ForeColor = System.Drawing.Color.Black;
            this.btn_Next.Image = global::AI.Properties.Resources.next_button3;
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(79)))));
            this.btn_Run.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btn_Run, "btn_Run");
            this.btn_Run.ForeColor = System.Drawing.Color.White;
            this.btn_Run.Image = global::AI.Properties.Resources.start_button;
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_Previous.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btn_Previous, "btn_Previous");
            this.btn_Previous.ForeColor = System.Drawing.Color.Black;
            this.btn_Previous.Image = global::AI.Properties.Resources.previos_button1;
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.UseVisualStyleBackColor = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Tao
            // 
            resources.ApplyResources(this.btn_Tao, "btn_Tao");
            this.btn_Tao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.btn_Tao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btn_Tao.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Tao.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.UseVisualStyleBackColor = false;
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // rTB_HuongDan
            // 
            this.rTB_HuongDan.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.rTB_HuongDan, "rTB_HuongDan");
            this.rTB_HuongDan.Name = "rTB_HuongDan";
            this.rTB_HuongDan.ReadOnly = true;
            this.rTB_HuongDan.TextChanged += new System.EventHandler(this.rTB_HuongDan_TextChanged);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rTB_HuongDan);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_Tao);
            this.Controls.Add(this.g_Source);
            this.Controls.Add(this.la_Chiphi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ReadFile);
            this.Controls.Add(this.gViewer1);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label la_Chiphi;
        private System.Windows.Forms.GroupBox g_Source;
        private System.Windows.Forms.RichTextBox rTB_Source;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Tao;
        private System.Windows.Forms.RichTextBox rTB_HuongDan;
    }
}