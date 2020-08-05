using BinaryTree.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace BinaryTree.Domain.Model
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// The root node of the binary tree.
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the BinaryTree
        /// </summary>
        public int Count { get; private set; }

        public BinaryTree()
        {
            Count = 0;
            Root = null;
        }

        public IEnumerable<T> PreOrder() => PreOrder(Root);
        
        public IEnumerable<T> PostOrder() => PostOrder(Root);

        public IEnumerable<T> InOrder() => InOrder(Root);

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
 
        private IEnumerable<T> PreOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                list.Add(node.Value);

                if (node.Left != null)
                    list.AddRange(PreOrder(node.Left));
                if (node.Right != null)
                    list.AddRange(PreOrder(node.Right));
            }

            return list;
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                    list.AddRange(PostOrder(node.Left));
                if (node.Right != null)
                    list.AddRange(PostOrder(node.Right));

                list.Add(node.Value);
            }

            return list;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                    list.AddRange(InOrder(node.Left));

                list.Add(node.Value);

                if (node.Right != null)
                    list.AddRange(InOrder(node.Right));
            }
            return list;
        }
    }
}
