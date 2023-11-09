using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikstra
{
    public class Graph
    {
        public List<GraphVertex> Vertices { get; }
        public List<SpecialEdge> SEdges { get; }

        public Graph()
        {
            Vertices = new List<GraphVertex>();
            SEdges = new List<SpecialEdge>();
        }

        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }

        public GraphVertex FindVertex(string vertexName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }

            return null;
        }
        public SpecialEdge FindEdge(string vertex1, string vertex2)
        {
            foreach (var v in SEdges)
            {
                if (v.ConnectedVertex1.Name.Equals(vertex1) && v.ConnectedVertex2.Name.Equals(vertex2))
                {
                    return v;
                }
            }

            return null;
        }

        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
                SEdges.Add(new SpecialEdge(v1, v2, weight));
                SEdges.Add(new SpecialEdge(v2, v1, weight));
            }
        }
    }
}
