using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public interface IGraph<T> : IEnumerable<T>
    {
        bool isWeightedGraph { get; }
        int Count { get; }
        IGraphVertex<T> ReferenceVertex { get; }
        IEnumerable<IGraphVertex<T>> VerticesAsEnumberable { get; }
        IEnumerable<T> Edges(T key);
        IGraph<T> Clone();
        bool ContainsVertex(T key);
        IGraphVertex<T> GetVertex(T key);
        bool HasEdge(T source, T dest);
        void AddVertex(T key);
        void RemoveVertex(T key);
        void RemoveEdge(T source, T dest);

    }
    public interface IDiGraph<T> : IGraph<T> 
    {
        new IDiGraphVertex<T> ReferenceVertex { get; }
        new IEnumerable<IDiGraphVertex<T>> VerticesAsEnumberable { get; }
        new IDiGraphVertex<T> GetVertex(T key);
    }
    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }
        IEnumerable<IEdge<T>> Edges { get; }
        IEdge<T> GetEdge(IGraphVertex<T> targetVertex);

    }
    public interface IDiGraphVertex<T> : IGraphVertex<T>
    {
        IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex);
        IEnumerable<IDiEdge<T>> OutEdges { get; }
        IEnumerable<IDiEdge<T>> InEdges { get; }
        int OutEdgesCount { get; }
        int InEdgesCount { get; }

    }
    public interface IEdge<T>
    {
        T TargetVertexKey { get; }
        IGraphVertex<T> TargetVertex { get; }
        W Weight<W>() where W : IComparable;
    }
    public interface IDiEdge<T> : IEdge<T>
    {
        new IDiGraphVertex<T> TargetVertex { get; }
    }
}
