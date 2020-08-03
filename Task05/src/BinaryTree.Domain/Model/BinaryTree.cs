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

        protected void Insert(Node<T> newNode)
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


        ///// <summary>
        ///// Inserts a new node to the tree.
        ///// </summary>
        ///// <param name="currentNode">Current node to insert afters.</param>
        ///// <param name="newNode">New node to be inserted.</param>
        //protected virtual bool _insertNode(BSTNode<T> newNode)
        //{
        //    // Handle empty trees
        //    if (this.Root == null)
        //    {
        //        Root = newNode;
        //        _count++;
        //        return true;
        //    }

        //    if (newNode.Parent == null)
        //        newNode.Parent = this.Root;

        //    // Check for value equality and whether inserting duplicates is allowed
        //    if (_allowDuplicates == false && newNode.Parent.Value.IsEqualTo(newNode.Value))
        //    {
        //        return false;
        //    }

        //    // Go Left
        //    if (newNode.Parent.Value.IsGreaterThan(newNode.Value)) // newNode < parent
        //    {
        //        if (newNode.Parent.HasLeftChild == false)
        //        {
        //            newNode.Parent.LeftChild = newNode;

        //            // Increment count.
        //            _count++;

        //            return true;
        //        }

        //        newNode.Parent = newNode.Parent.LeftChild;
        //        return _insertNode(newNode);
        //    }
        //    // Go Right

        //    if (newNode.Parent.HasRightChild == false)
        //    {
        //        newNode.Parent.RightChild = newNode;

        //        // Increment count.
        //        _count++;

        //        return true;
        //    }

        //    newNode.Parent = newNode.Parent.RightChild;
        //    return _insertNode(newNode);
        //}

    }
}
