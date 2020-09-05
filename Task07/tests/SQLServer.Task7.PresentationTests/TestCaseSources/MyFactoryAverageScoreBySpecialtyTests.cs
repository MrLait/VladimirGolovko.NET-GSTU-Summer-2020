using NUnit.Framework;
using System.Collections;

namespace SQLServer.Task7.PresentationTests.TestCaseSources
{
    public class MyFactoryAverageScoreBySpecialtyTests
    {
        /// <summary>
        /// String implementation for session one and specialty one.
        /// </summary>
        public static readonly string SessionOneSpecialtyOne =
            "SessionName; SpecialtyName; AverageValue\r\n" +
            "1; Specialty-1; 58,4";
        /// <summary>
        /// String implementation for session one and specialty two.
        /// </summary>
        public static readonly string SessionOneSpecialtyTwo =
            "SessionName; SpecialtyName; AverageValue\r\n" +
            "1; Specialty-2; 37";

        /// <summary>
        /// String implementation for session two and specialty one.
        /// </summary>
        public static readonly string SessionTwoSpecialtyOne =
            "SessionName; SpecialtyName; AverageValue\r\n" +
            "2; Specialty-1; 51,75";

        /// <summary>
        /// String implementation for session two and specialty two.
        /// </summary>
        public static readonly string SessionTwoSpecialtyTwo =
            "SessionName; SpecialtyName; AverageValue\r\n" +
            "2; Specialty-2; 19,5";

        /// <summary>
        /// Parameters for tests AverageScoreByExaminerView.
        /// </summary>
        public static IEnumerable GiveToString_ThenOutIsToString
        {
            get
            {
                yield return new TestCaseData(1, "Specialty-1").Returns(SessionOneSpecialtyOne);
                yield return new TestCaseData(1, "Specialty-2").Returns(SessionOneSpecialtyTwo);
                yield return new TestCaseData(2, "Specialty-1").Returns(SessionTwoSpecialtyOne);
                yield return new TestCaseData(2, "Specialty-2").Returns(SessionTwoSpecialtyTwo);
            }
        }
    }
}
