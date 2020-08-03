using BinaryTree.Domain.Interfaces;
using System;

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
        public int Count { get; set; }

        public int Height => GetHeight(Root);

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


            if (newNode.Parent.Value.CompareTo(newNode.Value) == 1)
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
            }
            else if(newNode.Parent.Value.CompareTo(newNode.Value) == -1)
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
