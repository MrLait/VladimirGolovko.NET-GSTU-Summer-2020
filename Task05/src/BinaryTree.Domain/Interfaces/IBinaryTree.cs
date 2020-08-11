using BinaryTree.Domain.Model;
using System;
using System.Collections.Generic;

namespace BinaryTree.Domain.Interfaces
{
    /// <summary>
    /// Interface for BinaryTree.
    /// </summary>
    /// <typeparam name="T">Object.</typeparam>
    public interface IBinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// The root node of the binary tree.
        /// </summary>
        Node<T> Root { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the BinaryTree
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// <see cref="BinaryTree{T}.PreOrder"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> PreOrder();

        /// <summary>
        /// <see cref="BinaryTree{T}.PostOrder"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> PostOrder();

        /// <summary>
        /// <see cref="BinaryTree{T}.InOrder"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> InOrder();

        /// <summary>
        /// Inserts an element to the tree
        /// </summary>
        /// <param name="item">Element.</param>
        void Insert(T item);        

    }
}
