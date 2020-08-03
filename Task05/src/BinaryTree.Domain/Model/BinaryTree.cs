using BinaryTree.Domain.Interfaces;
using System;

namespace BinaryTree.Domain.Model
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        private const int LeftBalanceFactor = 2;
        private const int RightBalanceFactor = -2;

        /// <summary>
        /// The root node of the binary tree.
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the BinaryTree
        /// </summary>
        public int Count { get; set; }

        public int Height => GetHeight(Root);
        public int BalanceFactor => GetBalanceFactor(Root);

        public BinaryTree()
        {
            Count = 0;
            Root = null;
        }

        /// <summary>
        /// Inserts an element to the tree
        /// </summary>
        /// <param name="item">Item to insert</param>
        public void Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var newNode = new Node<T>(item);
            
            Insert(newNode);
            Root = Balance(Root);
        }

        /// <summary>
        /// The difference in the heights of the right and left subtrees
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>The difference in the heights of the right and left node.</returns>
        public int GetBalanceFactor(Node<T> node)
        {
            if (node == null)
                return -1;

         return GetHeight(node.Right) - GetHeight(node.Left);
        }


        /// <summary>
        /// Balancing nodes.
        /// </summary>
        /// <param name="node">Current node/</param>
        /// <returns>Returns a balanced node.</returns>
        private Node<T> Balance(Node<T> node)
        {
            var test = GetBalanceFactor(node);

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


        void Insert(Node<T> newNode)
        {
            if (Root == null)
            {
                Root = newNode;
                Count++;
                return;
            }

            if (newNode.Parent == null)
                newNode.Parent = Root;


            if (newNode.Value.CompareTo(newNode.Parent.Value) == -1)
            {
                if (newNode.Parent.Left == null)
                { 
                    newNode.Parent.Left = newNode;
                    Count++;
                }
                else
                {
                    newNode.Parent = newNode.Parent.Left;
                    Insert(newNode);
                }
                newNode.Parent.Left = Balance(newNode.Parent.Left);

            }
            else if(newNode.Value.CompareTo(newNode.Parent.Value) == 1)
            {
                if (newNode.Parent.Right == null)
                { 
                    newNode.Parent.Right = newNode;
                    Count++;
                }
                else
                {
                    newNode.Parent = newNode.Parent.Right;
                    Insert(newNode);
                }
                newNode.Parent.Right = Balance(newNode.Parent.Right);
            }
        }

       int GetHeight(Node<T> node)
        {
            if (node == null)
                return 0;
            if (node.IsLeaf)
                return 1;

            return (1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right)));
        }

    }
}
