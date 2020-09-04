using NUnit.Framework;
using System.Collections;

namespace SQLServer.Task7.PresentationTests.TestCaseSources
{
    public class MyFactoryAverageScoreSubjectByYearsTests
    {
        /// <summary>
        /// String implementation for subject one.
        /// </summary>
        public static readonly string SessionOne =
            "SubjectName; Year; AverageValue;\r\n" +
            "Subject-1.0; 2018; 20;\r\n" +
            "Subject-1.0; 2019; 29,25;\r\n" +
            "Subject-1.0; 2020; 57;";

        /// <summary>
        /// String implementation for subject two.
        /// </summary>
        public static readonly string SubjectTwo =
            "SubjectName; Year; AverageValue;\r\n" +
            "Subject-2.0; 2018; 22;\r\n" +
            "Subject-2.0; 2019; 60,8333333333333;\r\n" +
            "Subject-2.0; 2020; 46,5;";

        /// <summary>
        /// Parameters for tests AverageScoreByExaminerView.
        /// </summary>
        public static IEnumerable GiveToString_ThenOutIsToString
        {
            get
            {
                yield return new TestCaseData("Subject-1.0").Returns(SessionOne);
                yield return new TestCaseData("Subject-2.0").Returns(SubjectTwo);
            }
        }
    }
}
