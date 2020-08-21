using NUnit.Framework;
using DAO.DataAccess.Factory;
using SQLServer.Task6.Domain.Models;
using System;

namespace DAO.DataAccess.Singleton.Tests
{
    [TestFixture()]
    public class SingletonDboAccessTests
    {
        [Test()]
        public void GetInstanceTest()
        {
            var dbConnString = @"Data Source=LAIT-PC\SQLEXPRESS;Initial Catalog=SQLServer.Task6.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SingletonDboAccess test = SingletonDboAccess.GetInstance(new ADORepositoryFactory(dbConnString));

            //test.AbstractFactory.CreateGroups().Add(
            //    new Groups()
            //    { Name = "1" });

            //test.AbstractFactory.CreateStudents().Add(
            //    new Students() 
            //    { 
            //        LastName = "asda", DateOfBirthday =DateTime.Now, FirstName ="firs",
            //        Gender = "ASd", GroupsID = 1, MiddleName = "asd", Id = 0
            //    });


            var testGetAllGroups = test.AbstractFactory.CreateGroups().GetAll();
            var testGetAllStudents = test.AbstractFactory.CreateStudents().GetAll();
            var testGetAllSessionResults = test.AbstractFactory.CreateSessionsResults().GetAll();

            var testGetByIdGroup = test.AbstractFactory.CreateGroups().GetByID(5);

            test.AbstractFactory.CreateGroups().Update(new Groups() { Id = 2, Name = "LOL" });
            test.AbstractFactory.CreateGroups().Delete(4);

        }
    }
}