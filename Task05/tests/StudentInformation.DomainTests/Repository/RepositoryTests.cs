using BinaryTree.Domain.Model;
using NUnit.Framework;
using StudentInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInformation.Domain.Repository.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture()]
    public class RepositoryTests
    {
        /// <summary>
        /// InitialStudentBinaryTree
        /// </summary>
        /// <returns></returns>
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
        /// InitialTestResultsBinaryTree
        /// </summary>
        /// <returns></returns>
        public static BinaryTree<TestResults> InitialTestResultsBinaryTree()
        {
            BinaryTree<TestResults> actualBinaryTree = new BinaryTree<TestResults>();
            actualBinaryTree.Insert(new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today });
            actualBinaryTree.Insert(new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today });
            actualBinaryTree.Insert(new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today });
            actualBinaryTree.Insert(new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today });
            actualBinaryTree.Insert(new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today });
            actualBinaryTree.Insert(new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today });
            return actualBinaryTree;
        }

        /// <summary>
        /// GivenAddStudentToBinaryTreeThenOutIsStudentBinaryTree
        /// </summary>
        [TestCase()]
        public void GivenAddStudentToBinaryTreeThenOutIsStudentBinaryTree()
        {
            //Arrange
            Student studentA = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "FirstNameA", Gender = "Male", MiddleName = "MiddleNameA", SurName = "SurNameA" };
            Student studentC = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "FirstNameC", Gender = "Male", MiddleName = "MiddleNameC", SurName = "SurNameC" };
            Student studentB = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "FirstNameB", Gender = "Male", MiddleName = "MiddleNameB", SurName = "SurNameB" };
            Repository<Student> studentRepository = new Repository<Student>();
            BinaryTree<Student> expectedBinaryTree = new BinaryTree<Student>
            {
                Root = new Node<Student>(studentC, new Node<Student>(studentA), new Node<Student>(studentB))
            };
            //Act
            studentRepository.Insert(studentA);
            studentRepository.Insert(studentC);
            studentRepository.Insert(studentB);
            var actualBinaryTreeStudentTestResult = studentRepository.BinaryTree;
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResult);
        }

        /// <summary>
        /// GivenAddTestToBinaryTreeThenOutIsTestBinaryTree
        /// </summary>
        [TestCase()]
        public void GivenAddTestToBinaryTreeThenOutIsTestBinaryTree()
        {
            //Arrange
            Test testA = new Test() { ID = 0, TestName = "TestNameA" };
            Test testC = new Test() { ID = 1, TestName = "TestNameC" };
            Test testB = new Test() { ID = 2, TestName = "TestNameB" };
            Repository<Test> testRepository = new Repository<Test>();
            BinaryTree<Test> expectedBinaryTree = new BinaryTree<Test>
            {
                Root = new Node<Test>(testC, new Node<Test>(testA), new Node<Test>(testB))
            };
            //Act
            testRepository.Insert(testA);
            testRepository.Insert(testC);
            testRepository.Insert(testB);
            var actualBinaryTreeStudentTestResult = testRepository.BinaryTree;
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResult);
        }

        /// <summary>
        /// GivenAddTestResultsToBinaryTreeThenOutIsTestResultsBinaryTree
        /// </summary>
        [TestCase()]
        public void GivenAddTestResultsToBinaryTreeThenOutIsTestResultsBinaryTree()
        {
            //Arrange
            TestResults testResultsA = new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Now};
            TestResults testResultsC = new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 98, TestData = DateTime.Now };
            TestResults testResultsB = new TestResults() { ID = 2, StudentID = 1, TestID = 0, Value = 60, TestData = DateTime.Now };
            Repository<TestResults> testResultsRepository = new Repository<TestResults>();
            BinaryTree<TestResults> expectedBinaryTree = new BinaryTree<TestResults>
            {
                Root = new Node<TestResults>(testResultsC, new Node<TestResults>(testResultsA), new Node<TestResults>(testResultsB))
            };

            //Act
            testResultsRepository.Insert(testResultsA);
            testResultsRepository.Insert(testResultsC);
            testResultsRepository.Insert(testResultsB);
            var actualBinaryTreeStudentTestResultsResult = testResultsRepository.BinaryTree;
            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResultsResult);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingByIdFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenStudentsDescendingByIdFalse(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };

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
            List<Student> actualGetAll =  actualRepository.GetAll(x => x.ID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingByIdTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenStudentsDescendingByIdTrue(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };
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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.ID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingByFirstNameFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenStudentsDescendingByFirstNameFalse(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };
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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.FirstName.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingByFirstNameTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenStudentsDescendingByFirstNameTrue(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };
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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.FirstName.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingByMiddleNameFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenStudentsDescendingByMiddleNameFalse(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };
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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.MiddleName, descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingByMiddleNameTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenStudentsDescendingByMiddleNameTrue(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };

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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.MiddleName, descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingBySurNameFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenStudentsDescendingBySurNameFalse(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };

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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.SurName, descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenStudentsDescendingBySurNameTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenStudentsDescendingBySurNameTrue(bool descending)
        {
            //Arrange
            Repository<Student> actualRepository = new Repository<Student>
            {
                BinaryTree = InitialStudentBinaryTree()
            };

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
            List<Student> actualGetAll = actualRepository.GetAll(x => x.SurName, descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByIdFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenTestResultssDescendingByIdFalse(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.ID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByIdTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenTestResultssDescendingByIdTrue(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today}

            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.ID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByStudentIDFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenTestResultssDescendingByStudentIDFalse(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.StudentID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByStudentIDTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenTestResultssDescendingByStudentIDTrue(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today},
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.StudentID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByTestIDFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenTestResultssDescendingByTestIDFalse(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.TestID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByTestIDTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenTestResultssDescendingByTestIDTrue(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.TestID.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByValueFalse
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(false)]
        public void GivenGetAll_WhenTestResultssDescendingByValueFalse(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today},
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.Value.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }

        /// <summary>
        /// GivenGetAll_WhenTestResultssDescendingByValueTrue
        /// </summary>
        /// <param name="descending">descending</param>
        [TestCase(true)]
        public void GivenGetAll_WhenTestResultssDescendingByValueTrue(bool descending)
        {
            //Arrange
            Repository<TestResults> actualRepository = new Repository<TestResults>
            {
                BinaryTree = InitialTestResultsBinaryTree()
            };

            List<TestResults> expectedGetAll = new List<TestResults>()
            {
                new TestResults() { ID = 2, StudentID = 0, TestID = 2, Value = 99, TestData = DateTime.Today},
                new TestResults() { ID = 3, StudentID = 1, TestID = 0, Value = 98, TestData = DateTime.Today},
                new TestResults() { ID = 1, StudentID = 0, TestID = 1, Value = 58, TestData = DateTime.Today},
                new TestResults() { ID = 5, StudentID = 1, TestID = 2, Value = 20, TestData = DateTime.Today},
                new TestResults() { ID = 0, StudentID = 0, TestID = 0, Value = 10, TestData = DateTime.Today},
                new TestResults() { ID = 4, StudentID = 1, TestID = 1, Value = 1, TestData = DateTime.Today}
            };
            //Act
            List<TestResults> actualGetAll = actualRepository.GetAll(x => x.Value.ToString(), descending).ToList();
            //Assert
            Assert.AreEqual(expectedGetAll, actualGetAll);
        }
    }
}