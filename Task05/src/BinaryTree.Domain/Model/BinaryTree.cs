using BinaryTree.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BinaryTree.Domain.Model
{
    /// <summary>
    /// Binary tree class.
    /// </summary>
    /// <typeparam name="T">Object.</typeparam>
    [Serializable]
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// The root node of the binary tree.
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the BinaryTree
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Constructor withaut parameters.
        /// </summary>
        public BinaryTree()
        {
            Count = 0;
            Root = null;
        }

        /// <summary>
        /// Tree traversal preOrder.
        /// </summary>
        /// <returns>Returns an ordered tree.</returns>
        public IEnumerable<T> PreOrder() => GetPreOrder(Root);

        /// <summary>
        /// Tree traversal postOrder.
        /// </summary>
        /// <returns>Returns an ordered tree.</returns>
        public IEnumerable<T> PostOrder() => GetPostOrder(Root);

        /// <summary>
        /// Tree traversal inOrder.
        /// </summary>
        /// <returns>Returns an ordered tree.</returns>
        public IEnumerable<T> InOrder() => GetInOrder(Root);

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

        /// <summary>
        /// Comparing one binary tree with another.
        /// </summary>
        /// <param name="obj">The compared binary tree.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            BinaryTree<T> binaryTree = (BinaryTree<T>)obj;
            return Root.Equals(binaryTree.Root);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode() => Root.GetHashCode();

        /// <summary>
        /// Tree traversal preOrder.
        /// </summary>
        /// <param name="node">Node parameter.</param>
        /// <returns>Returns an ordered tree</returns>
        private IEnumerable<T> GetPreOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                list.Add(node.Value);

                if (node.Left != null)
                    list.AddRange(GetPreOrder(node.Left));
                if (node.Right != null)
                    list.AddRange(GetPreOrder(node.Right));
            }
            return list;
        }

        /// <summary>
        /// Tree traversal preOrder.
        /// </summary>
        /// <param name="node">Node parameter.</param>
        /// <returns>Returns an ordered tree</returns>
        private IEnumerable<T> GetPostOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                    list.AddRange(GetPostOrder(node.Left));
                if (node.Right != null)
                    list.AddRange(GetPostOrder(node.Right));

                list.Add(node.Value);
            }

            return list;
        }

        /// <summary>
        /// Tree traversal inOrder.
        /// </summary>
        /// <param name="node">Node parameter.</param>
        /// <returns>Returns an ordered tree</returns>
        private IEnumerable<T> GetInOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                    list.AddRange(GetInOrder(node.Left));

                list.Add(node.Value);

                if (node.Right != null)
                    list.AddRange(GetInOrder(node.Right));
            }
            return list;
        }
    }
}
