using BinaryTree.Domain.Model;
using System;
using System.Collections.Generic;

namespace BinaryTree.Domain.Interfaces
{
    public interface IBinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// The root node of the binary tree.
        /// </summary>
        Node<T> Root { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the BinaryTree
        /// </summary>
        int Count { get; }

        IEnumerable<T> PreOrder();

        IEnumerable<T> PostOrder();

        IEnumerable<T> InOrder();

        // Inserts an element to the tree
        void Insert(T item);        

    }
}
