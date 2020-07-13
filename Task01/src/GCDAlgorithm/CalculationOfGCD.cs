using System;
using System.Diagnostics;

namespace GCDAlgorithm
{
    /// <summary>
    /// Static class, which includes a set of methods for calculating the GCD.
    /// </summary>
    public static class CalculationOfGCD
    {
        /// <summary>
        /// Minimum number of parameters for building a histogram.
        /// </summary>
        public const int MinGcdNum = 2;

        /// <summary>
        /// Maximum number of parameters for building a histogram.
        /// </summary>
        public const int MaxGcdNum = 4;

        /// <summary>
        /// The method calculates the GCD in a Euclid way for four two. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="totalMs">The time taken to execute the method in milliseconds.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GetEuclidGcd(int numOne, int numTwo, out double totalMs)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int euclidGcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            stopwatch.Stop();

            totalMs = stopwatch.Elapsed.TotalMilliseconds;
            
            return euclidGcdForTwoNumbers;
        }

        /// <summary>
        /// The method calculates the GCD in a Euclid way for four three. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="totalMs">The time taken to execute the method in milliseconds.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GetEuclidGcd(int numOne, int numTwo, int numThree, out double totalMs)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int euclidGcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            int euclidGcdForThreeNumbers = GetEuclidGcdForTwoNumbers(euclidGcdForTwoNumbers, numThree);

            totalMs = stopwatch.Elapsed.TotalMilliseconds;

            return euclidGcdForThreeNumbers;
        }

        /// <summary>
        /// The method calculates the GCD in a Euclid way for four parameters. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="totalMs">The time taken to execute the method in milliseconds.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GetEuclidGcd(int numOne, int numTwo, int numThree, int numFour, out double totalMs)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int euclidGcdForTwoNumbers = GetEuclidGcdForTwoNumbers(numOne, numTwo);
            int euclidGcdForThreeNumbers = GetEuclidGcdForTwoNumbers(euclidGcdForTwoNumbers, numThree);
            int euclidGcdForFourNumbers = GetEuclidGcdForTwoNumbers(euclidGcdForThreeNumbers, numFour);
           
            totalMs = stopwatch.Elapsed.TotalMilliseconds;

            return euclidGcdForFourNumbers;
        }

        /// <summary>
        /// The method calculates the GCD in a Binary way for two parameters. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="totalMs">The time taken to execute the method in milliseconds.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GetBinaryGcd(int numOne, int numTwo, out double totalMs)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int binaryGcdForTwoNum = GetBinaryGcdForTwoNum(numOne, numTwo);

            totalMs = stopwatch.Elapsed.TotalMilliseconds;

            return binaryGcdForTwoNum;
        }

        /// <summary>
        /// The method calculates the GCD in a Binary way for three parameters. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="totalMs">The time taken to execute the method in milliseconds.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GetBinaryGcd(int numOne, int numTwo, int numThree, out double totalMs)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int binaryGcdForTwoNum = GetBinaryGcdForTwoNum(numOne, numTwo);
            int binaryGcdForThreeNum = GetBinaryGcdForTwoNum(binaryGcdForTwoNum, numThree);

            totalMs = stopwatch.Elapsed.TotalMilliseconds;

            return binaryGcdForThreeNum;
        }

        /// <summary>
        /// The method calculates the GCD in a Binary way for four parameters. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="totalMs">The time taken to execute the method in milliseconds.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GetBinaryGcd(int numOne, int numTwo, int numThree, int numFour, out double totalMs)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int binaryGcdForTwoNum = GetBinaryGcdForTwoNum(numOne, numTwo);
            int binaryGcdForThreeNum = GetBinaryGcdForTwoNum(binaryGcdForTwoNum, numThree);
            int binaryGcdForFourNum = GetBinaryGcdForTwoNum(binaryGcdForThreeNum, numFour);

            totalMs = stopwatch.Elapsed.TotalMilliseconds;

            return binaryGcdForFourNum;
        }

        /// <summary>
        /// Method preparing data for building histograms.
        /// </summary>
        /// <param name="numbers">Parameters for calculating the GCD. The minimum number of parameters is two, and the maximum is 4.</param>
        /// <returns>Returns a boolean expression. Where: true is prepared; false isn't prepeared.</returns>
        public static bool PrepareDataForHistogram(params Int32[] numbers)
        {
            double totalMsForEuclidGcd;
            double totalMsForBinaryGcd;
            bool isPrepeared = false;

            if (numbers != null & numbers.Length >= MinGcdNum & numbers.Length <= MaxGcdNum)
            {
                string s = $"{"Euclid",45} {"Binary",11}" + Environment.NewLine;

                for (int i = MinGcdNum; i <= numbers.Length; i++)
                {
                    string numParams = $"Number of Gcd parameters: {i.ToString() }";

                    if (i == MinGcdNum)
                    {
                        GetEuclidGcd(numbers[0], numbers[1], out totalMsForEuclidGcd);
                        GetBinaryGcd(numbers[0], numbers[1], out totalMsForBinaryGcd);
                        s += $"{numParams};{totalMsForEuclidGcd,7:N4} ms {totalMsForBinaryGcd, 7:N4} ms" + Environment.NewLine;
                    }
                    else if (i == 3)
                    {
                        GetEuclidGcd(numbers[0], numbers[1], numbers[2], out totalMsForEuclidGcd);
                        GetBinaryGcd(numbers[0], numbers[1], numbers[2], out totalMsForBinaryGcd);
                        s += $"{numParams};{totalMsForEuclidGcd,7:N4} ms {totalMsForBinaryGcd, 7:N4} ms" + Environment.NewLine;
                    }
                    else if (i == MaxGcdNum)
                    {
                        GetEuclidGcd(numbers[0], numbers[1], numbers[2], numbers[3], out totalMsForEuclidGcd);
                        GetBinaryGcd(numbers[0], numbers[1], numbers[2], numbers[3], out totalMsForBinaryGcd);
                        s += $"{numParams};{totalMsForEuclidGcd,7:N4} ms {totalMsForBinaryGcd, 7:N4} ms";
                    }
                }

                isPrepeared = true;
            }

            return isPrepeared;
        }

        /// <summary>
        /// The method calculates the GCD in a Euclid way for four two. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        private static int GetEuclidGcdForTwoNumbers(int numOne, int numTwo)
        {
            while (numTwo != 0)
                numTwo = numOne % (numOne = numTwo);
            return Math.Abs(numOne);
        }

        /// <summary>
        /// The method calculates the GCD in a Binary way for four two. 
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <returns>The greatest common divisor.</returns>
        private static int GetBinaryGcdForTwoNum(int numOne, int numTwo)
        {
            numOne = Math.Abs(numOne);
            numTwo = Math.Abs(numTwo);

            if (numOne == 0)
                return numTwo;

            if (numTwo == 0)
                return numOne;

            int k;

            for (k = 0; ((numOne | numTwo) & 1) == 0; ++k)
            {
                numOne >>= 1;
                numTwo >>= 1;
            }

            while ((numOne & 1) == 0)
                numOne >>= 1;
            do
            {
                while ((numTwo & 1) == 0)
                    numTwo >>= 1;
                if (numOne > numTwo)
                {
                    int temp = numOne;
                    numOne = numTwo;
                    numTwo = temp;
                }
                numTwo = (numTwo - numOne);
            } 
            while (numTwo != 0);

            return numOne << k;
        }

    }
}
