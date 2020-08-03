using System;

namespace BinaryTree.Domain.Model
{
    public class Node<T> where T : IComparable<T>
    {
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

        public Node() : this(default(T), 0, null, null, null) { }
        public Node(T value) : this(value, 0, null, null, null) { }
        public Node(T value, int subTreeSize, Node<T> parent, Node<T> left, Node<T> right)
        {
            Value = value;
            Parent = parent;
            Left = left;
            Right = right;
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

    }
}
