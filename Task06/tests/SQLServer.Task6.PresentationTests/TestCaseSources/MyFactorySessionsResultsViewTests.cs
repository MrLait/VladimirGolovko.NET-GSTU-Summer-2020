using NUnit.Framework;
using System.Collections;

namespace SQLServer.Task6.PresentationTests.TestCaseSources
{
    /// <summary>
    /// Factory sessions results view.
    /// </summary>
    public class MyFactorySessionsResultsViewTests
    {
        /// <summary>
        /// String implementation for session one group PM-1 and no ordered.
        /// </summary>
        public static readonly string SessionOneGroupPM_1_NoOrdered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "1; PM-1; FirstName2; LastName2; Middlename2; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; 97\r\n" +
            "1; PM-1; FirstName3; LastName3; Middlename3; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName3; LastName3; Middlename3; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName3; LastName3; Middlename3; Subject-2.0; 71\r\n" +
            "1; PM-1; FirstName4; LastName4; Middlename4; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; 65\r\n" +
            "1; PM-1; FirstName5; LastName5; Middlename5; Subject-1.0; Offset\r\n" +
            "1; PM-1; FirstName5; LastName5; Middlename5; Subject-1.0; 32\r\n" +
            "1; PM-1; FirstName5; LastName5; Middlename5; Subject-2.0; NotOffset\r\n" +
            "1; PM-1; FirstName8; LastName8; Middlename8; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName8; LastName8; Middlename8; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName8; LastName8; Middlename8; Subject-2.0; 27";

        /// <summary>
        /// String implementation for session one group PM-2 and no ordered.
        /// </summary>
        public static readonly string SessionOneGroupPM_2_NoOrdered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "1; PM-2; FirstName1; LastName1; Middlename1; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName1; LastName1; Middlename1; Subject-1.0; 58\r\n" +
            "1; PM-2; FirstName1; LastName1; Middlename1; Subject-2.0; NotOffset\r\n" +
            "1; PM-2; FirstName6; LastName6; Middlename6; Subject-1.0; NotOffset\r\n" +
            "1; PM-2; FirstName6; LastName6; Middlename6; Subject-2.0; NotOffset\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; 16\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; Offset\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; 64\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; 27\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-2.0; Offset\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-2.0; 41\r\n" +
            "1; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; 16\r\n" +
            "1; PM-2; FirstName10; LastName10; Middlename10; Subject-2.0; NotOffset";

        /// <summary>
        /// String implementation for session two group PM-1 and no ordered.
        /// </summary>
        public static readonly string SessionTwoGroupPM_1_NoOrdered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "2; PM-1; FirstName2; LastName2; Middlename2; Subject-1.0; NotOffset\r\n" +
            "2; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; Offset\r\n" +
            "2; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; 90\r\n" +
            "2; PM-1; FirstName3; LastName3; Middlename3; Subject-1.0; NotOffset\r\n" +
            "2; PM-1; FirstName3; LastName3; Middlename3; Subject-2.0; NotOffset\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-1.0; Offset\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-1.0; 94\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; Offset\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; 3\r\n" +
            "2; PM-1; FirstName5; LastName5; Middlename5; Subject-1.0; NotOffset\r\n" +
            "2; PM-1; FirstName5; LastName5; Middlename5; Subject-2.0; NotOffset\r\n" +
            "2; PM-1; FirstName8; LastName8; Middlename8; Subject-1.0; Offset\r\n" +
            "2; PM-1; FirstName8; LastName8; Middlename8; Subject-1.0; 20\r\n" +
            "2; PM-1; FirstName8; LastName8; Middlename8; Subject-2.0; NotOffset";
        /// <summary>
        /// String implementation for session two group PM-2 and no ordered.
        /// </summary>
        public static readonly string SessionTwoGroupPM_2_NoOrdered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "2; PM-2; FirstName1; LastName1; Middlename1; Subject-1.0; NotOffset\r\n" +
            "2; PM-2; FirstName1; LastName1; Middlename1; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName1; LastName1; Middlename1; Subject-2.0; 33\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-1.0; 19\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-2.0; 5\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; 16\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; 38\r\n" +
            "2; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; 20\r\n" +
            "2; PM-2; FirstName9; LastName9; Middlename9; Subject-2.0; NotOffset\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; 13\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-2.0; 12";

        /// <summary>
        /// String implementation for session one group PM-1 and ordered.
        /// </summary>
        public static readonly string SessionOneGroupPM_1_Ordered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "1; PM-1; FirstName8; LastName8; Middlename8; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName8; LastName8; Middlename8; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName8; LastName8; Middlename8; Subject-2.0; 27\r\n" +
            "1; PM-1; FirstName5; LastName5; Middlename5; Subject-1.0; Offset\r\n" +
            "1; PM-1; FirstName5; LastName5; Middlename5; Subject-2.0; NotOffset\r\n" +
            "1; PM-1; FirstName5; LastName5; Middlename5; Subject-1.0; 32\r\n" +
            "1; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName4; LastName4; Middlename4; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; 65\r\n" +
            "1; PM-1; FirstName3; LastName3; Middlename3; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName3; LastName3; Middlename3; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName3; LastName3; Middlename3; Subject-2.0; 71\r\n" +
            "1; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; Offset\r\n" +
            "1; PM-1; FirstName2; LastName2; Middlename2; Subject-1.0; NotOffset\r\n" +
            "1; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; 97";

