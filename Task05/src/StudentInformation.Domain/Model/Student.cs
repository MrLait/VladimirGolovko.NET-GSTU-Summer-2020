using Version.Domain;
using System;

namespace StudentInformation.Domain.Model
{
    [Serializable]
    public class Student : Entity
    {
        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Student():base(){}

        public Student(ModuleVersion version):base(version){}

    }
}
