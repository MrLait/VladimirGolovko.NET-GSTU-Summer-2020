using System;

namespace BinaryTree.Domain.Model
{
    /// <summary>
    /// Node class.
    /// </summary>
    /// <typeparam name="T">Object.</typeparam>
    [Serializable]
    public class Node<T> where T : IComparable
    {
        /// <summary>
        /// Left balance factor.
        /// </summary>
        private const int LeftBalanceFactor = 2;

        /// <summary>
        /// Right balance factor.
        /// </summary>
        private const int RightBalanceFactor = -2;

        /// <summary>
        /// Node value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Left node.
        /// </summary>
        public Node<T> Left { get;  set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public Node<T> Right { get;  set; }

        /// <summary>
        ///C heck if it's a leaf or not.
        /// </summary>
        public bool IsLeaf => GetChildrenCount() ==  0;

        /// <summary>
        /// Property height.
        /// </summary>
        public int Height => GetHeight(this);

        /// <summary>
        /// Property balance factor.
        /// </summary>
        public int BalanceFactor => GetBalanceFactor(this);

        /// <summary>
        /// Constructor with out parameters.
        /// </summary>
        public Node() {}

        /// <summary>
        /// Constructor for init value.
        /// </summary>
        /// <param name="value">Value</param>
        public Node(T value) 
        { 
            Value = value; 
        }

        /// <summary>
        /// Constructor for init value, parent node, left node, right node.
        /// </summary>
        /// <param name="value">Valeu.</param>
        /// <param name="left">Left node.</param>
        /// <param name="right">Right node.</param>
        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            //Parent = parent;
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

        /// <summary>
        /// Insert node in left or right node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void Insert(Node<T> node)
        {
            if (node.Value.CompareTo(Value) == -1)
            {
                if (Left == null)
                { 
                    Left = node;
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
                }
                else
                    Right.Insert(node);

                Right = Balance(Right);
            }
        }

        /// <summary>
        /// Comparing one node with another.
        /// </summary>
        /// <param name="obj">The compared node.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Node<T> node = (Node<T>)obj;
            return Value.Equals(node.Value);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// The difference in the heights of the right and left subtrees
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>The difference in the heights of the right and left node.</returns>
        private int GetBalanceFactor(Node<T> node) =>
            GetHeight(node.Right) - GetHeight(node.Left);

        /// <summary>
        /// Counter left and right node.
        /// </summary>
        private int GetChildrenCount()
        {
            int cnt = 0;

            if (Left != null)
                cnt++;
            if (Right != null)
                cnt++;
            return cnt;
        }

        /// <summary>
        /// Count height node.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <returns></returns>
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
            node.Right = newNode.Left;
            newNode.Left = node;
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
            node.Left = newNode.Right;
            newNode.Right = node;
            return newNode;
        }
    }
}
