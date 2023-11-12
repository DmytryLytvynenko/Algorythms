using System;

namespace DikstraAlgorithm
{
	class Dijkstra
	{
		public static int V = 9;
		int minDistance(int[] dist,
						bool[] sptSet)
		{
			int min = int.MaxValue, min_index = -1;

			for (int v = 0; v < V; v++)
				if (sptSet[v] == false && dist[v] <= min)
				{
					min = dist[v];
					min_index = v;
				}

			return min_index;
		}

		void printSolution(int[] dist, int n)
		{
			Console.Write("Vertex	 Distance "
						+ "from Source\n");
			for (int i = 0; i < V; i++)
				Console.Write(i+1 + " \t\t " + dist[i] + "\n");
		}
		void dijkstra(int[,] graph, int src)
		{
			int[] dist = new int[V]; 

			bool[] sptSet = new bool[V];

			for (int i = 0; i < V; i++)
			{
				dist[i] = int.MaxValue;
				sptSet[i] = false;
			}
			dist[src] = 0;

			for (int count = 0; count < V - 1; count++)
			{
				int u = minDistance(dist, sptSet);

				sptSet[u] = true;

				for (int v = 0; v < V; v++)
					if (!sptSet[v] && graph[u, v] != 0 &&
						dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
						dist[v] = dist[u] + graph[u, v];
			}

			printSolution(dist, V);
		}

		public static void Main()
		{
			int source = 0;
			int[,] graph = new int[,] { { 0, 1, 5, 8, 0, 0, 0, 0},
									    { 1, 0, 0, 3, 2, 0, 0, 0},
									    { 5, 0, 0, 2, 0, 4, 0, 0},
									    { 8, 3, 2, 0, 6, 7, 0, 0},
									    { 0, 2, 0, 6, 0, 1, 6, 0},
									    { 0, 0, 4, 7, 1, 0, 3, 3},
									    { 0, 0, 0, 0, 6, 3, 0, 8},
									    { 0, 0, 0, 0, 0, 3, 8, 0} };
			Dijkstra.V = 8;
			Dijkstra t = new Dijkstra();
            Console.WriteLine("Source: " + (source + 1) + " vertex");
            Console.WriteLine();
			t.dijkstra(graph, source);

			Console.ReadLine();
		}
	}
}
