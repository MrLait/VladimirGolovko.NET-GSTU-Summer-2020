using NUnit.Framework;
using System;

namespace Polynomials.Domain.Tests
{
    /// <summary>
    /// Test cases to testing class Polynomial.
    /// </summary>
    [TestFixture()]
    public class PolynomialTests
    {
        /// <summary>
        /// Test for correct get property this[int i] from polynomial elements 
        /// Where the index number is the degree of the polynomial.
        /// </summary>
        /// <param name="elementOne">Polinomial element with degree zero.</param>
        /// <param name="elementTwo">Polinomial element with degree two.</param>
        /// <param name="elementThree">Polinomial element with degree three.</param>
        /// <param name="index">Polinomial element index.</param>
        [TestCase(2, 4, 6, 0)]
        [TestCase(2, 4, 6, 1)]
        [TestCase(2, 4, 6, 2)]
        public void GivenThisInt_i_ForGetData_WhenNumbers_2_4_6_ThenOutIs2_4_6(
            double elementOne, double elementTwo, double elementThree, int index)
        {
            // Arrange
            Polynomial actualPolynomial = new Polynomial(new double[] { elementOne, elementTwo, elementThree });

            // Assert
            switch (index)
            {
                case 0:
                    Assert.AreEqual(elementOne, actualPolynomial.Elements[index]);
                    break;
                case 1:
                    Assert.AreEqual(elementTwo, actualPolynomial.Elements[index]);
                    break;
                case 2:
                    Assert.AreEqual(elementThree, actualPolynomial.Elements[index]);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Test for correct get property this[int i] from polynomial elements 
        /// Where the index number is the degree of the polynomial.
        /// </summary>
        /// <param name="elementOne">Polinomial element with degree zero.</param>
        /// <param name="elementTwo">Polinomial element with degree two.</param>
        /// <param name="elementThree">Polinomial element with degree three.</param>
        /// <param name="index">Polinomial element index.</param>
        [TestCase(2, 4, 6, 3)]
        [TestCase(2, 4, 6, 4)]
        [TestCase(2, 4, 6, 10)]
        public void GivenThisInt_i_ForGetData_WhenNumbersIsDifferent_ThenOutIsArgumentOutOfRangeException(
            double elementOne, double elementTwo, double elementThree, int index)
        {
            // Assert
            Assert.That(() => new Polynomial(new double[] { elementOne, elementTwo, elementThree }).Elements[index],
                Throws.TypeOf<IndexOutOfRangeException>()
            );
        }

        /// <summary>
        /// Method for testing division operator overload quotien element.
        /// </summary>
        /// <param name="dividendElDegZero">Dividend element with degree zero.</param>
        /// <param name="dividendElDegOne">Dividend element with degree one.</param>
        /// <param name="dividendElDegTwo">Dividend element with degree two.</param>
        /// <param name="dividendElDegeThree">Dividend element with degree three.</param>
        /// <param name="dividendElDegFour">Dividend element with degree four.</param>
        /// <param name="dividendElDegFive">Dividend element with degree five.</param>
        /// <param name="dividerElDegZero">Divider element with degree zero.</param>
        /// <param name="dividerElDegOne">Divider element with degree one.</param>
        /// <param name="dividerElDegTwo">Divider element with degree two.</param>
        /// <param name="dividerElDegeThree">Divider element with degree three.</param>
        /// <param name="quotientElDegZero">Quotient element with degree zero.</param>
        /// <param name="quotientElDegOne">Quotient element with degree one.</param>
        /// <param name="quotientElDegTwo">Quotient element with degree two.</param>
        /// <param name="remainderElDegZero">Remainder element with degree zero.</param>
        /// <param name="remainderElDegOne">Remainder element with degree one.</param>
        /// <param name="remainderElDegTwo">Remainder element with degree two.</param>
        /// <param name="remainderElDegeThree">Remainder element with degree three.</param>
        /// <param name="remainderElDegFour">Remainder element with degree four.</param>
        /// <param name="remainderElDegFive">Remainder element with degree five.</param>
        [TestCase(
            1, -1, 1, 0, 2, 3,
            0, 1, 2, 1,
            5, -4, 3,
            1, -6, -5, 0, 0, 0)]
        public void GetDivisionForTwoPolynomialWhenInputPolynomialIsValidThenOutIsQuotient(
            double dividendElDegZero, double dividendElDegOne, double dividendElDegTwo, double dividendElDegeThree, double dividendElDegFour, double dividendElDegFive,
            double dividerElDegZero, double dividerElDegOne, double dividerElDegTwo, double dividerElDegeThree,
            double quotientElDegZero, double quotientElDegOne, double quotientElDegTwo,
            double remainderElDegZero, double remainderElDegOne, double remainderElDegTwo, double remainderElDegeThree, double remainderElDegFour, double remainderElDegFive)
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //3x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { dividendElDegZero, dividendElDegOne, dividendElDegTwo, dividendElDegeThree, dividendElDegFour, dividendElDegFive });
            Polynomial divider = new Polynomial(
                //x^3 + 2x^2 + x + 0
                elements: new double[] { dividerElDegZero, dividerElDegOne, dividerElDegTwo, dividerElDegeThree });
            Polynomial expected = new Polynomial(
                //quotient elements = 3x^2 -4x + 5,
                quotientElements: new double[] { quotientElDegZero, quotientElDegOne, quotientElDegTwo },
                //remainder elements = -5x^2 -6x + 1
                remainderElements: new double[] { remainderElDegZero, remainderElDegOne, remainderElDegTwo, remainderElDegeThree, remainderElDegFour, remainderElDegFive });
            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
        }

        /// <summary>
        /// Method for testing division operator overload remainder element.
        /// </summary>
        /// <param name="dividendElDegZero">Dividend element with degree zero.</param>
        /// <param name="dividendElDegOne">Dividend element with degree one.</param>
        /// <param name="dividendElDegTwo">Dividend element with degree two.</param>
        /// <param name="dividendElDegeThree">Dividend element with degree three.</param>
        /// <param name="dividendElDegFour">Dividend element with degree four.</param>
        /// <param name="dividendElDegFive">Dividend element with degree five.</param>
        /// <param name="dividerElDegZero">Divider element with degree zero.</param>
        /// <param name="dividerElDegOne">Divider element with degree one.</param>
        /// <param name="dividerElDegTwo">Divider element with degree two.</param>
        /// <param name="dividerElDegeThree">Divider element with degree three.</param>
        /// <param name="quotientElDegZero">Quotient element with degree zero.</param>
        /// <param name="quotientElDegOne">Quotient element with degree one.</param>
        /// <param name="quotientElDegTwo">Quotient element with degree two.</param>
        /// <param name="remainderElDegZero">Remainder element with degree zero.</param>
        /// <param name="remainderElDegOne">Remainder element with degree one.</param>
        /// <param name="remainderElDegTwo">Remainder element with degree two.</param>
        /// <param name="remainderElDegeThree">Remainder element with degree three.</param>
        /// <param name="remainderElDegFour">Remainder element with degree four.</param>
        /// <param name="remainderElDegFive">Remainder element with degree five.</param>
        [TestCase(
            1, -1, 1, 0, 2, 3,
            0, 1, 2, 1,
            5, -4, 3,
            1, -6, -5, 0, 0, 0)]
        public void GetDivisionForTwoPolynomialWhenInputPolynomialIsValidThenOutIsRemainder(
            double dividendElDegZero, double dividendElDegOne, double dividendElDegTwo, double dividendElDegeThree, double dividendElDegFour, double dividendElDegFive,
            double dividerElDegZero, double dividerElDegOne, double dividerElDegTwo, double dividerElDegeThree,
            double quotientElDegZero, double quotientElDegOne, double quotientElDegTwo,
            double remainderElDegZero, double remainderElDegOne, double remainderElDegTwo, double remainderElDegeThree, double remainderElDegFour, double remainderElDegFive)
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //3x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { dividendElDegZero, dividendElDegOne, dividendElDegTwo, dividendElDegeThree, dividendElDegFour, dividendElDegFive });
            Polynomial divider = new Polynomial(
                //x^3 + 2x^2 + x + 0
                elements: new double[] { dividerElDegZero, dividerElDegOne, dividerElDegTwo, dividerElDegeThree });
            Polynomial expected = new Polynomial(
                //quotient elements = 3x^2 -4x + 5,
                quotientElements: new double[] { quotientElDegZero, quotientElDegOne, quotientElDegTwo },
                //remainder elements = -5x^2 -6x + 1
                remainderElements: new double[] { remainderElDegZero, remainderElDegOne, remainderElDegTwo, remainderElDegeThree, remainderElDegFour, remainderElDegFive });
            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }

