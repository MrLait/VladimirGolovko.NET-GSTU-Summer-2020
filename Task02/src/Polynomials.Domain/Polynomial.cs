using System;

namespace Polynomials.Domain
{
    /// <summary>
    /// Class polynomial with overloading opertors.
    /// </summary>
    public class Polynomial
    {
        private readonly double[] _elements;

        /// <summary>
        /// Elements arraay.
        /// </summary>
        public double[] Elements => _elements;

        /// <summary>
        /// Quotient elements array.
        /// </summary>
        public double[] QuotientElements { get; }

        /// <summary>
        /// Remainder elements array.
        /// </summary>
        public double[] RemainderElements { get; }

        /// <summary>
        /// Constructor for initializing polynomial elements.
        /// The array element index is the degree of the polynomial.
        /// </summary>
        /// <param name="elements">Elements of the polynomial.</param>
        public Polynomial(double[] elements)
        {
            _elements = elements;
        }

        /// <summary>
        /// Constructor for initializing polynomial elements in quotient remainder format.
        /// The array element index is the degree of the polynomial.
        /// </summary>
        /// <param name="quotientElements">Quotient elements of the polynomial.</param>
        /// <param name="remainderElements">Remainder elements of the polynomial.</param>
        public Polynomial(double[] quotientElements, double[] remainderElements)
        {
            QuotientElements = quotientElements;
            RemainderElements = remainderElements;
        }

