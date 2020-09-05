using NUnit.Framework;
using System.Collections;

namespace SQLServer.Task7.PresentationTests.TestCaseSources
{
    public class MyFactoryAverageScoreByExaminerTests
    {
        /// <summary>
        /// String implementation for session one and examiner one.
        /// </summary>
        public static readonly string SessionOneExaminerOne =
            "SessionName; FirstName; LastName; MiddleName; AverageValue\r\n" +
            "1; FirstName1; LastName1; MiddleName1; 29,8";
        /// <summary>
        /// String implementation for session one and examiner two.
        /// </summary>
        public static readonly string SessionOneExaminersTwo =
            "SessionName; FirstName; LastName; MiddleName; AverageValue\r\n" +
            "1; FirstName2; LastName2; MiddleName2; 60,8333333333333";

        /// <summary>
        /// String implementation for session two and examiner one.
        /// </summary>
        public static readonly string SessionTwoExaminerOne =
            "SessionName; FirstName; LastName; MiddleName; AverageValue\r\n" +
            "2; FirstName1; LastName1; MiddleName1; 30,3333333333333";

        /// <summary>
        /// String implementation for session two and examiner two.
        /// </summary>
        public static readonly string SessionTwoExaminerTwo =
            "SessionName; FirstName; LastName; MiddleName; AverageValue\r\n" +
            "2; FirstName2; LastName2; MiddleName2; 30,1666666666667";

        /// <summary>
        /// Parameters for tests AverageScoreByExaminerView.
        /// </summary>
        public static IEnumerable GiveToString_ThenOutIsToString
        {
            get
            {
                yield return new TestCaseData(1, "FirstName1", "LastName1", "MiddleName1").Returns(SessionOneExaminerOne);
                yield return new TestCaseData(1, "FirstName2", "LastName2", "MiddleName2").Returns(SessionOneExaminersTwo);
                yield return new TestCaseData(2, "FirstName1", "LastName1", "MiddleName1").Returns(SessionTwoExaminerOne);
                yield return new TestCaseData(2, "FirstName2", "LastName2", "MiddleName2").Returns(SessionTwoExaminerTwo);
            }
        }
    }
}