        /// <summary>
        /// String implementation for session one group PM-2 and ordered.
        /// </summary>
        public static readonly string SessionOneGroupPM_2_Ordered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-2.0; Offset\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-2.0; 41\r\n" +
            "1; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; 27\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; Offset\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; 64\r\n" +
            "1; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; 16\r\n" +
            "1; PM-2; FirstName6; LastName6; Middlename6; Subject-1.0; NotOffset\r\n" +
            "1; PM-2; FirstName6; LastName6; Middlename6; Subject-2.0; NotOffset\r\n" +
            "1; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName10; LastName10; Middlename10; Subject-2.0; NotOffset\r\n" +
            "1; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; 16\r\n" +
            "1; PM-2; FirstName1; LastName1; Middlename1; Subject-1.0; Offset\r\n" +
            "1; PM-2; FirstName1; LastName1; Middlename1; Subject-2.0; NotOffset\r\n" +
            "1; PM-2; FirstName1; LastName1; Middlename1; Subject-1.0; 58";

        /// <summary>
        /// String implementation for session two group PM-1 and ordered.
        /// </summary>
        public static readonly string SessionTwoGroupPM_1_Ordered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "2; PM-1; FirstName8; LastName8; Middlename8; Subject-1.0; Offset\r\n" +
            "2; PM-1; FirstName8; LastName8; Middlename8; Subject-2.0; NotOffset\r\n" +
            "2; PM-1; FirstName8; LastName8; Middlename8; Subject-1.0; 20\r\n" +
            "2; PM-1; FirstName5; LastName5; Middlename5; Subject-1.0; NotOffset\r\n" +
            "2; PM-1; FirstName5; LastName5; Middlename5; Subject-2.0; NotOffset\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-1.0; Offset\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; Offset\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-1.0; 94\r\n" +
            "2; PM-1; FirstName4; LastName4; Middlename4; Subject-2.0; 3\r\n" +
            "2; PM-1; FirstName3; LastName3; Middlename3; Subject-1.0; NotOffset\r\n" +
            "2; PM-1; FirstName3; LastName3; Middlename3; Subject-2.0; NotOffset\r\n" +
            "2; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; Offset\r\n" +
            "2; PM-1; FirstName2; LastName2; Middlename2; Subject-1.0; NotOffset\r\n" +
            "2; PM-1; FirstName2; LastName2; Middlename2; Subject-2.0; 90";

        /// <summary>
        /// String implementation for session two group PM-2 and ordered.
        /// </summary>
        public static readonly string SessionTwoGroupPM_2_Ordered =
            "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value\r\n" +
            "2; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName9; LastName9; Middlename9; Subject-2.0; NotOffset\r\n" +
            "2; PM-2; FirstName9; LastName9; Middlename9; Subject-1.0; 20\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-2.0; 38\r\n" +
            "2; PM-2; FirstName7; LastName7; Middlename7; Subject-1.0; 16\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-2.0; 5\r\n" +
            "2; PM-2; FirstName6; LastName6; Middlename6; Subject-1.0; 19\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; Offset\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-1.0; 13\r\n" +
            "2; PM-2; FirstName10; LastName10; Middlename10; Subject-2.0; 12\r\n" +
            "2; PM-2; FirstName1; LastName1; Middlename1; Subject-2.0; Offset\r\n" +
            "2; PM-2; FirstName1; LastName1; Middlename1; Subject-1.0; NotOffset\r\n" +
            "2; PM-2; FirstName1; LastName1; Middlename1; Subject-2.0; 33";

        /// <summary>
        /// Parameters for tests MyFactorySessionsResultsView
        /// </summary>
        public static IEnumerable GiveToString_WhenNoOrdered_ThenOutIsToString
        {
            get
            {
                yield return new TestCaseData("1", "PM-1").Returns(SessionOneGroupPM_1_NoOrdered);
                yield return new TestCaseData("1", "PM-2").Returns(SessionOneGroupPM_2_NoOrdered);
                yield return new TestCaseData("2", "PM-1").Returns(SessionTwoGroupPM_1_NoOrdered);
                yield return new TestCaseData("2", "PM-2").Returns(SessionTwoGroupPM_2_NoOrdered);
            }
        }

        /// <summary>
        /// Parameters for tests MyFactorySessionsResultsView and ordered.
        /// </summary>
        public static IEnumerable GiveToString_WhenOrderByDescendingFirstNameAndValue_ThenOutIsToStringOrderBy
        {
            get
            {
                yield return new TestCaseData("1", "PM-1").Returns(SessionOneGroupPM_1_Ordered);
                yield return new TestCaseData("1", "PM-2").Returns(SessionOneGroupPM_2_Ordered);
                yield return new TestCaseData("2", "PM-1").Returns(SessionTwoGroupPM_1_Ordered);
                yield return new TestCaseData("2", "PM-2").Returns(SessionTwoGroupPM_2_Ordered);
            }
        }
    }
}
