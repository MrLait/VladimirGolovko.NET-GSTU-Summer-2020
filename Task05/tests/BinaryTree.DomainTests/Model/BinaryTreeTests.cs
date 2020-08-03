using NUnit.Framework;
using BinaryTree.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Domain.Model.Tests
{
    [TestFixture()]
    public class BinaryTreeTests
    {
        [Test()]
        public void BinaryTreeTest()
        {
            BinaryTree<int> binaryTreeIntOne = new BinaryTree<int>();
            binaryTreeIntOne.Insert(0);
            binaryTreeIntOne.Insert(1);
            binaryTreeIntOne.Insert(2);
            binaryTreeIntOne.Insert(3);
            binaryTreeIntOne.Insert(4);
            binaryTreeIntOne.Insert(5);
            binaryTreeIntOne.Insert(6);
            binaryTreeIntOne.Insert(7);
            binaryTreeIntOne.Insert(8);
            binaryTreeIntOne.Insert(9);


            var test = binaryTreeIntOne.GetHeight(binaryTreeIntOne.Root);
        }
    }
}