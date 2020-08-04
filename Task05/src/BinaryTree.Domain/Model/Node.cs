using System;

namespace BinaryTree.Domain.Model
{
    public class Node<T> where T : IComparable<T>
    {
        private const int LeftBalanceFactor = 2;
        private const int RightBalanceFactor = -2;

        public T Value { get; set; }
        /// <summary>
        /// The data that is stored in the node.
        /// </summary>
        public Node<T> Parent { get;  set; }

        /// <summary>
        /// Left node.
        /// </summary>
        public Node<T> Left { get;  set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public Node<T> Right { get;  set; }

        public bool IsLeaf => childrenCount ==  0;

        public int Height => GetHeight(this);
        public int BalanceFactor => GetBalanceFactor(this);

        public Node() : this(default(T), null, null, null) { }
        public Node(T value) : this(value, null, null, null) { }
        public Node(T value, Node<T> parent, Node<T> left, Node<T> right)
        {
            Value = value;
            Parent = parent;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Balancing nodes.
        /// </summary>
        /// <param name="node">Current node/</param>
        /// <returns>Returns a balanced node.</returns>
        public Node<T> Balance(Node<T> node)
        {
            if (GetBalanceFactor(node) == LeftBalanceFactor)
            {
                if (GetBalanceFactor(node.Right) < 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            if (GetBalanceFactor(node) == RightBalanceFactor)
            {
                if (GetBalanceFactor(node.Left) > 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            return node;
        }

        public void Insert(Node<T> node)
        {

            if (node.Value.CompareTo(Value) == -1)
            {
                if (Left == null)
                { 
                    Left = node;
                    Left.Parent = this;
                }
                else
                    Left.Insert(node);

                Left = Balance(Left);
            }
            else
            {
                if (Right == null)
                { 
                    Right = node;
                    Right.Parent = this;
                }
                else
                    Right.Insert(node);

                Right = Balance(Right);
            }
        }

        private int childrenCount
        {
            get
            {
                int cnt = 0;

                if (Left != null)
                    cnt++;
                if (Right != null)
                    cnt++;
                return cnt;
            }
        }

        /// <summary>
        /// The difference in the heights of the right and left subtrees
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>The difference in the heights of the right and left node.</returns>
        private int GetBalanceFactor(Node<T> node)
        {
            return GetHeight(node.Right) - GetHeight(node.Left);
        }

        private int GetHeight(Node<T> node)
        {
            if (node == null)
                return 0;
            if (node.IsLeaf)
                return 1;

            return (1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right)));
        }

        /// <summary>
        /// Left turn around node.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Returns the new rotated node.</returns>
        private Node<T> RotateLeft(Node<T> node)
        {
            var newNode = node.Right;
            var parent = node.Parent;
            
            node.Right = newNode.Left;
            newNode.Left = node;

            // Update parents references
            node.Parent = newNode;
            newNode.Parent = parent;

            if (node.Right != null)
                node.Right.Parent = node;

            return newNode;
        }

        /// <summary>
        /// Right turn around node.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Returns the new rotated node.</returns>
        private Node<T> RotateRight(Node<T> node)
        {
            var newNode = node.Left;
            var parent = node.Parent;

            node.Left = newNode.Right;
            newNode.Right = node;

            // Update parents references
            node.Parent = newNode;
            newNode.Parent = parent;

            if (node.Left != null)
                node.Left.Parent = node;

            return newNode;
        }
    }
}