        /// <summary>
        /// Access polynomial elements by index.
        /// Where the index number is the degree of the polynomial.
        /// </summary>
        /// <param name="i">Polynomial index.</param>
        /// <returns>The element with a given index.</returns>
        public double this[int i]
        {
            get
            {
                if (i <= _elements.Length)
                    return _elements[i];
                else
                    throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// The method of dividing a polynomial into a polynomial.
        /// Where polynomial index is degree.
        /// </summary>
        /// <param name="dividend">Parameters of a divisible polynomial.</param>
        /// <param name="divider">Polynomial divisor coefficients.</param>
        /// <returns>Returns the new polynomial in the quotient remainder format.</returns>
        public static Polynomial operator /(Polynomial dividend, Polynomial divider)
        {
            if (dividend == null)
                throw new ArgumentNullException();
            if (divider == null)
                throw new ArgumentNullException();

            double[] numDividendElements = dividend.Elements;
            double[] numDividerElements = divider.Elements;

            if (dividend.Elements.Length < divider.Elements.Length)
                throw new ArithmeticException("The degree of the divisor must be less than or equal" +
                    " to the degree of the dividend!");
            if (dividend.Elements[dividend.Elements.Length - 1] == 0
                | divider.Elements[divider.Elements.Length - 1] == 0)
            {
                throw new ArgumentException("The Last Polynomial parameters can't be is zero");
            }

            var quotientElementsLength = numDividendElements.Length - numDividerElements.Length + 1;
            double[] quotientElements = new double[quotientElementsLength];
            double[] remainderElements = dividend.Elements;
            double coeff;

            for (int i = 0; i < quotientElements.Length; i++)
            {
                coeff = remainderElements[numDividendElements.Length - i - 1] / numDividerElements[numDividerElements.Length - 1];
                quotientElements[quotientElements.Length - 1 - i] = coeff;

                for (int j = 0; j < numDividerElements.Length; j++)
                {
                    remainderElements[numDividendElements.Length - 1 - i - j] = remainderElements[numDividendElements.Length - 1 - i - j]
                        - numDividerElements[numDividerElements.Length - 1 - j] * coeff;
                }
            }

            return new Polynomial(quotientElements, remainderElements);
        }

        /// <summary>
        /// The method of multiplication a polynomial into a polynomial.
        /// Where polynomial index is degree.
        /// </summary>
        /// <param name="polynomialOne">Elements of the polynomial one.</param>
        /// <param name="polynomialTwo">Elements of the polynomial two.</param>
        /// <returns>Returns the new polynomial.</returns>
        public static Polynomial operator *(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            if (polynomialOne == null)
                throw new ArgumentNullException();
            if (polynomialTwo == null)
                throw new ArgumentNullException();

            double[] multPolynomialsResult = new double[polynomialOne.Elements.Length + polynomialTwo.Elements.Length - 1];

            for (int i = 0; i < polynomialOne.Elements.Length; i++)
            {
                for (int j = 0; j < polynomialTwo.Elements.Length; j++)
                {
                    multPolynomialsResult[i + j] += polynomialOne.Elements[i] * polynomialTwo.Elements[j];
                }
            }

            return new Polynomial(multPolynomialsResult);
        }

        /// <summary>
        /// Method for summing a polynomial into a polynomial.
        /// Where polynomial index is degree.
        /// </summary>
        /// <param name="polynomialOne">Elements of the polynomial one.</param>
        /// <param name="polynomialTwo">Elements of the polynomial two.</param>
        /// <returns>Returns the new polynomial.</returns>
        public static Polynomial operator +(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            if (polynomialOne == null)
                throw new ArgumentNullException();
            if (polynomialTwo == null)
                throw new ArgumentNullException();

            double[] sumPolynomialResult = polynomialOne.Elements.Length >= polynomialTwo.Elements.Length
                ? polynomialOne.Elements
                : polynomialTwo.Elements;

            if (polynomialOne.Elements.Length >= polynomialTwo.Elements.Length)
                sumPolynomialResult = SumPolynomialElementsWithArray(polynomialTwo.Elements, sumPolynomialResult);
            else
                sumPolynomialResult = SumPolynomialElementsWithArray(polynomialOne.Elements, sumPolynomialResult);

            return new Polynomial(sumPolynomialResult);
        }

        /// <summary>
        /// Method for substracting a polynomial from polynomial.
        /// Where polynomial index is degree.
        /// </summary>
        /// <param name="polynomialOne">Elements of the polynomial one.</param>
        /// <param name="polynomialTwo">Elements of the polynomial two.</param>
        /// <returns>Returns the new polynomial.</returns>
        public static Polynomial operator -(Polynomial polynomialOne, Polynomial polynomialTwo)
        {
            if (polynomialOne == null)
                throw new ArgumentNullException();
            if (polynomialTwo == null)
                throw new ArgumentNullException();

            double[] sumPolynomialResult = polynomialOne.Elements.Length >= polynomialTwo.Elements.Length
                ? polynomialOne.Elements
                : polynomialTwo.Elements;

            if (polynomialOne.Elements.Length >= polynomialTwo.Elements.Length)
                sumPolynomialResult = SubtractionPolynomialElementsFromArray(polynomialTwo.Elements, sumPolynomialResult);
            else
                sumPolynomialResult = SubtractionPolynomialElementsFromArray(polynomialOne.Elements, sumPolynomialResult);

            return new Polynomial(sumPolynomialResult);
        }

        /// <summary>
        /// Method for summing a polinomial elements with an array.
        /// Where polynomial elements index is degree.
        /// </summary>
        /// <param name="polynomialElements"> Elements of a polynomial.</param>
        /// <param name="arrNumber">Array for summing with a polynomial elements.</param>
        /// <returns>Returns the summation of polynomial elements with array elements.</returns>
        private static double[] SumPolynomialElementsWithArray(double[] polynomialElements, double[] arrNumber)
        {
            for (int i = 0; i < polynomialElements.Length; i++)
            {
                arrNumber[i] += polynomialElements[i];
            }

            return arrNumber;
        }

        /// <summary>
        /// Subtracting a polynomial from an array.
        /// Where polynomial elements index is degree.
        /// </summary>
        /// <param name="polynomialElements"> Elements of a polynomial.</param>
        /// <param name="arrNumber">Array for summing with a polynomial elements.</param>
        /// <returns>Returns the substracion of polynomial elements from array elements.</returns>
        private static double[] SubtractionPolynomialElementsFromArray(double[] polynomialElements, double[] arrNumber)
        {
            for (int i = 0; i < polynomialElements.Length; i++)
            {
                arrNumber[i] -= polynomialElements[i];
            }

            return arrNumber;
        }
    }
}
