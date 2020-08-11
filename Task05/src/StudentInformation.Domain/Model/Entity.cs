using InterfaceMarkers;
using System;
using Version.Domain;

namespace StudentInformation.Domain.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class Entity : IComparable, ISerialize
    {
        /// <summary>
        /// Property ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Property Version.
        /// </summary>
        public ModuleVersion Version { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Entity() => Version = new ModuleVersion(1, 0, 0, 0);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version"></param>
        public Entity(ModuleVersion version) : this() => Version = version;

        /// <summary>
        /// CompareTo
        /// </summary>
        /// <param name="obj">obj</param>
        /// <returns>int</returns>
        public int CompareTo(object obj)
        {
            if (obj is Entity item)
                return ID.CompareTo(item.ID);
            else
                throw new ArgumentNullException("Types do not match");
        }

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
