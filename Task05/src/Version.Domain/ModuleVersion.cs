using System;
using System.Globalization;
namespace Version.Domain
{
    /// <summary>
    /// Serializable version of the System.Version class.
    /// </summary>
    [Serializable]
    public class ModuleVersion : ICloneable, IComparable
    {
        /// <summary>
        /// Gets the major.
        /// </summary>
        /// <value></value>
        public int Major { get; set; }

        /// <summary>
        /// Gets the minor.
        /// </summary>
        /// <value></value>
        public int Minor { get; set; }

        /// <summary>
        /// Gets the build.
        /// </summary>
        /// <value></value>
        public int Build { get; set; }
        
        /// <summary>
        /// Gets the revision.
        /// </summary>
        /// <value></value>
        public int Revision { get; set; }
        
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        public ModuleVersion()
        {
            Build = -1;
            Revision = -1;
            Major = 0;
            Minor = 0;
        }
        
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="version">Version.</param>
        public ModuleVersion(string version)
        {
            Build = -1;
            Revision = -1;
            if (version == null)
                throw new ArgumentNullException("version");
            
            char[] chArray1 = new char[1] { '.' };
            string[] textArray1 = version.Split(chArray1);
            int num1 = textArray1.Length;
            if ((num1 < 2) || (num1 > 4))
                throw new ArgumentException("Arg_VersionString");
            
            Major = int.Parse(textArray1[0], CultureInfo.InvariantCulture);
            if (Major < 0)
                throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
            
            Minor = int.Parse(textArray1[1], CultureInfo.InvariantCulture);
            if (Minor < 0)
                throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
            
            num1 -= 2;
            if (num1 > 0)
            {
                Build = int.Parse(textArray1[2], CultureInfo.InvariantCulture);
                if (Build < 0)
                    throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
                num1--;
                if (num1 > 0)
                {
                    Revision = int.Parse(textArray1[3], CultureInfo.InvariantCulture);
                    if (Revision < 0)
                        throw new ArgumentOutOfRangeException("revision", "ArgumentOutOfRange_Version");
                }
            }
        }
        
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        public ModuleVersion(int major, int minor)
        {
            Build = -1;
            Revision = -1;
            if (major < 0)
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            if (minor < 0)
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            
            Major = major;
            Minor = minor;
            Major = major;
        }
        
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        public ModuleVersion(int major, int minor, int build)
        {
            Build = -1;
            Revision = -1;
            
            if (major < 0)
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            if (minor < 0)
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            if (build < 0)
                throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
            
            Major = major;
            Minor = minor;
            Build = build;
        }
        
        /// <summary>
        /// Creates a new <see cref="ModuleVersion"/> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        /// <param name="revision">Revision.</param>
        public ModuleVersion(int major, int minor, int build, int revision)
        {
            Build = -1;
            Revision = -1;
            
            if (major < 0)
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            if (minor < 0)
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            if (build < 0)
                throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
            if (revision < 0)
                throw new ArgumentOutOfRangeException("revision", "ArgumentOutOfRange_Version");
            
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }
       
        #region ICloneable Members
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            ModuleVersion version1 = new ModuleVersion();
            version1.Major = Major;
            version1.Minor = Minor;
            version1.Build = Build;
            version1.Revision = Revision;
            return version1;
        }
        #endregion
        
        #region IComparable Members
        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="obj">Obj.</param>
        /// <returns></returns>
        public int CompareTo(object version)
        {
            if (version == null)
                return 1;
            if (!(version is ModuleVersion))
                throw new ArgumentException("Arg_MustBeVersion");
            ModuleVersion version1 = (ModuleVersion)version;
            if (Major != version1.Major)
            {
                if (Major > version1.Major)
                    return 1;
                return -1;
            }
            if (Minor != version1.Minor)
            {
                if (Minor > version1.Minor)
                    return 1;
                return -1;
            }
            if (Build != version1.Build)
            {
                if (Build > version1.Build)
                    return 1;
                return -1;
            }
            if (Revision == version1.Revision)
                return 0;
            if (Revision > version1.Revision)
                return 1;
            return -1;
        }
        #endregion
        
        /// <summary>
        /// Equalss the specified obj.
        /// </summary>
        /// <param name="obj">Obj.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is ModuleVersion))
                return false;
            ModuleVersion version1 = (ModuleVersion)obj;
            if (((Major == version1.Major) && (Minor == version1.Minor)) && (Build == version1.Build) && (Revision == version1.Revision))
                return true;
            return false;
        }
        
        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int num1 = 0;
            num1 |= ((Major & 15) << 0x1c);
            num1 |= ((Minor & 0xff) << 20);
            num1 |= ((Build & 0xff) << 12);
            return (num1 | Revision & 0xfff);
        }
        
        /// <summary>
        /// Operator ==s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator ==(ModuleVersion v1, ModuleVersion v2) => v1.Equals(v2);
        
        /// <summary>
        /// Operator &gt;s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator >(ModuleVersion v1, ModuleVersion v2) => (v2 < v1);

        /// <summary>
        /// Operator &gt;=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator >=(ModuleVersion v1, ModuleVersion v2) => (v2 <= v1);

        /// <summary>
        /// Operator !=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator !=(ModuleVersion v1, ModuleVersion v2) => (v1 != v2);

        /// <summary>
        /// Operator &lt;s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator <(ModuleVersion v1, ModuleVersion v2)
        {
            if (v1 == null)
                throw new ArgumentNullException("v1");
            return (v1.CompareTo(v2) < 0);
        }
        
        /// <summary>
        /// Operator &lt;=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator <=(ModuleVersion v1, ModuleVersion v2)
        {
            if (v1 == null)
                throw new ArgumentNullException("v1");
            return (v1.CompareTo(v2) <= 0);
        }
        
        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Build == -1)
                return ToString(2);
            if (Revision == -1)
                return ToString(3);
            return ToString(4);
        }
        
        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <param name="fieldCount">Field count.</param>
        /// <returns></returns>
        public string ToString(int fieldCount)
        {
            object[] objArray1;
            switch (fieldCount)
            {
                case 0: return string.Empty;
                case 1: return (Major.ToString());
                case 2: return (Major.ToString() + "." + Minor.ToString());
            }
            if (Build == -1)
                throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "2"), "fieldCount");
            if (fieldCount == 3)
            {
                objArray1 = new object[5] { Major, ".", Minor, ".", Build };
                return string.Concat(objArray1);
            }
            if (Revision == -1)
                throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "3"), "fieldCount");
            if (fieldCount == 4)
            {
                objArray1 = new object[7] { Major, ".", Minor, ".", Build, ".", Revision };
                return string.Concat(objArray1);
            }
            throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "4"), "fieldCount");
        }
    }
}
