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
            binaryTreeIntOne.Insert(5);
            binaryTreeIntOne.Insert(3);
            binaryTreeIntOne.Insert(8);
            binaryTreeIntOne.Insert(7);
            binaryTreeIntOne.Insert(10);
            binaryTreeIntOne.Insert(11);
            binaryTreeIntOne.Insert(12);
            binaryTreeIntOne.Insert(13);


            var test = binaryTreeIntOne.Height;
        }
    }
}