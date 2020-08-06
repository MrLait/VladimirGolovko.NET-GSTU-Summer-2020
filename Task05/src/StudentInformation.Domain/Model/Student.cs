using StudentInformation.Domain.Interfaces;
using Version.Domain;
using System;
using System.Collections.Generic;

namespace StudentInformation.Domain.Model
{
    [Serializable]
    public class Student : Entity
    {
        public ModuleVersion Version { get; set; } = new ModuleVersion(1, 2, 3, 0);

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
