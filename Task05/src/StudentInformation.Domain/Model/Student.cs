using Version.Domain;
using System;

namespace StudentInformation.Domain.Model
{
    /// <summary>
    /// Student model.
    /// </summary>
    [Serializable]
    public class Student : Entity
    {
        /// <summary>
        /// Property SurName.
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Property FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Property MiddleName.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Property Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Property DateOfBirth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Student():base(){}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version"></param>
        public Student(ModuleVersion version):base(version){}

    }
}
