using System;

namespace StudentInformation.Domain.Model
{
    public class TestResults : Entity
    {
        public int StudentID { get; set; }
        public int TestID { get; set; }
        public DateTime TestData { get; set; }
        public decimal Value { get; set; }

        public TestResults() : base() { }

        public TestResults(Version.Domain.ModuleVersion version) : base(version) { }
    }
}
