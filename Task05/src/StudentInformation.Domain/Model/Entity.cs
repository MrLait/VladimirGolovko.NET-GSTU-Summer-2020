using System;

namespace StudentInformation.Domain.Model
{
    public class Entity : IComparable<Entity>
    {
        public int ID { get; set; }

        public int CompareTo(Entity obj)
        {
            return ID.CompareTo(obj.ID);
        }
    }
}
