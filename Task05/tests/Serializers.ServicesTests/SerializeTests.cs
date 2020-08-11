using NUnit.Framework;
using Serializer.Services.Util;
using Serializers.Services.Util;
using StudentInformation.Domain.Model;
using StudentInformation.Domain.Repository;
using System;
using Version.Domain;

namespace Serializers.Services.Tests
{
    /// <summary>
    /// Serialize test.
    /// </summary>
    [TestFixture()]
    public class SerializeTests
    {
        /// <summary>
        /// GivenXmlSerializeStudentsRepository_ThenOutXmlSerialize
        /// </summary>
        [Test()]
        public void GivenXmlSerializeStudentsRepository_ThenOutXmlSerialize()
        {
            //Actual
            Serialize xmlSerialize = new Serialize(new XmlSerialaizer());
            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentTwo = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "C", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentThree = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "B", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Repository<Student> expectedRepository = new Repository<Student>();
            //Act
            expectedRepository.Insert(studentOne);
            expectedRepository.Insert(studentTwo);
            expectedRepository.Insert(studentThree);
            xmlSerialize.GetSerialize(expectedRepository, "serializeData");
            var actualRepository = xmlSerialize.GetDeserialize<Repository<Student>>("serializeData/Repository`1.xml");
            //Assert
            Assert.AreEqual(expectedRepository, actualRepository);
        }

        /// <summary>
        /// GivenJsonSerializeStudentsRepository_ThenOutJsonSerialize
        /// </summary>
        [Test()]
        public void GivenJsonSerializeStudentsRepository_ThenOutJsonSerialize()
        {
            //Actual
            Serialize jonSerialaizer = new Serialize(new JsonSerialaizer());
            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentTwo = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "C", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentThree = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "B", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Repository<Student> expectedRepository = new Repository<Student>();
            //Act
            expectedRepository.Insert(studentOne);
            expectedRepository.Insert(studentTwo);
            expectedRepository.Insert(studentThree);
            jonSerialaizer.GetSerialize(expectedRepository, "serializeData");
            var actualRepository = jonSerialaizer.GetDeserialize<Repository<Student>>("serializeData/Repository`1.json");
            //Assert
            Assert.AreEqual(expectedRepository, actualRepository);
        }

        /// <summary>
        /// GivenBinarySerializeStudentsRepository_ThenOutBinarySerialize
        /// </summary>
        [Test()]
        public void GivenBinarySerializeStudentsRepository_ThenOutBinarySerialize()
        {
            //Actual
            Serialize binarySerialaizer = new Serialize(new BinarySerialaizer());
            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentTwo = new Student() { ID = 1, DateOfBirth = DateTime.Now, FirstName = "C", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Student studentThree = new Student() { ID = 2, DateOfBirth = DateTime.Now, FirstName = "B", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            Repository<Student> expectedRepository = new Repository<Student>();
            //Act
            expectedRepository.Insert(studentOne);
            expectedRepository.Insert(studentTwo);
            expectedRepository.Insert(studentThree);
            binarySerialaizer.GetSerialize(expectedRepository, "serializeData");
            var actualRepository = binarySerialaizer.GetDeserialize<Repository<Student>>("serializeData/Repository`1.dat");
            //Assert
            Assert.AreEqual(expectedRepository, actualRepository);
        }

        /// <summary>
        /// GivenJsonSerialize_WhenStudentWitnISerialize_ThenOutJsonSerialize
        /// </summary>
        [Test()]
        public void GivenJsonSerialize_WhenStudentWitnISerialize_ThenOutJsonSerialize()
        {
            //Actual
            Serialize jsonSerialize = new Serialize(new JsonSerialaizer(),true, true, new ModuleVersion(1,0,0,0));
            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            //Act
            jsonSerialize.GetSerialize(studentOne, "serializeData");
            var actualStudent = jsonSerialize.GetDeserialize<Student>("serializeData/Student.json");
            //Assert
            Assert.AreEqual(studentOne, actualStudent);
        }

        /// <summary>
        /// GivenXmlSerialize_WhenStudentWitnISerialize_ThenOutXmlSerialize
        /// </summary>
        [Test()]
        public void GivenXmlSerialize_WhenStudentWitnISerialize_ThenOutXmlSerialize()
        {
            //Actual
            Serialize xmlSerialize = new Serialize(new XmlSerialaizer(), true, true, new ModuleVersion(1, 0, 0, 0));
            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            //Act
            xmlSerialize.GetSerialize(studentOne, "serializeData");
            var actualStudent = xmlSerialize.GetDeserialize<Student>("serializeData/Student.xml");
            //Assert
            Assert.AreEqual(studentOne, actualStudent);
        }

        /// <summary>
        /// GivenBinarySerialize_WhenStudentWitnISerialize_ThenOutBinarySerialize
        /// </summary>
        [Test()]
        public void GivenBinarySerialize_WhenStudentWitnISerialize_ThenOutBinarySerialize()
        {
            //Actual
            Serialize binarySerialize = new Serialize(new BinarySerialaizer(), true, true, new ModuleVersion(1, 0, 0, 0));
            Student studentOne = new Student() { ID = 0, DateOfBirth = DateTime.Now, FirstName = "A", Gender = "Male", MiddleName = "vov2", SurName = "vov3" };
            //Act
            binarySerialize.GetSerialize(studentOne, "serializeData");
            var actualStudent = binarySerialize.GetDeserialize<Student>("serializeData/Student.dat");
            //Assert
            Assert.AreEqual(studentOne, actualStudent);
        }

    }
}