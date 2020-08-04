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

        public BinaryTree()
        {
            Count = 0;
            Root = null;
        }

        /// <summary>
        /// Inserts an element to the tree
        /// </summary>
        /// <param name="data">Item to insert</param>
        public void Insert(T data)
        {
            if (data == null)
                throw new ArgumentNullException();

            if (Root == null)
            { 
                Root = new Node<T>(data);
                Count++;
                return;
            }

            var newNode = new Node<T>(data);
            Root.Insert(newNode);
            Count++;
            Root = Root.Balance(Root);
        }

        



    }
}
