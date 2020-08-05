using NUnit.Framework;
using BinaryTree.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformation.Domain.Model;
using StudentInformation.Domain.Repository;
using System.Diagnostics;

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



            var test1 = binaryTreeIntOne.PreOrder();
            var test2 = binaryTreeIntOne.PostOrder();
            var test3 = binaryTreeIntOne.InOrder();


            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentTwo = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "C", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentThree = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "B", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };

            StudentRepository studentRepository = new StudentRepository(x => x.FirstName, true);
            studentRepository.Insert(studentOne);
            studentRepository.Insert(studentTwo);
            studentRepository.Insert(studentThree);

            List<Student> students = new List<Student>();

            foreach (var item in studentRepository)
            {
                Debug.WriteLine(item);
            }
            studentRepository.Descending = false;
            foreach (var item in studentRepository)
            {
                Debug.WriteLine(item);
            }
        }
    }
}