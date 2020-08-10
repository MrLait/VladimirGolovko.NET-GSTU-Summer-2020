using BinaryTree.Domain.Model;
using NUnit.Framework;
using StudentInformation.Domain.Model;
using StudentInformation.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation.Domain.Repository.Tests
{
    [TestFixture()]
    public class RepositoryTests
    {
        public static BinaryTree<Student> InitialStudentBinaryTree()
        {
            BinaryTree<Student> actualBinaryTree = new BinaryTree<Student>();
            actualBinaryTree.Insert(new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" });
            actualBinaryTree.Insert(new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" });
            actualBinaryTree.Insert(new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" });
            actualBinaryTree.Insert(new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" });
            actualBinaryTree.Insert(new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" });
            actualBinaryTree.Insert(new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" });
            return actualBinaryTree;
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenAddStudentToBinaryTreeThenOutIsStudentBinaryTree()
        {
            //Arrange
            Student studentA = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" };
            Student studentC = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" };
            Student studentB = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" };
            Repository<Student> studentRepository = new Repository<Student>();
            BinaryTree<Student> expectedBinaryTree = new BinaryTree<Student>();
            expectedBinaryTree.Root = new Node<Student>(studentC, null, new Node<Student>(studentA), new Node<Student>(studentB));
            //Act
            studentRepository.Insert(studentA);
            studentRepository.Insert(studentC);
            studentRepository.Insert(studentB);
            var actualBinaryTreeStudentTestResult = studentRepository.BinaryTree;
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResult);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenAddTestToBinaryTreeThenOutIsTestBinaryTree()
        {
            //Arrange
            Test testA = new Test() { ID = 0, TestName = "TestNameA" };
            Test testC = new Test() { ID = 1, TestName = "TestNameC" };
            Test testB = new Test() { ID = 2, TestName = "TestNameB" };
            Repository<Test> testRepository = new Repository<Test>();
            BinaryTree<Test> expectedBinaryTree = new BinaryTree<Test>();
            expectedBinaryTree.Root = new Node<Test>(testC, null, new Node<Test>(testA), new Node<Test>(testB));
            //Act
            testRepository.Insert(testA);
            testRepository.Insert(testC);
            testRepository.Insert(testB);
            var actualBinaryTreeStudentTestResult = testRepository.BinaryTree;
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResult);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenAddTestResultsToBinaryTreeThenOutIsTestResultsBinaryTree()
        {
            //Arrange
            TestResults testResultsA = new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Now};
            TestResults testResultsC = new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 99, TestData = DateTime.Now };
            TestResults testResultsB = new TestResults() { ID = 2, StudentID = 1, TestID = 0, Value = 60, TestData = DateTime.Now };
            Repository<TestResults> testResultsRepository = new Repository<TestResults>();
            BinaryTree<TestResults> expectedBinaryTree = new BinaryTree<TestResults>();
            expectedBinaryTree.Root = new Node<TestResults>(testResultsC, null, new Node<TestResults>(testResultsA), new Node<TestResults>(testResultsB));
            //Act
            testResultsRepository.Insert(testResultsA);
            testResultsRepository.Insert(testResultsC);
            testResultsRepository.Insert(testResultsB);
            var actualBinaryTreeStudentTestResultsResult = testResultsRepository.BinaryTree;
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResultsResult);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingByIdFalse()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" }
            };
            //Act
            List<Student> actualGetAll =  actualRepository.GetAll(x => x.ID.ToString(), false).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingByIdTrue()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.ID.ToString(), true).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingByFirstNameFalse()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.FirstName.ToString(), false).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingByFirstNameTrue()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.FirstName.ToString(), true).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingByMiddleNameFalse()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.ID.ToString(), false).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingByMiddleNameTrue()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.MiddleName, true).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingBySurNameFalse()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.SurName, false).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// Testing <see cref="Repository{T}.BinaryTree)"/>
        /// </summary>
        [TestCase()]
        public void GivenGetAll_WhenStudentsDescendingBySurNameTrue()
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>();
            actualRepository.BinaryTree = InitialStudentBinaryTree();
            List<Student> expectedGetAll = new List<Student>()
            {
                new Student() { ID = 5, DateOfBirth = DateTime.Today, FirstName = "FirstNameF", Gender = "Male", MiddleName = "MiddleNameF", SurName = "SurNameF" },
                new Student() { ID = 4, DateOfBirth = DateTime.Today, FirstName = "FirstNameE", Gender = "Male", MiddleName = "MiddleNameE", SurName = "SurNameE" },
                new Student() { ID = 3, DateOfBirth = DateTime.Today, FirstName = "FirstNameD", Gender = "Male", MiddleName = "MiddleNameD", SurName = "SurNameD" },
                new Student() { ID = 2, DateOfBirth = DateTime.Today, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" },
                new Student() { ID = 1, DateOfBirth = DateTime.Today, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" },
                new Student() { ID = 0, DateOfBirth = DateTime.Today, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" }
            };
            //Act
            List<Student> actualGetAll = actualRepository.GetAll(x => x.SurName, true).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }
    }
}