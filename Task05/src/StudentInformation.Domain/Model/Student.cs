using StudentInformation.Domain.Interfaces;
using Version.Domain;
using System;

namespace StudentInformation.Domain.Model
{
    [Serializable]
    public class Student : IEntity, IComparable<Student>
    {
        public ModuleVersion Version = new ModuleVersion(1, 2, 3, 0);

        public int ID { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CompareTo(Student obj)
        {
            return ID.CompareTo(obj.ID);
        }

        public Student()
        {
            //Version = new Version(1,1,1);
        }

        //public int CompareTo(object obj)
        //{
        //    return ID.CompareTo(obj);
        //}
    }
}
