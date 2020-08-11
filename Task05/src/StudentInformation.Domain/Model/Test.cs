namespace StudentInformation.Domain.Model
{
    /// <summary>
    /// Test model.
    /// </summary>
    public class Test : Entity
    {
        /// <summary>
        /// Property test name.
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Constructor wothout parameters.
        /// </summary>
        public Test() : base() { }

        /// <summary>
        /// Constructor with version.
        /// </summary>
        /// <param name="version"></param>
        public Test(Version.Domain.ModuleVersion version) : base(version) { }
    }
}
