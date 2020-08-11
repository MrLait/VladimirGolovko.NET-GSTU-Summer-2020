using System;

namespace StudentInformation.Domain.Model
{
    /// <summary>
    /// Test resilt model.
    /// </summary>
    public class TestResults : Entity
    {
        /// <summary>
        /// Property student id.
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Property test id.
        /// </summary>
        public int TestID { get; set; }

        /// <summary>
        /// Property test data.
        /// </summary>
        public DateTime TestData { get; set; }

        /// <summary>
        /// Property value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public TestResults() : base() { }

        /// <summary>
        /// Constructor for init version
        /// </summary>
        /// <param name="version">Version parameter.</param>
        public TestResults(Version.Domain.ModuleVersion version) : base(version) { }
    }
}
