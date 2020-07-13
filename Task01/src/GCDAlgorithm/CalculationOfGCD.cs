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

        public static int GetBinaryGcd(int numOne, int numTwo)
        {
            int binaryGcdForTwoNum = GetBinaryGcdForTwoNum(numOne, numTwo);
            return binaryGcdForTwoNum;
        }

        public static int GetBinaryGcd(int numOne, int numTwo, int numThree)
        {
            int binaryGcdForTwoNum = GetBinaryGcdForTwoNum(numOne, numTwo);
            int binaryGcdForThreeNum = GetBinaryGcdForTwoNum(binaryGcdForTwoNum, numThree);
            return binaryGcdForThreeNum;
        }

        public static int GetBinaryGcd(int numOne, int numTwo, int numThree, int numFour)
        {
            int binaryGcdForTwoNum = GetBinaryGcdForTwoNum(numOne, numTwo);
            int binaryGcdForThreeNum = GetBinaryGcdForTwoNum(binaryGcdForTwoNum, numThree);
            int binaryGcdForFourNum = GetBinaryGcdForTwoNum(binaryGcdForThreeNum, numFour);
            return binaryGcdForFourNum;
        }

        private static int GetBinaryGcdForTwoNum(int numbOne, int numbTwo)
        {
            numbOne = Math.Abs(numbOne);
            numbTwo = Math.Abs(numbTwo);

            if (numbOne == 0)
                return numbTwo;

            if (numbTwo == 0)
                return numbOne;

            int k;

            for (k = 0; ((numbOne | numbTwo) & 1) == 0; ++k)
            {
                numbOne >>= 1;
                numbTwo >>= 1;
            }

            while ((numbOne & 1) == 0)
                numbOne >>= 1;
            do
            {
                while ((numbTwo & 1) == 0)
                    numbTwo >>= 1;
                if (numbOne > numbTwo)
                {
                    int temp = numbOne;
                    numbOne = numbTwo;
                    numbTwo = temp;
                }
                numbTwo = (numbTwo - numbOne);
            } 
            while (numbTwo != 0);

            return numbOne << k;
        }

    }
}
