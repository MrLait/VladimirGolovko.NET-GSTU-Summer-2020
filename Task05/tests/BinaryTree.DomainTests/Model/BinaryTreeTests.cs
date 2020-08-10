using NUnit.Framework;
using System;
using System.Collections.Generic;
using StudentInformation.Domain.Model;
using StudentInformation.Domain.Repository;
using Serializers.Services;
using Serializers.Services.Util;

namespace BinaryTree.Domain.Model.Tests
{
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
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> where T is Int32.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenTIsIntThenOutIsIntBinaryTree()
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            BinaryTree<int> expectedBinaryTree = new BinaryTree<int>();
            //Act
            expectedBinaryTree.Root = new Node<int>(8, null, new Node<int>(5, null, new Node<int>(3), new Node<int>(7)),
                                                    new Node<int>(11, null, new Node<int>(10), new Node<int>(12)));
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> where T is String.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenTIsStringThenOutIsStringBinaryTree()
        {
            //Arrange
            BinaryTree<string> actualBinaryTree = InitialStringBinaryTree();
            BinaryTree<string> expectedBinaryTree = new BinaryTree<string>();
            //Act
            expectedBinaryTree.Root = new Node<string>("d", null, new Node<string>("b", null, new Node<string>("a"), new Node<string>("c")),
                                                    new Node<string>("f", null, new Node<string>("e"), new Node<string>("g")));
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> where T is Int32 and String.
        /// </summary>
        [TestCase()]
        public void GivenAddWhenActualTIntExpectedTStringThenOutIsNotEquel()
        {
            //Arrange
            BinaryTree<int> actualBinaryTree = InitialIntBinaryTree();
            BinaryTree<string> expectedBinaryTree = new BinaryTree<string>();
            //Act
            expectedBinaryTree.Root = new Node<string>("d", null, new Node<string>("b", null, new Node<string>("a"), new Node<string>("c")),
                                                    new Node<string>("f", null, new Node<string>("e"), new Node<string>("g")));
            //Assert
            Assert.AreNotEqual(expectedBinaryTree, actualBinaryTree);
        }

        /// <summary>
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.Add(T)"/> when ArgumentNullException.
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
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.PreOrder"/>
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
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.PostOrder"/>
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
        /// Testing <see cref="BinaryTreeLib.Core.BinaryTree{T}.InOrder"/>
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

        [Test()]
        public void BinaryTreeTest()
        {

            //Arrange
            BinaryTree<int> aVLTreeVan = new BinaryTree<int>();

            //Act
            aVLTreeVan.Insert(1);
            aVLTreeVan.Insert(2);
            aVLTreeVan.Insert(3);
            aVLTreeVan.Insert(4);
            aVLTreeVan.Insert(5);
            aVLTreeVan.Insert(6);
            aVLTreeVan.Insert(7);
            aVLTreeVan.Insert(8);
            aVLTreeVan.Insert(9);
            aVLTreeVan.Insert(10);
            aVLTreeVan.Insert(11);
            aVLTreeVan.Insert(12);
            aVLTreeVan.Insert(13);

            ////Arrange
            //AVLTree<int> aVLTree = new AVLTree<int>();

            ////Act
            //aVLTree.Add(1);
            //aVLTree.Add(2);
            //aVLTree.Add(3);
            //aVLTree.Add(4);
            //aVLTree.Add(5);
            //aVLTree.Add(6);
            //aVLTree.Add(7);
            //aVLTree.Add(8);
            //aVLTree.Add(9);
            //aVLTree.Add(10);
            //aVLTree.Add(11);
            //aVLTree.Add(12);
            //aVLTree.Add(13);



            BinaryTree<int> binaryTreeIntOne = new BinaryTree<int>();
            binaryTreeIntOne.Insert(5);
            binaryTreeIntOne.Insert(3);
            binaryTreeIntOne.Insert(8);
            binaryTreeIntOne.Insert(7);
            binaryTreeIntOne.Insert(10);
            binaryTreeIntOne.Insert(11);
            binaryTreeIntOne.Insert(12);



            var test1 = binaryTreeIntOne.PreOrder();
            var test2 = binaryTreeIntOne.PostOrder();
            var test3 = binaryTreeIntOne.InOrder();


            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentTwo = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "C", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentThree = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "B", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };

            Student testStudent = new Student();
            Student testStudentTwo = new Student(new Version.Domain.ModuleVersion(2, 0, 0, 0));

            Repository<Student> studentsRepository = new Repository<Student>();
            studentsRepository.Insert(studentOne);
            studentsRepository.Insert(studentTwo);
            studentsRepository.Insert(studentThree);

            List<Student> students = new List<Student>();
            var testObj = studentsRepository.GetAll(x => x.FirstName, true);
            var testObj2 = studentsRepository.GetAll(x => x.FirstName, false);

            Serialize serialize = new Serialize(new JsonSerialaizer());
            serialize.GetSerialize(studentOne);
            var jsonDeserialize = serialize.GetDeserialize<Student>("Student.json");


            Serialize serializeWithCeck = new Serialize(new JsonSerialaizer(), false, true, new Version.Domain.ModuleVersion(1, 0, 0, 0));
            //serializeWithCeck.GetSerialize(studentOne);
            var jsonDeserializeeWithCeck = serializeWithCeck.GetDeserialize<Student>("Student.json");


            Serialize serializeXmlOne = new Serialize(new XmlSerialaizer());
            //serializeXmlOne.GetSerialize(studentOne);
            var xmlOneDeserialize = serializeXmlOne.GetDeserialize<Student>("Student.xml");



            //JsonSerialaizer jsonSerialaizerasdasds = new JsonSerialaizer();
            //XmlSerialaizer xmlSerialaizer = new XmlSerialaizer();
            //BinarySerialaizer binarySerialaizer = new BinarySerialaizer();



            //xmlSerialaizer.Serialize(studentOne);
            //jsonSerialaizerasdasds.Serialize(studentOne);
            //binarySerialaizer.Serialize(studentOne);

            //var binaryDeserialize = binarySerialaizer.Deserialize<Student>("Student.dat");

            //var jsonDeserialize = jsonSerialaizerasdasds.Deserialize<Student>("Student.json");

            //var xmlDeserialize = xmlSerialaizer.Deserialize<Student>("Student.xml");

        }
    }
}