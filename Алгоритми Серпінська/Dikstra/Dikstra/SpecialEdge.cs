using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikstra
{
    public class SpecialEdge
    {
        /// <summary>
        /// Связанная вершина
        /// </summary>
        public GraphVertex ConnectedVertex1 { get; }
        public GraphVertex ConnectedVertex2 { get; }

        /// <summary>
        /// Вес ребра
        /// </summary>
        public int EdgeWeight { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectedVertex">Связанная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public SpecialEdge(GraphVertex connectedVertex1, GraphVertex connectedVertex2, int weight)
        {
            ConnectedVertex1 = connectedVertex1;
            ConnectedVertex2 = connectedVertex2;
            EdgeWeight = weight;
        }
    }
}
