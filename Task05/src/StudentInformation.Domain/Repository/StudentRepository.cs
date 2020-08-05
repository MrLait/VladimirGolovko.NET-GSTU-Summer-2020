using BinaryTree.Domain.Model;
using StudentInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation.Domain.Repository
{
    public class StudentRepository
    {
        public BinaryTree<Student> StudentsBinaryTree { get; set; }
        public Func<Student, string> OrderBySelector { get; set; }
        public bool Descending { get; set; }

        public StudentRepository(Func<Student, string> orderBySelector, bool descending)
        {
            StudentsBinaryTree = new BinaryTree<Student>();
            OrderBySelector = orderBySelector;
            Descending = descending;
        }

        /// <summary>
        /// Adding student test results to a binary tree
        /// </summary>
        /// <param name="studentTestResult">Student test results.</param>
        public void Insert(Student student)
        {
            if (student != null)
                StudentsBinaryTree.Insert(student);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            if (Descending)
                return StudentsBinaryTree.InOrder().OrderByDescending(OrderBySelector).GetEnumerator();
            else
                return StudentsBinaryTree.InOrder().OrderBy(OrderBySelector).GetEnumerator();
        }

    }
}
