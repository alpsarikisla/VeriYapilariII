using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.Search
{
    public class BreadthFirst<T>
    {
        public bool Find(IGraph<T> graph,T vertexKey)
        {
            return bfs(graph.ReferenceVertex,new HashSet<T>(),vertexKey);
        }
        private bool bfs(IGraphVertex<T> referenceVertex,HashSet<T> visited,T searchVertexKey)
        {
            var Q = new DataStructures.Queue.Queue<IGraphVertex<T>>();
            Q.EnQueue(referenceVertex);
            visited.Add(referenceVertex.Key);
            //Console.WriteLine(referenceVertex.Key);

            while (Q.Count>0)
            {
                var current = Q.DeQueue();
                Console.WriteLine(current.Key); //Graph override to string yerine yazılabilir
                if (current.Key.Equals(searchVertexKey))
                {
                    return true;
                }
                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.TargetVertexKey))
                    {
                        continue;
                    }
                    visited.Add(edge.TargetVertexKey);
                    //Console.WriteLine(edge.TargetVertexKey);
                    Q.EnQueue(edge.TargetVertex);
                }
            }
            return false;

        }
       
     
    }
}
