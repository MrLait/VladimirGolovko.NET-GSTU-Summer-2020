using System;
using Version.Domain;

namespace StudentInformation.Domain.Model
{
    public abstract class Entity : IComparable<Entity>
    {
        public int ID { get; set; }
      
        public ModuleVersion Version { get; set; }

        public Entity() => Version = new ModuleVersion(1, 0, 0, 0);

        public Entity(ModuleVersion version) : this() => Version = version;

        public int CompareTo(Entity obj) => ID.CompareTo(obj.ID);

        /// <summary>
        /// Comparing one StudentTestResultRepository with another.
        /// </summary>
        /// <param name="obj">The compared StudentTestResultRepository.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Entity x = (Entity)obj;
            return ID.Equals(x.ID);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode() => ID.GetHashCode();


    }
}
