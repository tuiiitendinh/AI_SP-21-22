using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public struct DuLieu
    {
        public int sodinh;
        public int[,] mt;
    };
    public class Edge
    {
        public int weight { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public Edge(int w, int s, int e)
        {
            this.weight = w;
            this.start = s;
            this.end = e;
        }
    }
    public class Set
    {
        int[] parent;
        int[] rank;
        public Set(int length)
        {
            parent = new int[length];
            rank = new int[length];
            for (int i = 0; i < parent.Length; i++)
                parent[i] = i;
        }

        public void MakeSet(int x)
        {
            parent[x] = x;
            rank[x] = 0;
        }

        public void Union(int x, int y)
        {
            int representativeX = FindSet(x);
            int representativeY = FindSet(y);
            if (rank[representativeX] == rank[representativeY])
            {
                rank[representativeY]++;
                parent[representativeX] = representativeY;
            }
            else if (rank[representativeX] > rank[representativeY])
            { parent[representativeY] = representativeX; }
            else
            { parent[representativeX] = representativeY; }
        }

        public int FindSet(int x)
        {
            if (parent[x] != x)
                parent[x] = FindSet(parent[x]);
            return parent[x];
        }
    }
    public class Kruskal
    {
        List<Edge> edges;
        int sodinh;
        public Kruskal()
        {
            this.edges = new List<Edge>();
            this.sodinh = 0;
        }
        public void Change(DuLieu X)
        {
            for (int i = 0; i < X.sodinh; i++)
            {
                for (int j = i; j < X.sodinh; j++)
                {
                    if (X.mt[i, j] != int.MinValue)
                    {
                        this.edges.Add(new Edge(X.mt[i, j], i, j));
                    }
                }
            }
            this.sodinh = X.sodinh;
        }
        public List<int> TimDuong()
        {
            List<int> Answer = new List<int>();
            Set set = new Set(100);
            int sum = 0;
            for (int i = 0; i < this.sodinh; i++)
            {
                set.MakeSet(i);
            }
            var sortEdge = edges.OrderBy(x => x.weight).ToList();
            foreach (Edge edge in sortEdge)
            {
                if (set.FindSet(edge.start) != set.FindSet(edge.end))
                {
                    sum += edge.weight;
                    Answer.Add(edge.start);
                    Answer.Add(edge.end);
                    set.Union(edge.start, edge.end);
                }
            }
            Answer.Insert(0, sum);
            return Answer;
        }
    }
}
