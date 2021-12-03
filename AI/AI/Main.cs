using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Msagl = Microsoft.Msagl.Drawing;
namespace AI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------//Khai bao bien///-------------------------------------------------------------------------------------------
        string[] Node = new string[100];
        int[,] Weight = new int[100, 1000];
        int coutNode = 0;
        string path = "";
        bool nghivan = false, am = false;
        List<int> dinhDuongDi = new List<int>(); // [n-1..2]tap hop cac dinh da di qua khi tim duong di ngan nhat, [0] la chi phi, [1] dinh den, [n] dinh dau 
        List<string> viTri = new List<string>(); // viTri[0] la dinh bat dau
                                                 // viTri[1] la dinh ket thuc
        List<string> Open = new List<string>();
        List<string> Close = new List<string>();
        int[] g = new int[100];
        int[] prev = new int[100];
        RichTextBox lable = new RichTextBox();
        Msagl.Graph graph = new Msagl.Graph();
        public class History
        {
            public List<List<string>> hOpen;
            public List<List<string>> hClose;
            public List<List<string>> line;
            public List<List<string>> Node;
            public List<RichTextBox> Tutorial;
            public int[,] hg;
            public int[,] hprev;
            public History()
            {
                hOpen = new List<List<string>>();
                hClose = new List<List<string>>();
                line = new List<List<string>>();
                Node = new List<List<string>>();
                Tutorial = new List<RichTextBox>();
                hg = new int[100, 100];
                hprev = new int[100, 100];

            }
        };
        History history = new History();
        //----------------------------------------------------------//Doc File va Tao Graph//------------------------------------------------------------------------------------------------------------
        private void btn_ReadFile_Click(object sender, EventArgs e) 
        {
            Reset();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                string[] line = File.ReadAllLines(path);
                coutNode = int.Parse(line[0].Trim());
                for (int i = 0; i < coutNode; i++)
                {
                    string[] weight = line[i + 1].Split(' ');
                    for (int j = 0; j < coutNode; j++)
                    {
                        if (weight[j] == "∞") Weight[i, j] = int.MinValue;
                        else
                        {
                            if (int.Parse(weight[j]) == 0) nghivan = true;
                            if (int.Parse(weight[j]) < 0) am = true;
                            Weight[i, j] = int.Parse(weight[j]);
                        }

                    }
                }
                for (int j = 0; j < coutNode; j++)
                {
                    try
                    {
                        Node[j] = line[coutNode + 1 + j].Trim();
                    }
                    catch
                    {
                        Node[j] = $"N{j}";
                    }
                }
            }
            graph = new Msagl.Graph();
            XetDoThiHopLe xet = new XetDoThiHopLe();
            XetDoThiHopLe.DoThi doThi = new XetDoThiHopLe.DoThi();
            doThi.iSodinh = coutNode;
            doThi.iMaTran = Weight;
            if (nghivan)
            {
                System.Media.SystemSounds.Exclamation.Play();
                NghiVan nghiVan = new NghiVan();
                nghiVan.ShowDialog();
                if (!nghiVan.ok)
                {
                    for (int i = 0; i < coutNode; i++)
                    {
                        Weight[i, i] = int.MinValue;
                    }
                    nghivan = false;
                }
                else
                {
                    for (int i = 0; i < coutNode; i++)
                    {
                        for (int j = 0; j < coutNode; j++)
                        {
                            if (Weight[i, j] == 0) Weight[i, j] = int.MinValue;
                        }
                    }
                    nghivan = false;
                }

            }
            if (!nghivan && xet.KiemTraDonDoThiDonVoHuong(doThi))
            {
                if (path != "")
                {
                    if (am)
                    {
                        am = false;
                        MessageBox.Show("Hệ thống nhạy cảm với số âm :(", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        for (int i = 0; i < coutNode; i++)
                        {
                            graph.AddNode(Node[i]);
                        }
                        for (int i = 0; i < coutNode; i++)
                        {
                            for (int j = i + 1; j < coutNode; j++)
                            {
                                if (Weight[i, j] != int.MinValue && i != j && Weight[i, j] != 0)
                                {
                                    string id = i.ToString() + j.ToString();
                                    Msagl.Edge E = graph.AddEdge(Node[i], Node[j]);
                                    E.Attr.LineWidth = 3;
                                    E.Attr.Id = id;
                                    E.Attr.ArrowheadAtTarget = Msagl.ArrowStyle.None;
                                    E.Attr.Weight = Weight[i, j];
                                    E.LabelText = Weight[i, j].ToString();
                                   // MessageBox.Show(Node[i] + Node[j]);
                                }

                            }
                        }
                        gViewer1.Graph = graph;
                        gViewer1.SuspendLayout();
                        gViewer1.BackColor = Color.Red;

                    }
                }
            }
            else
            {
                MessageBox.Show("Chỉ đọc được đồ thị đơn vô hướng thôi !!! ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //--------------------------------------------------//Ham bo tro//----------------------------------------------------------------------------------------------------------------
        int NodeToIndex(string node) // tim index cua dinh thong qua ten dinh
        {
           // int index;
            for (int i = 0; i < coutNode; i++)
            {
                if(node == Node[i])
                {
                    return i;
                }
            }
            return -1;
        }
        string ToId (int i,int j) {
            if (j  > i) {
                return i.ToString() + j.ToString();
            }
            return j.ToString() + i.ToString();
        }
        string ToNode(int i, int j)
        {
            if (j > i)
            {
                return Node[i] + Node[j];
            }
            return Node[j] + Node[i];
        }
        void VeDuongDiDijsktra()
        {
            for(int i = dinhDuongDi.Count-1; i > 0; i--)
            {
                graph.FindNode(Node[dinhDuongDi[i] - 1]).Attr.FillColor = Msagl.Color.GreenYellow;
                if(i > 1)
                {
                    graph.EdgeById(ToId(dinhDuongDi[i-1] - 1,dinhDuongDi[i] - 1)).Attr.Color = Msagl.Color.GreenYellow;
                }
            }
        }
        void VeDuongDiKruskal()
        {
            for(int i = 1;i < dinhDuongDi.Count - 1; i += 2)
            {
                graph.FindNode(Node[dinhDuongDi[i]]).Attr.FillColor = Msagl.Color.GreenYellow;
                graph.FindNode(Node[dinhDuongDi[i + 1]]).Attr.FillColor = Msagl.Color.GreenYellow;
                graph.EdgeById(ToId(dinhDuongDi[i], dinhDuongDi[i + 1])).Attr.Color = Msagl.Color.GreenYellow;
            }
        }
        List<Tuple<string,string>> SortEdge(List<Tuple<string,string>> nameEdge,List<int> valueEdge)
        {
            for(int i = 0; i< valueEdge.Count - 1; i++)
            {
                for(int j = i + 1; j < valueEdge.Count; j++)
                {
                    if(valueEdge[i] > valueEdge[j])
                    {
                        int hv = valueEdge[i];
                        Tuple<string,string> hn = nameEdge[i];
                        valueEdge[i] = valueEdge[j];
                        nameEdge[i] = nameEdge[j];
                        valueEdge[j] = hv;
                        nameEdge[j] = hn;
                    }
                }
            }
            return nameEdge;
        }
        void cls()
        {
            foreach (Msagl.Node node in gViewer1.Graph.Nodes)
            {
                node.Attr.FillColor = Msagl.Color.White;
            }
            foreach (Msagl.Edge edge in gViewer1.Graph.Edges)
            {
                edge.Attr.Color = Msagl.Color.Black;
                edge.Label.FontColor = Msagl.Color.Black;
            }
            gViewer1.Refresh();
            la_Chiphi.Text = "Distance :";
        }
        void Reset()
        {
            dinhDuongDi.Clear();
            Open.Clear();
            Close.Clear();
            for(int i = 0; i< 100; i++)
            {
                g[i] = 0;
                prev[i] = -1;
            }
            viTri.Clear();
            step = 0;
            btn_Previous.Enabled = false;
            btn_Next.Enabled = true;
            history = new History();
            count = true;
            textOpen.Text = textClose.Text = textG.Text = textPrev.Text = "";
            g_HuongDan.Controls.Clear();
            la_Chiphi.Text = "Distance :";
        }
        //======================================================//DIJKSTRA//=============================================================================================
        RichTextBox tutorial = new RichTextBox();
        void HuongdanDijkstra()
        {
            tutorial =  new RichTextBox();
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.Brown;
            tutorial.SelectedText = "Khởi tạo:\n\n";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = "Cho đỉnh bắt đầu vào tập Open\n\n";
            int chosen = NodeToIndex(viTri[0]);
            int step = 0;
            Open.Add(viTri[0]);
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = $"Open[";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.Red;
            tutorial.SelectedText = $"{string.Join(" ", Open)}";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = $"]\n\n";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = $"Close[{string.Join(" ", Close)}]\n\n";
            history.Tutorial.Add(tutorial);
            history.hOpen.Add(new List<string>(Open));
            history.hClose.Add(new List<string>());
            for (int i = 0; i < coutNode; i++)
            {
                history.hg[step, i] = 0;
                history.hprev[step, i] = -1;
            }
            history.line.Add(new List<string>());
            history.Node.Add(new List<string>());
            while (chosen != NodeToIndex(viTri[1]))
            {
                step++;
                tutorial = new RichTextBox();
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.Brown;
                tutorial.SelectedText = $"Bước {step}:\n\n";
                List<string> line = new List<string>();
                List<string> node = new List<string>();
                int min = int.MaxValue;
                int indexChosen = 0;
                for (int i = 0; i < Open.Count; i++)
                {
                    if (g[NodeToIndex(Open[i])] < min)
                    {
                        min = g[NodeToIndex(Open[i])];
                        chosen =NodeToIndex(Open[i]);
                        indexChosen = i;
                    }
                }
                node.Add(Node[chosen]);
                history.Node.Add(new List<string>(node));
                history.hOpen.Add(new List<string>(Open));
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.OrangeRed;
                tutorial.SelectedText = $"* Chọn đỉnh {Node[chosen]}\n(Do trong tập Open thì g[{chosen}] là nhỏ nhất)\n* Mở các đỉnh kề với {Node[chosen]} mà không nằm trong tập Close\n\n";
                if (prev[chosen] != -1)
                {
                    tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                    tutorial.SelectionColor = Color.Green;
                    tutorial.SelectedText = $"Nối đỉnh {Node[prev[chosen]]} và đỉnh {Node[chosen]}\n\n";
                }
                Close.Add(Node[chosen]);
                Open.RemoveAt(indexChosen);
                for (int i = 0; i < coutNode; i++)
                {
                    if (Weight[chosen, i] >= 0 && !Close.Contains(Node[i]))
                    {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.OrangeRed;
                        tutorial.SelectedText = $"# Mở đỉnh {Node[i]}: \ng[{i}] = g[{chosen}] + w({Node[chosen]},{Node[i]}) = {g[chosen]} + {Weight[chosen, i]} = {g[chosen] + Weight[chosen, i]} \n";
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Purple;
                        tutorial.SelectedText = $"prev[{i}] = {chosen}\n\n";
                        line.Add(ToId(chosen, i));

                        if (g[i] > g[chosen] + Weight[chosen, i] || g[i] == 0)
                        {
                            g[i] = g[chosen] + Weight[chosen, i];
                            prev[i] = chosen;
                        }
                        else
                        {
                            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                            tutorial.SelectionColor = Color.OrangeRed;
                            tutorial.SelectedText = $"# Mở đỉnh {Node[i]} nhưng không cập nhật g[{i}]\n(vì g[{i}] = {g[i]} < g[{chosen}] + w({Node[chosen]},{Node[i]}) = {g[chosen] + Weight[chosen, i]} )\n\n";
                        }
                        if (!Open.Contains(Node[i]))
                        {
                            Open.Add(Node[i]);
                            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                            tutorial.SelectionColor = Color.DarkGoldenrod;
                            tutorial.SelectedText = $"# Thêm đỉnh {Node[i]} vào tập Open\n\n";
                        }
                        else
                        {
                            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                            tutorial.SelectionColor = Color.DarkGoldenrod;
                            tutorial.SelectedText = $"# Không thêm đỉnh {Node[i]}\nvào tập Open vì tập Open có đỉnh này rồi\n\n";
                        }
                    }
                    else if(Weight[chosen, i] >= 0 && Close.Contains(Node[i]))
                    {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.DarkSlateGray;
                        tutorial.SelectedText = $"# Không chọn đỉnh {Node[i]}\nvì đỉnh này đã nằm trong tập Close\n\n";
                    }
                }
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.DarkSlateGray;
                tutorial.SelectedText = $"Thêm đỉnh {Node[chosen]} vào Close\n\n";  
                history.Tutorial.Add(tutorial);
                history.line.Add(new List<string>(line));
                history.hClose.Add(new List<string>(Close));
                for (int i = 0; i < coutNode; i++)
                {
                    history.hg[step, i] = g[i];
                    history.hprev[step, i] = prev[i];
                }
            }
            
        }
        //======================================================//KRUSKAL//============================================================================================
        void HuongdanKruskal()
        {
            int step = 0;
            List<Tuple<string, string>> sortLineName = new List<Tuple<string, string>>(); ;
            List<int> sortLine = new List<int>();
            tutorial = new RichTextBox();
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.Brown;
            tutorial.SelectedText = "Khởi tạo :\n\n";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = "Sắp xếp các cạnh theo trọng số\ntừ nhỏ đến lớn và đưa vào tập Open\n\nClose = {}\n\n g = 0\n\n";
            for(int i = 0; i < coutNode -1 ; i++)
            {
                for(int j = i+1; j < coutNode; j++)
                {
                    if (Weight[i, j] > 0)
                    {
                        sortLine.Add(Weight[i, j]);
                        sortLineName.Add(new Tuple<string, string>(Node[i],Node[j]));
                    }
                }
            }
            sortLineName = SortEdge(sortLineName,sortLine); // sắp xếp Edge từ nhỏ -> lớn (trọng số)
            sortLineName.ForEach(delegate (Tuple<string,string> tuple)
            {
                Open.Add(tuple.Item1+tuple.Item2);
            });
            history.Tutorial.Add(tutorial);
            history.hOpen.Add(new List<string>(Open));
            history.hClose.Add(new List<string>());
            history.Node.Add(new List<string>());
            history.line.Add(new List<string>());
            List<string> checkEgde = new List<string>();
            for (int i = 1; i < dinhDuongDi.Count - 1; i += 2)
            {
                checkEgde.Add(dinhDuongDi[i].ToString() + (dinhDuongDi[i + 1]).ToString());
            }
            //MessageBox.Show(string.Join(" ", sortLineName));
            int g = 0;
            history.hg[step, 0] = g;
            while (Open.Count > 0)
            {
                Tuple<string, string> chosen = sortLineName[0];
                List<string> line = new List<string>();
                List<string> node = new List<string>();
                step++;
                tutorial = new RichTextBox();
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.Brown;
                tutorial.SelectedText = $"Bước {step}:\n\n";
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.OrangeRed;
                tutorial.SelectedText = $"-Chọn cạnh {Open[0]}\n\n";
                if (Close.Contains(chosen.Item1)&&Close.Contains(chosen.Item2))
                {
                   if (!checkEgde.Contains(ToId(NodeToIndex(chosen.Item1),NodeToIndex(chosen.Item2)))){
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.DimGray;
                        tutorial.SelectedText = $"# Không nhận cạnh {Open[0]}\n(vì đỉnh cả hai đỉnh {chosen.Item1}, {chosen.Item2} đã nằm trong tập Close)\n\n";
                        history.hprev[NodeToIndex(chosen.Item1), NodeToIndex(chosen.Item2)] = 0;
                   }
                   else
                   {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.LimeGreen;
                        tutorial.SelectedText = $"# Nhận cạnh {Open[0]}\n (vì đồ thị sẽ không liên thông\nmặc dù hai đỉnh {chosen.Item1}, {chosen.Item2} đã nằm trong tập Close)\n\n";
                        history.hprev[NodeToIndex(chosen.Item1), NodeToIndex(chosen.Item2)] = 2;
                        history.hg[step, 0] = g + Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)];
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Purple;
                        tutorial.SelectedText = $"  g = g + w({Open[0]}) = {g} + {Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)]} = {g + Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)]}\n\n";
                        g = g + Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)];
                    }
                    node.Add(chosen.Item1);
                    node.Add(chosen.Item2);
                    line.Add(NodeToIndex(chosen.Item1).ToString() + NodeToIndex(chosen.Item2).ToString());
                    history.line.Add(new List<string>(line));
                }
                else
                {
                    tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                    tutorial.SelectionColor = Color.ForestGreen;
                    tutorial.SelectedText = $"# Nhận cạnh {Open[0]}\n\n";
                    // MessageBox.Show(sortLineName.Count.ToString()+" "+(step - 1).ToString());
                    history.hg[step, 0] = g + Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)];
                    tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                    tutorial.SelectionColor = Color.Purple;
                    tutorial.SelectedText = $"  g = g + w({Open[0]}) = {g} + {Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)]} = {g + Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)]}\n\n";
                    g = g + Weight[NodeToIndex(sortLineName[0].Item1), NodeToIndex(sortLineName[0].Item2)];
                    history.hprev[NodeToIndex(chosen.Item1), NodeToIndex(chosen.Item2)] = 1;
                    node.Add(chosen.Item1);
                    node.Add(chosen.Item2);
                    line.Add(NodeToIndex(chosen.Item1).ToString()+NodeToIndex(chosen.Item2).ToString());
                    history.line.Add(new List<string>(line));
                    if (!Close.Contains(chosen.Item1)) {
                        Close.Add(chosen.Item1);
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Green;
                        tutorial.SelectedText = $"Thêm {chosen.Item1} vào tập Close\n\n";
                    }
                    else
                    {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Green;
                        tutorial.SelectedText = $"Không thêm {chosen.Item1} vào tập Close\nvì {chosen.Item1} đã tồn tại trông Close\n\n";
                    }
                    if (!Close.Contains(chosen.Item2))
                    {
                        Close.Add(chosen.Item2);
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Green;
                        tutorial.SelectedText = $"Thêm {chosen.Item2} vào tập Close\n\n";
                    }
                    else
                    {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Green;
                        tutorial.SelectedText = $"Không thêm {chosen.Item2} vào tập Close\nvì {chosen.Item2} đã tồn tại trông Close\n\n";
                    }
                }
                sortLineName.RemoveAt(0);
                history.hOpen.Add(new List<string>(Open));
                Open.RemoveAt(0);
                history.hClose.Add(new List<string>(Close));
                history.Tutorial.Add(tutorial);
                history.Node.Add(new List<string>(node));
            }
        }
        //======================================================//PRIM//============================================================================================
        void HuongDaPrim(int start)
        {
            List<string> bug = new List<string>();
            List<Tuple<int,int, int>> egde = new List<Tuple<int,int, int>>();
            tutorial = new RichTextBox();
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.Brown;
            tutorial.SelectedText = "Khởi tạo:\n\n ";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = "Open[]\nClose[";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.Red;
            tutorial.SelectedText = $"{Node[start]}";
            tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
            tutorial.SelectionColor = Color.DarkCyan;
            tutorial.SelectedText = "]\n g = 0\n\n";
            int step = 0;
            int g = 0;
            history.hg[step, 1] = 0;
            Close.Add(Node[start]);
            history.hOpen.Add(new List<string>());
            history.hClose.Add(new List<string>(Close));
            history.line.Add(new List<string>());
            history.Node.Add(new List<string>());
            history.Tutorial.Add(tutorial);
            while (coutNode !=history.hClose.Count-2)
            {
                step++;
                List<string> line = new List<string>();
                List<string> lineNode = new List<string>();
                int indexChosen = NodeToIndex(Close[Close.Count-1]);
                tutorial = new RichTextBox();
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.Brown;
                tutorial.SelectedText = $"Bước {step}:\n\n";
                tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                tutorial.SelectionColor = Color.OrangeRed;
                tutorial.SelectedText = $"Chọn đỉnh {Node[indexChosen]}\n\n";
                history.Node.Add(new List<string>(Close));
                for (int i = 0; i < coutNode; i++)
                {
                    if (Weight[indexChosen, i] >= 0 && !bug.Contains(ToId(i, indexChosen)) && !Open.Contains(ToNode(i, indexChosen)))
                    {
                        Open.Add(ToNode(indexChosen, i));
                        egde.Add(new Tuple<int,int, int>(indexChosen,i,Weight[indexChosen,i]));
                        line.Add(ToId(indexChosen, i));
                        lineNode.Add(Node[indexChosen] + Node[i]);
                    }
                }
                if (lineNode.Count > 0)
                {
                    tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                    tutorial.SelectionColor = Color.OrangeRed;
                    tutorial.SelectedText = $"Mở các cạnh {string.Join(" , ", lineNode)}\n\n";
                }
                history.hOpen.Add(new List<string>(Open));
                history.line.Add(line);
                egde.Sort((a, b) => a.Item3.CompareTo(b.Item3));
               // MessageBox.Show(string.Join(" ", egde));
                for (int i = 0; i < egde.Count; i++)
                {
                    if (!Close.Contains(Node[egde[i].Item2]))
                    {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Green;
                        tutorial.SelectedText = $"Chọn cạnh {Node[egde[i].Item1]+Node[egde[i].Item2]}\nVì cạnh này nhỏ nhất trong các cạnh\n({string.Join(" , ", Open)})\ntrong tập Open\n\n";
                        history.hg[step, 1] = g + Weight[egde[i].Item1, egde[i].Item2];
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.Purple;
                        tutorial.SelectedText = $"g = g + w({Node[egde[i].Item1] + Node[egde[i].Item2]}) = {g} + {Weight[egde[i].Item1, egde[i].Item2]} = {g + Weight[egde[i].Item1, egde[i].Item2]}\n\n";
                        g = history.hg[step, 1];
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.OrangeRed;
                        tutorial.SelectedText = $"Đưa đỉnh {Node[egde[i].Item2]} vào tập Close\n\n";
                        history.hprev[step, 0] = egde[i].Item1;
                        history.hg[step, 0] = egde[i].Item2;
                        Close.Add(Node[egde[i].Item2]);
                        bug.Add(ToId(egde[i].Item1, egde[i].Item2));
                        Open.RemoveAt(Open.IndexOf(ToNode(egde[i].Item1, egde[i].Item2)));
                        egde.RemoveAt(egde.IndexOf(egde[i]));
                        break;
                    }
                    else
                    {
                        tutorial.SelectionFont = new Font("Consolas", 15, FontStyle.Bold);
                        tutorial.SelectionColor = Color.DimGray;
                        tutorial.SelectedText = $"Không chọn cạnh {Node[egde[i].Item1] + Node[egde[i].Item2]}\nVì đỉnh {Node[egde[i].Item2]} đã trong tập Close\nBỏ cạnh {Node[egde[i].Item1] + Node[egde[i].Item2]} khỏi tập Open\n";
                        Open.RemoveAt(Open.IndexOf(ToNode(egde[i].Item1, egde[i].Item2)));
                        egde.RemoveAt(egde.IndexOf(egde[i]));
                    }
                }
                history.Tutorial.Add(tutorial);
                history.hClose.Add(new List<string>(Close));
            }
/*            string mess = "";
            for (int i = 0; i < step; i++)
            {
                mess += string.Join(" ", history.Node[i]) + "\n\n";
                mess += string.Join(" ", history.line[i]) + "\n\n";
                mess += string.Join(" ", history.hOpen[i]) + "\n\n";
                mess += string.Join(" ", history.hClose[i]) + "\n\n";
                MessageBox.Show(mess);
                mess = "";
            }*/
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form2_Load_1(object sender, EventArgs e)
        {
            rd_Dijkstra.Checked = true;
        }
        //--------------------------------------------------------------//Source//--------------------------------------------------------------------------------
        void SourceDijsktra()
        {
           // rTB_Source = new RichTextBox();
            rTB_Source.Text = "";
            rTB_Source.SelectedText = "Mỗi đỉnh ứng 1 số g(N)\n\nChi phí từ đỉnh S ban đầu tới N\n\nClose : Tập đỉnh đóng\n\nOpen: Tập đỉnh mở\n\n";
            rTB_Source.SelectionColor = Color.Brown;
            rTB_Source.SelectedText = "Bước khởi tạo\n";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "Open = {";
            rTB_Source.SelectionColor = Color.Red;
            rTB_Source.SelectedText = "S";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "}\nClose = {}\n\n";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "g[] = {0}\nprev[] = {-1}\n\n";
            rTB_Source.SelectionColor = Color.Brown;
            rTB_Source.SelectedText = "Bước thực thi: \n\n";
            rTB_Source.SelectionColor = Color.Red;
            rTB_Source.SelectedText = "While";
            rTB_Source.SelectionColor = Color.Black;
            rTB_Source.SelectedText = "(";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "Open != {}";
            rTB_Source.SelectionColor = Color.Black;
            rTB_Source.SelectedText = ")\n";
            rTB_Source.SelectionColor = Color.OrangeRed;
            rTB_Source.SelectedText = " __Chọn N thuộc Open có g(N) nhỏ nhất\n";
            rTB_Source.SelectionColor = Color.Green;
            rTB_Source.SelectedText = "     __Nối với đỉnh chọn trước đó (nếu có)\n";
            rTB_Source.SelectionColor = Color.OrangeRed;
            rTB_Source.SelectedText = " __Mở các đỉnh Q sau đỉnh N\n";
            rTB_Source.SelectionColor = Color.OrangeRed;
            rTB_Source.SelectedText = "    __Nếu g(Q) > g(N) + w(N,Q)\n    __g(Q) = g(N) + w(N,Q)\n";
            rTB_Source.SelectionColor = Color.Purple;
            rTB_Source.SelectedText = "    __prev(Q) = N\n";
            rTB_Source.SelectionColor = Color.DarkGoldenrod;
            rTB_Source.SelectedText = "    __Nếu tập Open chưa có đỉnh Q, thêm Q vào Open\n";
            rTB_Source.SelectionColor = Color.DarkSlateGray;
            rTB_Source.SelectedText = "    __Thêm N vào Close, nếu N là đỉnh đến thì dừng thuật toán";
        }
        void SourceKruskal()
        {
            // rTB_Source = new RichTextBox();
            rTB_Source.Text = "";
            rTB_Source.SelectedText = "Từ một đỉnh bất kì đến tất cả các đỉnh sao cho chi phí là nhỏ nhất\n\n";
            rTB_Source.SelectionColor = Color.Brown;
            rTB_Source.SelectedText = "Bước khởi tạo\n";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "Sắp xếp các cạnh theo thứ tự tăng dần theo trọng số đưa vào tập Open\nClose = {}\n g = 0\n\n";
            rTB_Source.SelectionColor = Color.Brown;
            rTB_Source.SelectedText = "Bước thực thi: \n\n";
            rTB_Source.SelectionColor = Color.Red;
            rTB_Source.SelectedText = "While";
            rTB_Source.SelectionColor = Color.Black;
            rTB_Source.SelectedText = "(";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "Open != {}";
            rTB_Source.SelectionColor = Color.Black;
            rTB_Source.SelectedText = ")\n";
            rTB_Source.SelectionColor = Color.OrangeRed;
            rTB_Source.SelectedText = " __Chọn cạnh N\n";
            rTB_Source.SelectionColor = Color.ForestGreen;
            rTB_Source.SelectedText = "     __Nhận N, nếu cả hai đỉnh của N không nằm trong tập Close()\n";
            rTB_Source.SelectionColor = Color.Purple;
            rTB_Source.SelectedText = "           g = g + w(N)\n\n";
            rTB_Source.SelectionColor = Color.LimeGreen;
            rTB_Source.SelectedText = "     __Nhận N, vì đồ thị sẽ không liên thông nếu không nhận N\n";
            rTB_Source.SelectionColor = Color.Purple;
            rTB_Source.SelectedText = "           g = g + w(N)\n\n";
            rTB_Source.SelectionColor = Color.DimGray;
            rTB_Source.SelectedText = "     __Không nhận N, vì cả hai đỉnh của N đều nằm trong tập Close và đồ thị vẫn liên thông nếu không nhận cạnh N\n";
            rTB_Source.SelectionColor = Color.Green;
            rTB_Source.SelectedText = "    __Thêm 2 đỉnh của N vào Close";
        }
        void SourcePrim()
        {
            // rTB_Source = new RichTextBox();
            rTB_Source.Text = "";
            rTB_Source.SelectedText = "Từ một đỉnh S cho trước đến tất cả các đỉnh sao cho chi phí là nhỏ nhất\n\n";
            rTB_Source.SelectionColor = Color.Brown;
            rTB_Source.SelectedText = "Bước khởi tạo\n";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "Open = {}\nClose = {";
            rTB_Source.SelectionColor = Color.Red;
            rTB_Source.SelectedText = "S";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "}\n";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "g = {0}\n\n";
            rTB_Source.SelectionColor = Color.Brown;
            rTB_Source.SelectedText = "Bước thực thi: \n\n";
            rTB_Source.SelectionColor = Color.Red;
            rTB_Source.SelectedText = "While";
            rTB_Source.SelectionColor = Color.Black;
            rTB_Source.SelectedText = "(";
            rTB_Source.SelectionColor = Color.DarkCyan;
            rTB_Source.SelectedText = "Tổng số đỉnh trong tập Close != Tổng số đỉnh trên đồ thị";
            rTB_Source.SelectionColor = Color.Black;
            rTB_Source.SelectedText = ")\n\n";
            rTB_Source.SelectionColor = Color.OrangeRed;
            rTB_Source.SelectedText = "   B1_Chọn N (đỉnh cuối dùng trong tập Close)\n\n   B2_Mở các cạnh kề với N mà không có trong tập Open, rồi thêm những cạnh này vào tập Open\n\n";
            rTB_Source.SelectionColor = Color.Green;
            rTB_Source.SelectedText = "   B3_Xét trong tập Open, chọn cạnh nhỏ nhất là NQ\n\n";
            rTB_Source.SelectionColor = Color.DimGray;
            rTB_Source.SelectedText = "   B4_Nếu NQ là cạnh nhỏ nhất trong Open, mà Q đã tồn tại trong Close, xóa NQ ra khỏi Open, quay lại B3\n\n";
            rTB_Source.SelectionColor = Color.Purple;
            rTB_Source.SelectedText = "   B5_g = g + w(N,Q)\n\n";
            rTB_Source.SelectionColor = Color.OrangeRed;
            rTB_Source.SelectedText = "   B6_Thêm Q vào Close, nếu Q chưa tồn tại trong Close";
        }
        //-----------------------------------------------------//Thuc thi thuat toan//-----------------------------------------------------------------------------------------------------------------
        bool count = true;
        private void btn_Run_Click(object sender, EventArgs e) 
        {
            if (gViewer1.Graph != null)
            {
                cls();
            }
            if(dinhDuongDi.Count > 0)
            {
                Reset();
            }
            XetLienThong xetLienThong = new XetLienThong();
            XetLienThong.DoThi doThi = new XetLienThong.DoThi();
            doThi.iMaTran = Weight;
            doThi.iSoDinh = coutNode;
            if (!xetLienThong.xetLienThong(doThi)) MessageBox.Show("Đồ thị không hợp lệ (không liên thông) !!!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (rd_Dijkstra.Checked)
                {

                    Dijkstra.DuLieu data = new Dijkstra.DuLieu();
                    Dijkstra kieuDuongDi = new Dijkstra();
                    try
                    {
                        data.di = NodeToIndex(viTri[0]) + 1;
                        data.den = NodeToIndex(viTri[1]) + 1;
                        data.sodinh = coutNode;
                        data.mt = Weight;
                        HuongdanDijkstra();
                        SourceDijsktra();
                        count = false;
                    }
                    catch
                    {
                        if (count) MessageBox.Show("Vui lòng chọn đỉnh bắt đầu và đỉnh kết thúc", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Đã thực thi, có thể nhấn \"Next\" để tiếp tục", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dinhDuongDi = kieuDuongDi.TimDuong(data); // [n-1..2]tap hop cac dinh da di qua khi tim duong di ngan nhat, [0] la chi phi, [1] dinh den, [n] dinh dau 
                    VeDuongDiDijsktra();
                    //MessageBox.Show(string.Join(" ", dinhDuongDi));
                }
                else if (rd_Kruskal.Checked)
                {
                    Kruskal kruskal = new Kruskal();
                    DuLieu duLieu = new DuLieu();
                    try
                    {
                        duLieu.mt = Weight;
                        duLieu.sodinh = coutNode;
                        kruskal.Change(duLieu);
                        count = false;
                    }
                    catch
                    {
                        if (!count) MessageBox.Show("Đã thực thi, có thể nhấn \"Next\" để tiếp tục", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dinhDuongDi = kruskal.TimDuong();
                    VeDuongDiKruskal();
                    SourceKruskal();
                    HuongdanKruskal();
                }
                else
                {
                    int start = 0;
                    Prim prim = new Prim();
                    DuLieu duLieu = new DuLieu();
                    try
                    {
                        start = NodeToIndex(viTri[0]);
                        viTri.Clear();
                        duLieu.mt = Weight;
                        duLieu.sodinh = coutNode;
                        dinhDuongDi = prim.TimDuong(duLieu, start);
                        VeDuongDiKruskal();
                        HuongDaPrim(start);
                        SourcePrim();
                        count = false;
                    }
                    catch
                    {
                        if (count) MessageBox.Show("Vui lòng chọn đỉnh bắt đầu ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Đã thực thi, có thể nhấn \"Next\" để tiếp tục", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (history.Tutorial.Count > 1)
                {
                    // string tmp = history.Tutorial[history.Tutorial.Count - 1];
                    // history.Tutorial.RemoveAt(history.Tutorial.Count - 1);
                    //  tmp += "===================/Kết thúc thuật toán/=====================";
                    //  history.Tutorial.Add(tmp);
                }
                gViewer1.Refresh();
                if (dinhDuongDi.Count > 0) la_Chiphi.Text = $"Distance : {dinhDuongDi[0]}";
                //Reset();
            }
        }
        int step = 0;
        //------------------------------------------------------------//Nut Next//----------------------------------------------------------------------------------------------------------
        private void btn_Next_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(step.ToString());
            if (dinhDuongDi.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn \"Thực thi\"", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (step == history.Node.Count - 1)
                {
                    btn_Next.Enabled = false;
                    la_Chiphi.Text = $"Distance : {dinhDuongDi[0]}";
                }
                string tg = "";
                string tprev = "";
                lable = history.Tutorial[step];
                
                lable.Width = 370;
                lable.Height = 370;
                lable.ReadOnly = true;
                lable.Location= new Point(0,0);
                lable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(247)))));
                g_HuongDan.Controls.Clear();
                g_HuongDan.Controls.Add(lable);
                if(step > 0) btn_Previous.Enabled = true;
                if (step == 0) cls();
                if (rd_Dijkstra.Checked)
                {
                    if (step == history.Node.Count - 1)
                    {
                        int star = history.hprev[step, NodeToIndex(viTri[1])];
                        while(star != -1)
                        {
                            graph.FindNode(Node[star]).Attr.FillColor = Msagl.Color.Green;
                            star = history.hprev[step, star];
                        }
                        graph.FindNode(viTri[1]).Attr.FillColor = Msagl.Color.Green;
                    }
                    if (step != 0)
                    {
                        if (step < history.Node.Count - 1) graph.FindNode(history.Node[step][0]).Attr.FillColor = Msagl.Color.OrangeRed;
                        history.line[step].ForEach(delegate (String name)
                        {
                            graph.EdgeById(name).Attr.Color = Msagl.Color.OrangeRed;
                        });
                        if (history.hprev[step, NodeToIndex(history.Node[step][0])] != -1)
                        {
                            graph.EdgeById(ToId(NodeToIndex(history.Node[step][0]), history.hprev[step, NodeToIndex(history.Node[step][0])])).Attr.Color = Msagl.Color.Green;
                        }
                    }
                    for (int j = 0; j < coutNode; j++)
                    {
                        tg += history.hg[step, j] + " ";
                        tprev += history.hprev[step, j] + " ";
                    }
                    textG.Text = tg;
                    textPrev.Text = tprev;
                }
                else if(rd_Kruskal.Checked)
                {
                    if (step == 0) textG.Text = history.hg[step, 0].ToString();
                    if (step > 0)
                    {
                        //MessageBox.Show($"{NodeToIndex(history.Node[step][0])}, {NodeToIndex(history.Node[step][1])} || {history.Node[step][0]},{history.Node[step][1]}");
                        if (history.hprev[NodeToIndex(history.Node[step][0]), NodeToIndex(history.Node[step][1])] == 1)
                        {
                            graph.FindNode(history.Node[step][0]).Attr.FillColor = Msagl.Color.Green;
                            graph.FindNode(history.Node[step][1]).Attr.FillColor = Msagl.Color.Green;
                            graph.EdgeById(history.line[step][0]).Attr.Color = Msagl.Color.ForestGreen;
                            textG.Text = history.hg[step, 0].ToString();
                        }
                        else if(history.hprev[NodeToIndex(history.Node[step][0]), NodeToIndex(history.Node[step][1])] == 2)
                        {
                            graph.EdgeById(history.line[step][0]).Attr.Color = Msagl.Color.LimeGreen;
                            graph.EdgeById(history.line[step][0]).Label.FontColor = Msagl.Color.LimeGreen;
                            textG.Text = history.hg[step, 0].ToString();
                        }
                        else
                        {
                            graph.EdgeById(history.line[step][0]).Attr.Color = Msagl.Color.DimGray;
                            graph.EdgeById(history.line[step][0]).Label.FontColor = Msagl.Color.DimGray;
                        }
                    }
                }
                else
                {
                    if (step == 0) if(history.hg[step,1]>0)textG.Text = history.hg[step, 1].ToString();
                    if (step == history.Node.Count - 1)
                    {
                        if(history.hg[step,1]>0)textG.Text = history.hg[step, 1].ToString();
                        history.hClose[step].ForEach(delegate (string start)
                        {
                            graph.FindNode(start).Attr.FillColor = Msagl.Color.Green;
                        });
                    }
                    if (step > 0 && step != history.Node.Count - 1)
                    {
                       // MessageBox.Show(history.Node[step][step - 1]);
                        graph.FindNode(history.Node[step][history.Node[step].Count-1]).Attr.FillColor = Msagl.Color.OrangeRed;
                        if(history.hg[step,1]>0)textG.Text = history.hg[step, 1].ToString();
                        history.line[step].ForEach(delegate (String name)
                        {
                            graph.EdgeById(name).Attr.Color = Msagl.Color.OrangeRed;
                        });
                        // MessageBox.Show(ToId(history.hg[step, 0], history.hprev[step, 0]));
                        string edge = ToId(history.hg[step, 0], history.hprev[step, 0]);
                        if (edge!="00") graph.EdgeById(edge).Attr.Color = Msagl.Color.Green;
                    }
                }
                textOpen.Text = string.Join(" | ", history.hOpen[step]);
                textClose.Text= string.Join(" | ", history.hClose[step]);
                gViewer1.Refresh();
                ++ step;
            }
            
        }
        //--------------------------------------------------------------//Nut Previous//------------------------------------------------------------------------------------------------------------------
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            step--;
            la_Chiphi.Text = "Distance :";
            //MessageBox.Show(step.ToString());
            if (step - 1 <= 0)
            {
                btn_Previous.Enabled = false;
            }
            btn_Next.Enabled = true;
            if (rd_Dijkstra.Checked)
            {
                if (step == history.Node.Count - 1)
                {
                    int star = history.hprev[step, NodeToIndex(viTri[1])];
                    while (star != -1)
                    {
                        graph.FindNode(Node[star]).Attr.FillColor = Msagl.Color.OrangeRed;
                        star = history.hprev[step, star];
                    }
                    graph.FindNode(viTri[1]).Attr.FillColor = Msagl.Color.White;
                    btn_Next.Enabled = true;
                }
                if (step != 0)
                {
                    if (step < history.Node.Count - 1) graph.FindNode(history.Node[step][0]).Attr.FillColor = Msagl.Color.White;
                    history.line[step].ForEach(delegate (String name)
                    {
                        graph.EdgeById(name).Attr.Color = Msagl.Color.Black;
                    });
                    if (history.hprev[step, NodeToIndex(history.Node[step][0])] != -1)
                    {
                        graph.EdgeById(ToId(NodeToIndex(history.Node[step][0]), history.hprev[step, NodeToIndex(history.Node[step][0])])).Attr.Color = Msagl.Color.OrangeRed;
                    }
                }
                string tg = "";
                string tprev = "";
                for (int j = 0; j < coutNode; j++)
                {
                    tg += history.hg[step - 1, j] + " ";
                    tprev += history.hprev[step - 1, j] + " ";
                }
                textG.Text = tg;
                textPrev.Text = tprev;
            }
            else if (rd_Kruskal.Checked)
            {
                if(step == 0) textG.Text = history.hg[step, 0].ToString();
                if (step > 0)
                {
                    //MessageBox.Show($"{NodeToIndex(history.Node[step][0])}, {NodeToIndex(history.Node[step][1])} || {history.Node[step][0]},{history.Node[step][1]}");
                    if (history.hprev[NodeToIndex(history.Node[step][0]), NodeToIndex(history.Node[step][1])] == 1)
                    {
                        graph.FindNode(history.Node[step][0]).Attr.FillColor = Msagl.Color.White;
                        graph.FindNode(history.Node[step][1]).Attr.FillColor = Msagl.Color.White;
                        graph.EdgeById(history.line[step][0]).Attr.Color = Msagl.Color.Black;
                        textG.Text = history.hg[step-1, 0].ToString();
                    }
                    if (history.hprev[NodeToIndex(history.Node[step][0]), NodeToIndex(history.Node[step][1])] == 2)
                    {
                        graph.EdgeById(history.line[step][0]).Attr.Color = Msagl.Color.Black;
                        graph.EdgeById(history.line[step][0]).Label.FontColor = Msagl.Color.Black;
                        textG.Text = history.hg[step-1, 0].ToString();
                    }
                    else
                    {
                        graph.EdgeById(history.line[step][0]).Attr.Color = Msagl.Color.Black;
                        graph.EdgeById(history.line[step][0]).Label.FontColor = Msagl.Color.Black;
                    }
                }
            }
            else
            {
                if (step == 0) if(history.hg[step-1,1]>0)textG.Text = history.hg[step-1, 1].ToString();
                if (step == history.Node.Count - 1)
                {
                    if(history.hg[step-1,1]>0)textG.Text = history.hg[step-1, 1].ToString();
                    history.hClose[step].ForEach(delegate (string start)
                    {
                        graph.FindNode(start).Attr.FillColor = Msagl.Color.OrangeRed;
                    });
                    graph.FindNode(history.hClose[step][history.hClose[step].Count - 1]).Attr.FillColor = Msagl.Color.White;
                }
                if (step > 0 && step != history.Node.Count - 1)
                {
                    // MessageBox.Show(history.Node[step][step - 1]);
                    if(history.hg[step-1,1]>0)textG.Text = history.hg[step-1, 1].ToString();
                    graph.FindNode(history.Node[step][history.Node[step].Count - 1]).Attr.FillColor = Msagl.Color.White;
                    history.line[step].ForEach(delegate (String name)
                    {
                        graph.EdgeById(name).Attr.Color = Msagl.Color.Black;
                    });
                    // MessageBox.Show(ToId(history.hg[step, 0], history.hprev[step, 0]));
                    string edge = ToId(history.hg[step, 0], history.hprev[step, 0]);
                    if (edge != "00") graph.EdgeById(edge).Attr.Color = Msagl.Color.Black;
                }
            }
            lable = history.Tutorial[step-1];
            
            lable.ReadOnly = true;
            lable.Width = 350;
            lable.Height = 370;
            lable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(247)))));
            g_HuongDan.Controls.Clear();
            g_HuongDan.Controls.Add(lable);
            textOpen.Text = string.Join(" | ", history.hOpen[step - 1]);
            textClose.Text = string.Join(" | ", history.hClose[step - 1]);
            // btn_Next.Enabled = true;
            gViewer1.Refresh();
            
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void gViewer1_Load(object sender, EventArgs e)
        {

        }

        private void rd_Kruskal_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
            if (gViewer1.Graph != null) cls();
        }

        private void rd_Prim_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
            if (gViewer1.Graph != null) cls();
        }

        private void rd_Dijkstra_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
            if (gViewer1.Graph != null) cls();
        }


        private void btn_Tao_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            coutNode = form2.Sodinh;
            Weight = form2.mt;
            Reset();
            graph = new Msagl.Graph();
            XetDoThiHopLe xet = new XetDoThiHopLe();
            XetDoThiHopLe.DoThi doThi = new XetDoThiHopLe.DoThi();
            doThi.iSodinh = coutNode;
            doThi.iMaTran = Weight;
            Node = new string[100];
            for (int j = 0; j < coutNode; j++)
            {
                Node[j] = $"N{j}";
            }
            if (xet.KiemTraDonDoThiDonVoHuong(doThi))
            {
                for (int i = 0; i < coutNode; i++)
                {
                    graph.AddNode(Node[i]);
                }
                for (int i = 0; i < coutNode; i++)
                {
                    for (int j = i + 1; j < coutNode; j++)
                    {
                        if (Weight[i, j] != int.MinValue && i != j && Weight[i, j] != 0)
                        {
                            string id = i.ToString() + j.ToString();
                            Msagl.Edge E = graph.AddEdge(Node[i], Node[j]);
                            E.Attr.LineWidth = 3;
                            E.Attr.Id = id;
                            E.Attr.ArrowheadAtTarget = Msagl.ArrowStyle.None;
                            E.Attr.Weight = Weight[i, j];
                            E.LabelText = Weight[i, j].ToString();
                                    // MessageBox.Show(Node[i] + Node[j]);
                        }
                    }
                }
                gViewer1.Graph = graph;
                gViewer1.SuspendLayout();
                gViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("Chỉ đọc được đồ thị đơn vô hướng thôi !!! ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textOpen_TextChanged(object sender, EventArgs e)
        {

        }

        private void g_HuongDan_Enter(object sender, EventArgs e)
        {

        }

        





        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void gViewer1_Click(object sender, EventArgs e)
        {
            if((gViewer1.SelectedObject is Msagl.Node) && viTri.Count < 2)
            {
                Msagl.Node nodeSelec = gViewer1.SelectedObject as Msagl.Node;
                nodeSelec.Attr.FillColor = Msagl.Color.Red;
                viTri.Add(nodeSelec.Attr.Id);
            }
            else
            {
                Reset();
                if(gViewer1.Graph != null) cls();
                viTri.Clear();
                
            }
            gViewer1.Refresh();
        }
        
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
