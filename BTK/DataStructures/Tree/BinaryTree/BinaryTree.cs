using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        public List<Node<T>> list { get;private set; }
        public BinaryTree()
        {
            list = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (!(root == null))
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode!=null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (S.Count==0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                        
                    }
                }
            }
            return list;
        }
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (!(root==null))
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List< Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            if (root == null)
            {
                throw new Exception("This tree is empty"); 
            }
            S.Push(root);
            while (!(S.Count==0))
            {
                var temp = S.Pop();
                list.Add(temp);
                if (temp.Right!=null)
                {
                    S.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    S.Push(temp.Left);
                }
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (!(root==null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            throw new NotImplementedException();
        }
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            Q.EnQueue(root);
            while (Q.Count>0)
            {
                var temp = Q.DeQueue();
                list.Add(temp);
                if (temp.Left!=null)
                {
                    Q.EnQueue(temp.Left); 
                }
                if (temp.Right != null)
                {
                    Q.EnQueue(temp.Right);
                }
            }
            return list;
        }
        public void ClearList() => list.Clear();
        public static int MaxDepth(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return (leftDepth > rightDepth) ?
                leftDepth +1 :
                rightDepth +1;
        }
        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root==null)
            {
                throw new Exception("Empty tree");
            }
            var q = new DataStructures.Queue.Queue<Node<T>>();
            q.EnQueue(root);
            while (q.Count>0)
            {
                temp = q.DeQueue();
                if (temp.Left!=null)
                {
                    q.EnQueue(temp.Left);
                }
                if (temp.Right != null)
                {
                    q.EnQueue(temp.Right);
                }
            }
            return temp;
        }
        public Node<T> DeepestNode()
        {
            var list = LevelOrderNonRecursiveTraversal(Root);
            return list[list.Count-1];
        }
        public static int NumberOfLeafs(Node<T> root)
        {
            /*
            int count = 0;
            if (root==null)
            {
                return count;
            }
            var q = new DataStructures.Queue.Queue<Node<T>>();
            q.EnQueue(root);
            while (q.Count>0)
            {
                var temp = q.DeQueue();
                if (temp.Left==null && temp.Right==null)
                {
                    count++;
                }
                if (temp.Left != null)
                {
                    q.EnQueue(temp.Left);
                }
                if (temp.Right != null)
                {
                    q.EnQueue(temp.Right);
                }
            }
            return count;
            */

            // 2. Durum
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
                .Where(x=> x.Left==null &&  x.Right==null)
                .ToList()
                .Count;
        }
        public static int NumberOfFullNodes(Node<T> root) =>
            new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
            .Where(node => node.Left!=null && node.Right!=null)
            .ToList()
            .Count;
        public static int NumberOfHalfNodes(Node<T> root) => 
            new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
            .Where(node => (node.Left!=null && node.Right==null) || (node.Left==null && node.Right!=null))
            .ToList()
            .Count;
        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }
        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root==null)
            {
                return;
            }
            path[pathLen] = root.Value;
            pathLen++;
            if (root.Left==null && root.Right==null) // Yaprak mı?
            {
                PrintArray(path, pathLen);
            }
            else
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }
        }
        private void PrintArray(T[] path,int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write($" {path[i]} ");
            }
            Console.WriteLine();
        }
    }
}
