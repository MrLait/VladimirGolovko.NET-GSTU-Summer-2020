using StudentInformation.Domain.Interfaces;
using System;

namespace StudentInformation.Domain.Model
{
    public class TestResults : Entity
    {
        public int StudentID { get; set; }
        public int TestID { get; set; }
        public DateTime TestData { get; set; }
        public decimal Value { get; set; }
    }
}
