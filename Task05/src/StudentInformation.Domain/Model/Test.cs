using StudentInformation.Domain.Interfaces;
using System;

namespace StudentInformation.Domain.Model
{
    public class Test : IEntity
    {
        public int ID { get; set; }

        public string TestName { get; set; }
    }
}