        /// <summary>
        /// Method for testing division operator overload quotien element.
        /// </summary>
        /// <param name="dividendElDegZero">Dividend element with degree zero.</param>
        /// <param name="dividendElDegOne">Dividend element with degree one.</param>
        /// <param name="dividendElDegTwo">Dividend element with degree two.</param>
        /// <param name="dividendElDegeThree">Dividend element with degree three.</param>
        /// <param name="dividerElDegZero">Divider element with degree zero.</param>
        /// <param name="dividerElDegOne">Divider element with degree one.</param>
        /// <param name="quotientElDegZero">Quotient element with degree zero.</param>
        /// <param name="quotientElDegOne">Quotient element with degree one.</param>
        /// <param name="quotientElDegTwo">Quotient element with degree two.</param>
        /// <param name="remainderElDegZero">Remainder element with degree zero.</param>
        /// <param name="remainderElDegOne">Remainder element with degree one.</param>
        /// <param name="remainderElDegTwo">Remainder element with degree two.</param>
        /// <param name="remainderElDegeThree">Remainder element with degree three.</param>
        [TestCase(
            -14, 5, -3, 2,
            -2, 1,
            7, 1, 2,
            0, 0, 0, 0)]
        public void GetDivisionForTwoValidPolynomialWhenFirstPolynomialMoreThenSecondThenOutIsQuotienElement(
            double dividendElDegZero, double dividendElDegOne, double dividendElDegTwo, double dividendElDegeThree,
            double dividerElDegZero, double dividerElDegOne,
            double quotientElDegZero, double quotientElDegOne, double quotientElDegTwo,
            double remainderElDegZero, double remainderElDegOne, double remainderElDegTwo, double remainderElDegeThree)
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //2x^3 - 3x^2 + 5x^1 + 14
                elements: new double[] { dividendElDegZero, dividendElDegOne, dividendElDegTwo, dividendElDegeThree });
            Polynomial divider = new Polynomial(
                //x -2
                elements: new double[] { dividerElDegZero, dividerElDegOne });

