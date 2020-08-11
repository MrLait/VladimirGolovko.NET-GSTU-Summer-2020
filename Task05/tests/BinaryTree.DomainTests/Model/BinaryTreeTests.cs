using NUnit.Framework;
using System;

namespace BinaryTree.Domain.Model.Tests
{
    /// <summary>
    /// Binary tree tests
    /// </summary>
    [TestFixture()]
    public class BinaryTreeTests
    {

        /// <summary>
        /// Initialization of a int binary tree.
        /// </summary>
        /// <returns>Returns a new int binary tree.</returns>
        public static BinaryTree<int> InitialIntBinaryTree()
        {
            BinaryTree<int> actualBinaryTree = new BinaryTree<int>();

            actualBinaryTree.Insert(5);
            actualBinaryTree.Insert(3);
            actualBinaryTree.Insert(8);
            actualBinaryTree.Insert(7);
            actualBinaryTree.Insert(10);
            actualBinaryTree.Insert(11);
            actualBinaryTree.Insert(12);

            return actualBinaryTree;
        }

        /// <summary>
        /// Initialization of a string binary tree.
        /// </summary>
        /// <returns>Returns a new string binary tree.</returns>
        public static BinaryTree<string> InitialStringBinaryTree()
        {
            BinaryTree<string> actualBinaryTree = new BinaryTree<string>();

            actualBinaryTree.Insert("a");
            actualBinaryTree.Insert("b");
            actualBinaryTree.Insert("c");
            actualBinaryTree.Insert("d");
            actualBinaryTree.Insert("e");
            actualBinaryTree.Insert("f");
            actualBinaryTree.Insert("g");

            return actualBinaryTree;
        }

        /// <summary>
        /// GivenAddWhenTIsIntThenOutIsIntBinaryTree
        /// </summary>
        [TestCase()]
        public void GivenAddWhenTIsIntThenOutIsIntBinaryTree()
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            BinaryTree<int> expectedBinaryTree = new BinaryTree<int>
            {
                Root = new Node<int>(8, new Node<int>(5, new Node<int>(3), new Node<int>(7)),
                                                    new Node<int>(11, new Node<int>(10), new Node<int>(12)))
            };
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// GivenAddWhenTIsStringThenOutIsStringBinaryTree
        /// </summary>
        [TestCase()]
        public void GivenAddWhenTIsStringThenOutIsStringBinaryTree()
        {
            //Arrange
            BinaryTree<string> actualBinaryTree = InitialStringBinaryTree();
            BinaryTree<string> expectedBinaryTree = new BinaryTree<string>
            {
                Root = new Node<string>("d", new Node<string>("b", new Node<string>("a"), new Node<string>("c")),
                                                    new Node<string>("f", new Node<string>("e"), new Node<string>("g")))
            };
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// GivenAddWhenActualTIntExpectedTStringThenOutIsNotEquel
        /// </summary>
        [TestCase()]
        public void GivenAddWhenActualTIntExpectedTStringThenOutIsNotEquel()
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            BinaryTree<string> expectedBinaryTree = new BinaryTree<string>
            {
                Root = new Node<string>("d", new Node<string>("b", new Node<string>("a"), new Node<string>("c")),
                                                    new Node<string>("f", new Node<string>("e"), new Node<string>("g")))
            };
            //Assert
            Assert.AreNotEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// GivenAddWhenArgumentIsNullThenOutIsArgumentNullException
        /// </summary>
        [TestCase()]
        public void GivenAddWhenArgumentIsNullThenOutIsArgumentNullException()
        {
            //Arrange
            BinaryTree<string> actualBinaryTree = new BinaryTree<string>();
            //Assert
            Assert.That(() => actualBinaryTree.Insert(null), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Testing GivenPreOrderWhenTIsIntThenOutIsString
        /// </summary>
        /// <param name="expectedBinaryTreeToPreOrderStr">A string containing all the elements that were found in the binary tree.</param>
        /// <param name="initEmpty">BinaryTree is null?</param>
        [TestCase("8 5 3 7 11 10 12 ", false)]
        [TestCase("", true)]
        public void GivenPreOrderWhenTIsIntThenOutIsString(string expectedBinaryTreeToPreOrderStr, bool initEmpty)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree;

            if (!initEmpty)
                actualBinaryTree = InitialIntBinaryTree();
            else
                actualBinaryTree = new BinaryTree<int>();
            //Act
            string actualBinaryTreeToPreOrderStr = string.Empty;

            foreach (var item in actualBinaryTree.PreOrder())
            {
                actualBinaryTreeToPreOrderStr += item + " ";
            }
            //Assert
            Assert.AreEqual(expectedBinaryTreeToPreOrderStr, actualBinaryTreeToPreOrderStr);
        }

        /// <summary>
        /// Testing GivenPostOrderWhenTIsIntThenOutIsString
        /// </summary>
        /// <param name="expectedBinaryTreeToPostOrderStr">A string containing all the elements that were found in the binary tree.</param>
        /// <param name="initEmpty">BinaryTree is null?</param>
        [TestCase("3 7 5 10 12 11 8 ", false)]
        [TestCase("", true)]
        public void GivenPostOrderWhenTIsIntThenOutIsString(string expectedBinaryTreeToPostOrderStr, bool initEmpty)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree;

            if (!initEmpty)
                actualBinaryTree = InitialIntBinaryTree();
            else
                actualBinaryTree = new BinaryTree<int>();
            //Act
            string actualBinaryTreeToPostOrderStr = string.Empty;
            foreach (var item in actualBinaryTree.PostOrder())
            {
                actualBinaryTreeToPostOrderStr += item + " ";
            }
            //Assert
            Assert.AreEqual(expectedBinaryTreeToPostOrderStr, actualBinaryTreeToPostOrderStr);
        }

        /// <summary>
        /// Testing GivenInOrderWhenTIsIntThenOutIsString
        /// </summary>
        /// <param name="expectedBinaryTreeToInOrderStr">A string containing all the elements that were found in the binary tree.</param>
        /// <param name="initEmpty">BinaryTree is null?</param>
        [TestCase("3 5 7 8 10 11 12 ", false)]
        [TestCase("", true)]
        public void GivenInOrderWhenTIsIntThenOutIsString(string expectedBinaryTreeToInOrderStr, bool initEmpty)
        {
            //Arrange
            BinaryTree<int> actualBinaryTree;

            if (!initEmpty)
                actualBinaryTree = InitialIntBinaryTree();
            else
                actualBinaryTree = new BinaryTree<int>();
            //Act
            string actualBinaryTreeToInOrderStr = string.Empty;
            foreach (var item in actualBinaryTree.InOrder())
            {
                actualBinaryTreeToInOrderStr += item + " ";
            }
            //Assert
            Assert.AreEqual(expectedBinaryTreeToInOrderStr, actualBinaryTreeToInOrderStr);
        }
    }
}