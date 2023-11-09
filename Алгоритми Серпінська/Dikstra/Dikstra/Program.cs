using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikstra
{
    class Program
    {
        public static string FindPathLength(string path, Graph g)
        {
            int length = 0;
            if (path.Length < 1)
            {
                return "0";
            }
            else
            {
                for (int i = 0; i < path.Length - 1; i++)
                {
                    length += g.FindEdge(path[i].ToString(), path[i + 1].ToString()).EdgeWeight;
                }
            }
            return length.ToString();
        }
        private static string FindBestVertex(Graph g)
        {
            var dijkstra = new Dijkstra(g);
            string bestVertex = "";
            int min = 100000;
            int globalLength = 0;
            foreach (var v in g.Vertices)
            {
                foreach (var k in g.Vertices)
                {
                    var path = dijkstra.FindShortestPath(v.Name, k.Name);
                    globalLength += Convert.ToInt32(FindPathLength(path.ToString(), g));
                }
                if (globalLength < min)
                {
                    min = globalLength;
                    bestVertex = v.Name;
                }
                Console.WriteLine(v.Name + " " + globalLength.ToString() + "\n");
                globalLength = 0;
            }
            return "\nВiдповiдь: " + bestVertex;
        }
        static void Main(string[] args)
        {
            var g = new Graph();

            //додавання вершин
            g.AddVertex("1");
            g.AddVertex("2");
            g.AddVertex("3");
            g.AddVertex("4");
            g.AddVertex("5");
            g.AddVertex("6");
            g.AddVertex("7");
            g.AddVertex("8");
            g.AddVertex("9");

            //додавання ребер
            g.AddEdge("1", "2", 7);
            g.AddEdge("1", "4", 4);
            g.AddEdge("1", "3", 10);
            g.AddEdge("2", "6", 12);
            g.AddEdge("2", "4", 5);
            g.AddEdge("3", "5", 6);
            g.AddEdge("3", "8", 5);
            g.AddEdge("4", "6", 6);
            g.AddEdge("4", "5", 3);
            g.AddEdge("4", "7", 7);
            g.AddEdge("5", "8", 8);
            g.AddEdge("6", "9", 9);
            g.AddEdge("7", "9", 8);
            g.AddEdge("7", "8", 10);
            g.AddEdge("8", "9", 11);
            
            Console.WriteLine(FindBestVertex(g));
            Console.ReadLine();
        }

    }
}