            Polynomial expected = new Polynomial(
                // quotient elements = 0x^2 + 2x - 4,
                quotientElements: new double[] { quotientElDegZero, quotientElDegOne, quotientElDegTwo },
                //remainder elements = 7x^2 -3x + 1
                remainderElements: new double[] { remainderElDegZero, remainderElDegOne, remainderElDegTwo, remainderElDegeThree });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.QuotientElements, actual.QuotientElements);
        }

        /// <summary>
        /// Method for testing division operator overload remainde element.
        /// </summary>
        /// <param name="dividendElDegZero">Dividend element with degree zero.</param>
        /// <param name="dividendElDegOne">Dividend element with degree one.</param>
        /// <param name="dividendElDegTwo">Dividend element with degree two.</param>
        /// <param name="dividendElDegeThree">Dividend element with degree three.</param>
        /// <param name="dividerElDegZero">Divider element with degree zero.</param>
        /// <param name="dividerElDegOne">Divider element with degree one.</param>
        /// <param name="quotientElDegZero">Quotient element with degree zero.</param>
        /// <param name="quotientElDegOne">Quotient element with degree one.</param>
        /// <param name="quotientElDegTwo">Quotient element with degree two.</param>
        /// <param name="remainderElDegZero">Remainder element with degree zero.</param>
        /// <param name="remainderElDegOne">Remainder element with degree one.</param>
        /// <param name="remainderElDegTwo">Remainder element with degree two.</param>
        /// <param name="remainderElDegeThree">Remainder element with degree three.</param>
        [TestCase(
            -14, 5, -3, 2,
            -2, 1,
            7, 1, 2,
            0, 0, 0, 0)]
        public void GetDivisionForTwoValidPolynomialWhenFirstPolynomialMoreThenSecondThenOutIsRemainderElement(
            double dividendElDegZero, double dividendElDegOne, double dividendElDegTwo, double dividendElDegeThree,
            double dividerElDegZero, double dividerElDegOne,
            double quotientElDegZero, double quotientElDegOne, double quotientElDegTwo,
            double remainderElDegZero, double remainderElDegOne, double remainderElDegTwo, double remainderElDegeThree)
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //2x^3 - 3x^2 + 5x^1 + 14
                elements: new double[] { dividendElDegZero, dividendElDegOne, dividendElDegTwo, dividendElDegeThree });
            Polynomial divider = new Polynomial(
                //x -2
                elements: new double[] { dividerElDegZero, dividerElDegOne });

            Polynomial expected = new Polynomial(
                // quotient elements = 0x^2 + 2x - 4,
                quotientElements: new double[] { quotientElDegZero, quotientElDegOne, quotientElDegTwo },
                //remainder elements = 7x^2 -3x + 1
                remainderElements: new double[] { remainderElDegZero, remainderElDegOne, remainderElDegTwo, remainderElDegeThree });

            //Act
            Polynomial actual = dividend / divider;

            // Assert
            CollectionAssert.AreEqual(expected.RemainderElements, actual.RemainderElements);
        }

        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        /// <param name="dividendElDegZero">Dividend element with degree zero.</param>
        /// <param name="dividendElDegOne">Dividend element with degree one.</param>
        /// <param name="dividendElDegTwo">Dividend element with degree two.</param>
        /// <param name="dividendElDegeThree">Dividend element with degree three.</param>
        /// <param name="dividendElDegFour">Dividend element with degree four.</param>
        /// <param name="dividendElDegFive">Dividend element with degree five.</param>
        /// <param name="dividerElDegZero">Divider element with degree zero.</param>
        /// <param name="dividerElDegOne">Divider element with degree one.</param>
        /// <param name="dividerElDegTwo">Divider element with degree two.</param>
        /// <param name="dividerElDegeThree">Divider element with degree three.</param>
        [TestCase(
            1, -1, 1, 0, 2, 0,
            0, 1, 2, 1)]
        public void GetDivisionForTwoPolynomialWhenInputPolynomialWithFirstNumIsZeroThenOutIsArgumentException(
            double dividendElDegZero, double dividendElDegOne, double dividendElDegTwo, double dividendElDegeThree, double dividendElDegFour, double dividendElDegFive,
            double dividerElDegZero, double dividerElDegOne, double dividerElDegTwo, double dividerElDegeThree)
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //0x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { dividendElDegZero, dividendElDegOne, dividendElDegTwo, dividendElDegeThree, dividendElDegFour, dividendElDegFive });
            Polynomial divider = new Polynomial(
                //x^3 + 2x^2 + x + 0
                elements: new double[] { dividerElDegZero, dividerElDegOne, dividerElDegTwo, dividerElDegeThree });

            // Assert
            Assert.That(() => dividend / divider,
                Throws.TypeOf<ArgumentException>()
            );
        }

        /// <summary>
        /// Method for testing division operator overload.
        /// </summary>
        /// <param name="dividendElDegZero">Dividend element with degree zero.</param>
        /// <param name="dividendElDegOne">Dividend element with degree one.</param>
        /// <param name="dividendElDegTwo">Dividend element with degree two.</param>
        /// <param name="dividendElDegeThree">Dividend element with degree three.</param>
        /// <param name="dividerElDegZero">Divider element with degree zero.</param>
        /// <param name="dividerElDegOne">Divider element with degree one.</param>
        /// <param name="dividerElDegTwo">Divider element with degree two.</param>
        /// <param name="dividerElDegeThree">Divider element with degree three.</param>
        /// <param name="dividerElDegFour">Divider element with degree four.</param>
        /// <param name="dividerdElDegFive">Divider element with degree five.</param>
        [TestCase(
            0, 1, 2, 1,
            1, -1, 1, 0, 2, 0)]
        public void GetDivisionForTwoPolynomialWhenFirstPolynomialLessThenSecondThenOutIsArithmeticException(
            double dividendElDegZero, double dividendElDegOne, double dividendElDegTwo, double dividendElDegeThree,
            double dividerElDegZero, double dividerElDegOne, double dividerElDegTwo, double dividerElDegeThree, double dividerElDegFour, double dividerdElDegFive)
        {
            // Arrange
            Polynomial dividend = new Polynomial(
                //0x^5 + 2x^4 + 0x^3 + x^2 - x^1 + 1
                elements: new double[] { dividendElDegZero, dividendElDegOne, dividendElDegTwo, dividendElDegeThree });
            Polynomial divider = new Polynomial(
               //x^3 + 2x^2 + x + 0
               elements: new double[] { dividerElDegZero, dividerElDegOne, dividerElDegTwo, dividerElDegeThree, dividerElDegFour, dividerdElDegFive });

            // Assert
            Assert.That(() => dividend / divider, Throws.TypeOf<ArithmeticException>());
        }

        /// <summary>
        /// Method for testing multiplication operator overload.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polOneElDegeThree">Polinom one element with degree three.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="polTwoElDegeThree">Polinom two element with degree three.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        /// <param name="expectElDegFour">Expected polinom element with degree four.</param>
        /// <param name="expectElDegFive">Expected polinom element with degree five.</param>
        /// <param name="expectElDegSix">Expected polinom element with degree six.</param>
        [TestCase(
            2, 1, 1, 500,
            2, 1, 1, 1,
            4, 4, 5, 1004, 502, 501, 500)]
        [TestCase(
            -1, -1, -1, -1,
            -1, -1, -1, -1,
            1, 2, 3, 4, 3, 2, 1)]
        [TestCase(
            -1, -1, -1, -1,
            1, 1, 1, 1,
           -1, -2, -3, -4, -3, -2, -1)]
        [TestCase(
            0, 0, 0, 0,
            1, 1, 1, 1,
            0, 0, 0, 0, 0, 0, 0)]
        public void GetMultiplicationForTwoPolynomialWithFourArgWhenArg(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo, double polOneElDegeThree,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo, double polTwoElDegeThree,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree, double expectElDegFour, double expectElDegFive, double expectElDegSix)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo, polOneElDegeThree });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo, polTwoElDegeThree });

            Polynomial expected = new Polynomial(
                //x ^ 6 + x ^ 5 + x ^ 4 + x ^ 3 + x ^ 2 + x ^ 1 + x ^ 0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree, expectElDegFour, expectElDegFive, expectElDegSix });

            //Act
            Polynomial actual = polynomialOne * polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polOneElDegeThree">Polinom one element with degree three.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="polTwoElDegeThree">Polinom two element with degree three.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        [TestCase(
            1, 1, 1, 1,
            1, 1, 1, 1,
            2, 2, 2, 2)]
        [TestCase(
            1, 1, 1, 1,
            19, 19, 19, 19,
            20, 20, 20, 20)]
        public void GetSumForTwoPolynomialWhenPolynomialHasFoutArgThenOutIsFourArgument(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo, double polOneElDegeThree,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo, double polTwoElDegeThree,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo, polOneElDegeThree });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo, polTwoElDegeThree });

            Polynomial expected = new Polynomial(
                //2x^3 + x^2 + x^1 + x^0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree });

            //Act
            Polynomial actual = polynomialOne + polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="polTwoElDegeThree">Polinom two element with degree three.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        [TestCase(
            1, 1, 1,
            1, 1, 1, 1,
            2, 2, 2, 1)]
        [TestCase(
            1, 1, 1,
            19, 19, 19, 19,
            20, 20, 20, 19)]
        public void GetSumForTwoPolynomialWhenFirstPolynomialLessThenSecondThenOutIsFourArgument(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo, double polTwoElDegeThree,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo, polTwoElDegeThree });

            Polynomial expected = new Polynomial(
                //2x^3 + x^2 + x^1 + x^0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree });

            //Act
            Polynomial actual = polynomialOne + polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polOneElDegThree">Polinom one element with degree three.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        [TestCase(
            1, 1, 1, 1,
            1, 1, 1,
            2, 2, 2, 1)]
        [TestCase(
            1, 1, 1, 1,
            19, 19, 19,
            20, 20, 20, 1)]
        public void GetSumForTwoPolynomialWhenSecondtPolynomialLessThenFirstThenOutIsFourArgument(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo, double polOneElDegThree,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo, polOneElDegThree });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo });

            Polynomial expected = new Polynomial(
                //2x^3 + x^2 + x^1 + x^0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree });

            //Act
            Polynomial actual = polynomialOne + polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        [TestCase(1, 1, 1)]
        public void GetSumForTwoPolynomialWhenFirstPolynomialIsNullThenOutIsNullReferenceException(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                elements: null);
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo });

            //Act
            Assert.That(() => polynomialOne + polynomialTwo, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polOneElDegeThree">Polinom one element with degree three.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="polTwoElDegeThree">Polinom two element with degree three.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        [TestCase(
            1, 1, 1, 1,
            1, 1, 1, 1,
            0, 0, 0, 0)]
        public void GetSubtractionForTwoPolynomialWhenPolynomialHasFoutArgThenOutIsFourArgument(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo, double polOneElDegeThree,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo, double polTwoElDegeThree,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo, polOneElDegeThree });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo, polTwoElDegeThree });

            Polynomial expected = new Polynomial(
                //x^3 + x^2 + x^1 + 0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree });

            //Act
            Polynomial actual = polynomialOne - polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="polTwoElDegeThree">Polinom two element with degree three.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        [TestCase(
           1, 1, 1,
           1, 1, 1, 1,
           0, 0, 0, 1)]
        public void GetSubtractionForTwoPolynomialWhenFirstPolynomialLessThenSecondThenOutIsFourArgument(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo, double polTwoElDegeThree,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo, polTwoElDegeThree });

            Polynomial expected = new Polynomial(
                //x^3 + x^2 + x^1 + 0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree });

            //Act
            Polynomial actual = polynomialOne - polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the subtraction operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        /// <param name="polOneElDegThree">Polinom one element with degree three.</param>
        /// <param name="polTwoElDegZero">Polinom two element with degree zero.</param>
        /// <param name="polTwoElDegOne">Polinom two element with degree one.</param>
        /// <param name="polTwoElDegTwo">Polinom two element with degree two.</param>
        /// <param name="expectElDegZero">Expected polinom element with degree zero.</param>
        /// <param name="expectElDegOne">Expected polinom element with degree one.</param>
        /// <param name="expectElDegTwo">Expected polinom element with degree two.</param>
        /// <param name="expectElDegeThree">Expected polinom element with degree three.</param>
        [TestCase(
         1, 1, 1, 1,
         1, 1, 1,
         0, 0, 0, 1)]
        public void GetSubtractionForTwoPolynomialWhenSecondtPolynomialLessThenFirstThenOutIsFourArgument(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo, double polOneElDegThree,
            double polTwoElDegZero, double polTwoElDegOne, double polTwoElDegTwo,
            double expectElDegZero, double expectElDegOne, double expectElDegTwo, double expectElDegeThree)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo, polOneElDegThree });
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + x^0
                elements: new double[] { polTwoElDegZero, polTwoElDegOne, polTwoElDegTwo });

            Polynomial expected = new Polynomial(
                //x^3 + x^2 + x^1 + 0
                elements: new double[] { expectElDegZero, expectElDegOne, expectElDegTwo, expectElDegeThree });

            //Act
            Polynomial actual = polynomialOne - polynomialTwo;

            // Assert
            CollectionAssert.AreEqual(expected.Elements, actual.Elements);
        }

        /// <summary>
        /// Method for testing the overload of the summation operator.
        /// </summary>
        /// <param name="polOneElDegZero">Polinom one element with degree zero.</param>
        /// <param name="polOneElDegOne">Polinom one element with degree one.</param>
        /// <param name="polOneElDegTwo">Polinom one element with degree two.</param>
        public void GetSubtractionForTwoPolynomialWhenFirstPolynomialIsNullThenOutIsNullReferenceException(
            double polOneElDegZero, double polOneElDegOne, double polOneElDegTwo)
        {
            // Arrange
            Polynomial polynomialOne = new Polynomial(
                elements: null);
            Polynomial polynomialTwo = new Polynomial(
                //x^3 + x^2 + x^1 + 1
                elements: new double[] { polOneElDegZero, polOneElDegOne, polOneElDegTwo });

            //Act
            Assert.That(() => polynomialOne - polynomialTwo, Throws.TypeOf<NullReferenceException>());
        }
    }
}