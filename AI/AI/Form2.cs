using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += MainPage_FormClosing;
        }
        public int Sodinh = 0;
        public int[,] mt = new int[100,100];
        int h = 20, m = 3;
        int[] tmp = new int[10000];
        int chisotmp = 0;
        bool kt = false;
        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!kt) {
                MessageBox.Show("Input Error!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            chisotmp = 0;
            int x = 3, y = 3;
            panel1.Controls.Clear();
            Sodinh = trackBar1.Value;
            for(int i = 0; i <= Sodinh; i++)
            {
               for(int j =0;j <= Sodinh;j++)
                {
                   // tmp[i + j] = int.MinValue;
                    mt[i, j] = int.MinValue;
                    TextBox a = new TextBox();
                    a.Multiline = true;
                    a.Width = 50; 
                    a.Height = h;
                    if (i == 0 && j == 0)
                    {
                        a.ReadOnly = true;
                        a.Text = $"*";
                    }
                    else
                    {
                        if (i == 0)
                        {
                            a.ReadOnly = true;
                            a.Text = $"N{j-1}";
                        }
                        if (j == 0)
                        {
                            a.ReadOnly = true;
                            a.Text = $"N{i-1}";
                        }
                        if (i == j)
                        {
                            a.ReadOnly = true;
                            a.Text = $"∞";
                        }
                        if (i> j && j !=0)
                        {
                            a.ReadOnly = true;
                            a.Text = "???";
                        }
                    }
                    a.Location = new Point(x, y);
                    panel1.Controls.Add(a);
                    x += m + 50;
                }
                x = 3;
                y += m + h;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            so_dinh.Text = "1";
        }
        Random rnd = new Random();
        private void button2_Click(object sender, EventArgs e)
        { 
            foreach(TextBox textBox in panel1.Controls)
            {
                if (!textBox.ReadOnly)
                {
                    int trongso = rnd.Next(-100, 100);
                    if (trongso < 0) textBox.Text = "∞";
                    else textBox.Text = trongso.ToString();
                   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 
             kt = true;
            foreach(TextBox textBox in panel1.Controls)
            {
                int trongso;
                if (!textBox.ReadOnly)
                {
                    try
                    {

                        if (textBox.Text == "∞"||int.Parse(textBox.Text) < 0 ) trongso = int.MinValue;
                        else trongso = int.Parse(textBox.Text);
                        tmp[chisotmp++] = trongso;
                    }
                    catch
                    {
                        kt = false;
                        MessageBox.Show("Invalid matrix", "Input Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            if (kt)
            {
                chisotmp = 0;
                for(int i = 0; i < Sodinh-1; i++)
                {
                    for(int j = i+1; j < Sodinh; j++)
                    {
                        if (i != j)
                        {
                            if (tmp[chisotmp] == int.MinValue) mt[i, j] = mt[j, i] = int.MinValue;
                            else
                            {
                              
                                mt[i, j] = mt[j, i] = tmp[chisotmp];
                            }
                            chisotmp++;
                        }
                    }
                }
                chisotmp = 0;
                this.Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            so_dinh.Text = trackBar1.Value.ToString();
        }

     
    }
}
