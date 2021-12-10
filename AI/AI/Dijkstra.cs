using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class Dijkstra
    {
        // Initialize value the graph
        public struct DuLieu
        {
            public int sodinh;
            public int di;
            public int den;
            public int[,] mt;
        };

        public List<int> TimDuong(DuLieu x)
        {
            int min;
            int[] nhan = new int[100];
            int[] daDuyet = new int[100];
            int[] kq = new int[100];
            int dem = 0;
            int[,] mts = new int[100, 100];
            //int[] s = new int[1000];
            List<int> list = new List<int>();
            // Copy matrix
            for (int i = 1; i <= x.sodinh; i++)
            {
                for (int j = 1; j <= x.sodinh; j++)
                {
                    mts[i, j] = x.mt[i - 1, j - 1];
                }
            }
            // Initialize
            for (int i = 1; i <= x.sodinh; i++)
            {
                nhan[i] = 0;
                kq[i] = 1000000;
                daDuyet[i] = 0;
            }
            int vet = x.di;
            nhan[vet] = 1;
            kq[vet] = 0;
            // Find shortest path for all vertices
            while (vet != x.den && dem <= x.sodinh) 
            {
                for (int i = 1; i <= x.sodinh; i++)
                {
                    if (mts[vet, i] >= 0 && kq[vet] + mts[vet, i] < kq[i] && nhan[i] == 0)
                    {
                        kq[i] = kq[vet] + mts[vet, i];
                        daDuyet[i] = vet;
                    }
                }
                min = 1000000;
                for (int j = 1; j <= x.sodinh; j++)
                {
                    if (min > kq[j] && nhan[j] == 0)
                    {
                        min = kq[j];
                        vet = j;
                    }
                }
               
                nhan[vet] = 1;
                dem++;
            }
            // Get shortest path to list
            if (dem < x.sodinh)
            {
                list.Add(kq[x.den]);
                list.Add(x.den);
                int tmp = daDuyet[x.den];

                while (tmp != x.di)
                {
                    list.Add(tmp);
                    tmp = daDuyet[tmp];
                }
                list.Add(x.di);
            }
             return list;
        }
    }
}
