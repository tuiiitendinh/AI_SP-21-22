using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class PriorityQueue<Vertex>
    {
        class Node
        {
            public int Priority { get; set; }
            public Vertex Object { get; set; }
        }
        List<Node> queue = new List<Node>();
        int heapSize = -1;
        public int Count { get { return queue.Count; } }
        private void MinHeapify(int i)
        {
            int left = ChildL(i);
            int right = ChildR(i);
            int lowest = i;
            if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
            {
                lowest = left;
            }
            if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
            {
                lowest = right;
            }
            if (lowest != i)
            {
                Swap(lowest, i);
                MinHeapify(lowest);
            }
        }
        private void BuildHeapMin(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }
        public void Enqueue(int priority, Vertex obj)
        {
            Node node = new Node() { Priority = priority, Object = obj };
            queue.Add(node);
            heapSize++;
            BuildHeapMin(heapSize);
        }
        public Vertex Dequeue()
        {
            if (heapSize > -1)
            {
                Vertex returnVal = queue[0].Object;
                queue[0] = queue[heapSize];
                queue.RemoveAt(heapSize);
                heapSize--;
                MinHeapify(0);
                return returnVal;
            }
            else
            {
                throw new Exception("Queue is empty");
            }
        }
        public void UpdatePriority(Vertex obj, int priority)
        {
            for (int i = 0; i <= heapSize; i++)
            {
                Node node = queue[i];
                if (object.ReferenceEquals(node.Object, obj))
                {
                    node.Priority = priority;
                    BuildHeapMin(i);
                    MinHeapify(i);
                }
            }
        }
        private void Swap(int i, int j)
        {
            Node temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }
        private int ChildL(int i)
        {
            return i * 2 + 1;
        }
        private int ChildR(int i)
        {
            return i * 2 + 2;
        }
    }
    public class Vertex
    {
        public int Key { get; set; } = int.MaxValue;
        public int Parent { get; set; } = -1;
        public int V { get; set; }
        public bool IsProcessed { get; set; }
    }
    public class Prim
    {
        public List<int> TimDuong(DuLieu X, int pos)
        {
            List<int> Answer = new List<int>();
            PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>();
            int vertexCount = X.sodinh, sum = 0;
            Vertex[] vertices = new Vertex[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                vertices[i] = new Vertex() { Key = int.MaxValue, Parent = -1, V = i };
            }
            vertices[pos].Key = 0;
            for (int i = 0; i < vertexCount; i++)
            {
                queue.Enqueue(vertices[i].Key, vertices[i]);
            }
            while (queue.Count > 0)
            {
                Vertex minVertex = queue.Dequeue();
                int u = minVertex.V;
                vertices[u].IsProcessed = true;
                for (int i = 0; i < X.sodinh; i++)
                {
                    if (X.mt[u, i] > 0 && !vertices[i].IsProcessed && X.mt[u, i] < vertices[i].Key)
                    {
                        vertices[i].Parent = u;
                        vertices[i].Key = X.mt[u, i];
                        queue.UpdatePriority(vertices[i], vertices[i].Key);
                    }
                }
            }
            List<int> check = new List<int>();
            check.Add(pos);
            while (check.Count != 0)
            {
                int i = check[0];
                foreach (Vertex u in vertices)
                {
                    if (u.Parent == i)
                    {
                        Answer.Add(i);
                        Answer.Add(u.V);
                        check.Add(u.V);
                    }
                }
                check.RemoveAt(0);
            }
            foreach (Vertex u in vertices)
            {
                if (u.Parent >= 0)
                {
                    sum += u.Key;
                }
            }
            Answer.Insert(0, sum);
            return Answer;
        }
    }
}
