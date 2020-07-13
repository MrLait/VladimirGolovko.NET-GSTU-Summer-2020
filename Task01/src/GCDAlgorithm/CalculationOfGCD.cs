using System;

namespace GCDAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    public static class CalculationOfGCD
    {
        public static int GetEuclidGcd(int numOne, int numTwo)
        {
            int euclidGcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            return euclidGcdForTwoNumbers;
        }

        public static int GetEuclidGcd(int numOne, int numTwo, int numThree)
        {
            int euclidGcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            int euclidGcdForThreeNumbers = GetEuclidGcdForTwoNumbers(euclidGcdForTwoNumbers, numThree);
            return euclidGcdForThreeNumbers;
        }

        public static int GetEuclidGcd(int numOne, int numTwo, int numThree, int numFour)
        {
            int euclidGcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            int euclidGcdForThreeNumbers = GetEuclidGcdForTwoNumbers(euclidGcdForTwoNumbers, numThree);
            int euclidGcdForFourNumbers = GetEuclidGcdForTwoNumbers(euclidGcdForThreeNumbers, numFour);
            return euclidGcdForFourNumbers;
        }

        private static int GetEuclidGcdForTwoNumbers(int numOne, int numTwo)
        {
            while (numTwo != 0)
                numTwo = numOne % (numOne = numTwo);
            return Math.Abs(numOne);
        }

    }
}
