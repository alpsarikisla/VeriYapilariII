using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.MinimumSpanning_Tree
{
    public class Kruskals<T,TW>
        where T : IComparable
        where TW : IComparable
    {
        public List<MSTEdge<T,TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            // 1. Kenar Listesi (dfs)
            var edges = new List<MSTEdge<T,TW>>();
            dfs(graph.ReferenceVertex,
                new HashSet<T>(),
                new Dictionary<T,HashSet<T>>(),edges);


            // 2. Kenar sıralama
            var heap = new DataStructures.Heap.BinaryHeap<MSTEdge<T,TW>>(Shared.SortDirection.Ascending);
            foreach (var edge in edges)
            {
                heap.Add(edge);
            }
            var sortedEdgeArr = new Graph.MinimumSpanning_Tree.MSTEdge<T, TW>[edges.Count];
            for (int i = 0; i < edges.Count; i++)
            {
                sortedEdgeArr[i] = heap.DeleteMinMax();
            }

            // 3. MakeSet - FindSet - Union
            var disjointSet = new Set.DisjointSet<T>();
            foreach (var vertex in graph.VerticesAsEnumberable)
            {
                disjointSet.MakeSet(vertex.Key);
            }
            var resultEdgeList = new List<MSTEdge<T,TW>>();
            for (int i = 0; i < edges.Count; i++)
            {
                var currentEdge = sortedEdgeArr[i];
                var setA = disjointSet.FindSet(currentEdge.Source);
                var setB = disjointSet.FindSet(currentEdge.Destination);

                if (setA.Equals(setB))
                {
                    continue;
                }
                resultEdgeList.Add(currentEdge);
                disjointSet.Union(setA, setB);
            }

            return resultEdgeList;


            
        }

        private void dfs(IGraphVertex<T> currentVertex, HashSet<T> visitedVertices, Dictionary<T, HashSet<T>> visitedEdges, List<MSTEdge<T, TW>> edges)
        {
            if (!visitedVertices.Contains(currentVertex.Key))
            {
                visitedVertices.Add(currentVertex.Key);
                foreach (var edge in currentVertex.Edges)
                {
                    if (!visitedEdges.ContainsKey(currentVertex.Key) || !visitedEdges[currentVertex.Key].Contains(edge.TargetVertexKey))
                    {
                        // Kenar ekleme
                        edges.Add(new MSTEdge<T, TW>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<TW>()));

                        // Kenar Güncelleme (visitedEdges)
                        if (!visitedEdges.ContainsKey(currentVertex.Key))
                        {
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());
                        }
                        visitedEdges[currentVertex.Key].Add(edge.TargetVertexKey);

                        // Kenar Güncelleme (visitedEdges) - destination
                        if (!visitedEdges.ContainsKey(edge.TargetVertexKey))
                        {
                            visitedEdges.Add(edge.TargetVertexKey, new HashSet<T>());
                        }
                        visitedEdges[edge.TargetVertexKey].Add(currentVertex.Key);

                        dfs(edge.TargetVertex, visitedVertices, visitedEdges, edges);
                    }
                }
            }
            
        }
    }
}
