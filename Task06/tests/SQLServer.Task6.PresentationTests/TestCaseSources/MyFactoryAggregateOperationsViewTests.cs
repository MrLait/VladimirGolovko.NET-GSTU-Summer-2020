using NUnit.Framework;
using System.Collections;

namespace SQLServer.Task6.PresentationTests.TestCaseSources
{
    public class MyFactoryAggregateOperationsViewTests
    {
        public static readonly string SessionOneGroupPM_1 =
            "SessionName; GroupName; AverageValue; MaxValue; MinValue\r\n" +
            "1; PM-1; 58,4; 97; 27";

        public static readonly string SessionOneGroupPM_2 =
            "SessionName; GroupName; AverageValue; MaxValue; MinValue\r\n" +
            "1; PM-2; 37; 64; 16";

        public static readonly string SessionTwoGroupPM_1 = 
            "SessionName; GroupName; AverageValue; MaxValue; MinValue\r\n" +
            "2; PM-1; 51,75; 94; 3";

        public static readonly string SessionTwoGroupPM_2 = 
            "SessionName; GroupName; AverageValue; MaxValue; MinValue\r\n" +
            "2; PM-2; 19,5; 38; 5";


        public static IEnumerable GiveToString_ThenOutIsToString
        {
            get
            {
                yield return new TestCaseData("1", "PM-1").Returns(SessionOneGroupPM_1);
                yield return new TestCaseData("1", "PM-2").Returns(SessionOneGroupPM_2);
                yield return new TestCaseData("2", "PM-1").Returns(SessionTwoGroupPM_1);
                yield return new TestCaseData("2", "PM-2").Returns(SessionTwoGroupPM_2);
            }
        }
    }
}
