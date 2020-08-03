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
    public class NodeTests
    {
        [Test()]
        public void NodeTest()
        {
            Node<int> nodeIntOne = new Node<int>(1);

        }
    }
}