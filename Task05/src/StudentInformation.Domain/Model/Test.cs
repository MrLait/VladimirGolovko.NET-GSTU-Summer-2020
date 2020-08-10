namespace StudentInformation.Domain.Model
{
    public class Test : Entity
    {
        public string TestName { get; set; }

        public Test() : base() { }

        public Test(Version.Domain.ModuleVersion version) : base(version) { }
    }
}
