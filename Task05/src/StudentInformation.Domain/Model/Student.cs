using StudentInformation.Domain.Interfaces;
using System;

namespace StudentInformation.Domain.Model
{
    public class Student : IEntity
    {
        public int ID { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
