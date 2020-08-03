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
            binaryTreeIntOne.Insert(10);
            binaryTreeIntOne.Insert(5);
            binaryTreeIntOne.Insert(20);
            binaryTreeIntOne.Insert(15);
            binaryTreeIntOne.Insert(1);
        }
    }
}