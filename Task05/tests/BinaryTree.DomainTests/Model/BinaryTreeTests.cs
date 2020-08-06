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

            StudentRepository studentRepository = new StudentRepository();
            studentRepository.Insert(studentOne);
            studentRepository.Insert(studentTwo);
            studentRepository.Insert(studentThree);

            List<Student> students = new List<Student>();
            var testObj = studentRepository.GetAll(x => x.FirstName, true);
            var testObj2 = studentRepository.GetAll(x => x.FirstName, false);

            Serialize serialize = new Serialize(new JsonSerialaizer());
            serialize.GetSerialize(studentOne);
            var jsonDeserialize = serialize.GetDeserialize<Student>("Student.json");


            Serialize serializeWithCeck = new Serialize(new JsonSerialaizer(), false, true, new Version.Domain.ModuleVersion(1, 2, 3, 0));
            serializeWithCeck.GetSerialize(studentOne);
            var jsonDeserializeeWithCeck = serializeWithCeck.GetDeserialize<Student>("Student.json");


            Serialize serializeXmlOne = new Serialize(new XmlSerialaizer());
            serializeXmlOne.GetSerialize(studentOne);
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