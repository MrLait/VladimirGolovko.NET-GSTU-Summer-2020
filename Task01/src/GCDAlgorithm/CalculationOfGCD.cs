using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GCDAlgorithm
{
    public static class CalculationOfGCD
    {
        public static int GetEuclidGcd(int numOne, int numTwo)
        {
            int GcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            return GcdForTwoNumbers;
        }

        private static int GetEuclidGcdForTwoNumbers(int numOne, int numTwo)
        {
            while (numTwo != 0)
                numTwo = numOne % (numOne = numTwo);
            return Math.Abs(numOne);
        }

    }
}
