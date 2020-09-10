using NUnit.Framework;
using System.Collections;

namespace SQLServer.Task6.PresentationTests.TestCaseSources
{
    /// <summary>
    /// Factory students to be expelled view.
    /// </summary>
    public class MyFactoryStudentsToBeExpelledViewTests
    {
        /// <summary>
        /// String implementation for session one and grade 30.
        /// </summary>
        public static readonly string SessionOneGrade30 = 
                    "StudentId; SessionName; GroupName; FirstName; LastName; MiddleName\r\n" +
                    "1; 1; PM-2; FirstName1; LastName1; Middlename1\r\n" +
                    "6; 1; PM-2; FirstName6; LastName6; Middlename6\r\n" +
                    "7; 1; PM-2; FirstName7; LastName7; Middlename7\r\n" +
                    "9; 1; PM-2; FirstName9; LastName9; Middlename9\r\n" +
                    "10; 1; PM-2; FirstName10; LastName10; Middlename10\r\n" +
                    "2; 1; PM-1; FirstName2; LastName2; Middlename2\r\n" +
                    "3; 1; PM-1; FirstName3; LastName3; Middlename3\r\n" +
                    "4; 1; PM-1; FirstName4; LastName4; Middlename4\r\n" +
                    "5; 1; PM-1; FirstName5; LastName5; Middlename5\r\n" +
                    "8; 1; PM-1; FirstName8; LastName8; Middlename8\r\n";

        /// <summary>
        /// String implementation for session one and grade 50.
        /// </summary>
        public static readonly string SessionOneGrade50 =
                    "StudentId; SessionName; GroupName; FirstName; LastName; MiddleName\r\n" +
                    "1; 1; PM-2; FirstName1; LastName1; Middlename1\r\n" +
                    "6; 1; PM-2; FirstName6; LastName6; Middlename6\r\n" +
                    "7; 1; PM-2; FirstName7; LastName7; Middlename7\r\n" +
                    "9; 1; PM-2; FirstName9; LastName9; Middlename9\r\n" +
                    "10; 1; PM-2; FirstName10; LastName10; Middlename10\r\n" +
                    "2; 1; PM-1; FirstName2; LastName2; Middlename2\r\n" +
                    "3; 1; PM-1; FirstName3; LastName3; Middlename3\r\n" +
                    "4; 1; PM-1; FirstName4; LastName4; Middlename4\r\n" +
                    "5; 1; PM-1; FirstName5; LastName5; Middlename5\r\n" +
                    "8; 1; PM-1; FirstName8; LastName8; Middlename8\r\n";

        /// <summary>
        /// String implementation for session one and grade 20 and ordered.
        /// </summary>
        public static readonly string SessionOneGrade20Ordered = 
                    "StudentId; SessionName; GroupName; FirstName; LastName; MiddleName\r\n" +
                    "2; 1; PM-1; FirstName2; LastName2; Middlename2\r\n" +
                    "3; 1; PM-1; FirstName3; LastName3; Middlename3\r\n" +
                    "4; 1; PM-1; FirstName4; LastName4; Middlename4\r\n" +
                    "5; 1; PM-1; FirstName5; LastName5; Middlename5\r\n" +
                    "8; 1; PM-1; FirstName8; LastName8; Middlename8\r\n" +
                    "1; 1; PM-2; FirstName1; LastName1; Middlename1\r\n" +
                    "6; 1; PM-2; FirstName6; LastName6; Middlename6\r\n" +
                    "7; 1; PM-2; FirstName7; LastName7; Middlename7\r\n" +
                    "10; 1; PM-2; FirstName10; LastName10; Middlename10\r\n";

        /// <summary>
        /// String implementation for session one and grade 40 and ordered.
        /// </summary>
        public static readonly string SessionOneGrade40Ordered = 
                    "StudentId; SessionName; GroupName; FirstName; LastName; MiddleName\r\n" +
                    "2; 1; PM-1; FirstName2; LastName2; Middlename2\r\n" +
                    "3; 1; PM-1; FirstName3; LastName3; Middlename3\r\n" +
                    "4; 1; PM-1; FirstName4; LastName4; Middlename4\r\n" +
                    "5; 1; PM-1; FirstName5; LastName5; Middlename5\r\n" +
                    "8; 1; PM-1; FirstName8; LastName8; Middlename8\r\n" +
                    "1; 1; PM-2; FirstName1; LastName1; Middlename1\r\n" +
                    "6; 1; PM-2; FirstName6; LastName6; Middlename6\r\n" +
                    "7; 1; PM-2; FirstName7; LastName7; Middlename7\r\n" +
                    "9; 1; PM-2; FirstName9; LastName9; Middlename9\r\n" +
                    "10; 1; PM-2; FirstName10; LastName10; Middlename10\r\n";

        /// <summary>
        /// Parameters for tests StudentsToBeExpelledView
        /// </summary>
        public static IEnumerable GiveToString_WhenNoOrdered_ThenOutIsToString
        {
            get
            {
                yield return new TestCaseData("1", 30).Returns(SessionOneGrade30);
                yield return new TestCaseData("1", 50).Returns(SessionOneGrade50);
            }
        }

        /// <summary>
        /// Parameters for tests StudentsToBeExpelledView and ordered.
        /// </summary>
        public static IEnumerable GiveToString_WhenOrderByGroupNameAndStudentId_ThenOutIsToStringOrderByGroupNameAndStudentId
        {
            get
            {
                yield return new TestCaseData("1", 20).Returns(SessionOneGrade20Ordered);
                yield return new TestCaseData("1", 40).Returns(SessionOneGrade40Ordered);
            }
        }
    }
}
