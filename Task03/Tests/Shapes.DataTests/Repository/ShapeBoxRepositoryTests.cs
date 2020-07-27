using NUnit.Framework;
using Shapes.Data.UserException;
using Shapes.DataTests.Repository;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shapes.Data.Repository.Tests
{
    /// <summary>
    /// Tests for <see cref="ShapeBoxRepository"/>
    /// </summary>
    [TestFixture]
    public class ShapeBoxRepositoryTests
    {
        private static readonly object[] _sourceSquareBoxShapes =
        {
            new object[]
            {
                new List<BaseAbstractShape>{new FilmSquare(10)}, //Test case 1 actual
                new List<BaseAbstractShape>{new FilmSquare(10)} //Test case 1 expected
            },
            new object[]
            {
                new List<BaseAbstractShape>{new FilmSquare(double.MaxValue/1000), new FilmSquare(10) }, //Test case 2 actual
                new List<BaseAbstractShape>{new FilmSquare(double.MaxValue/1000), new FilmSquare(10) } //Test case 2 expected
            }
        };

        private static readonly object[] _sourceRectangleBoxShapes = {
            new object[]
            {
                new List<BaseAbstractShape>{new FilmRectangle(100,100) },
                new List<BaseAbstractShape>{new FilmRectangle(100,100) }
            },
            new object[]
            {
            new List<BaseAbstractShape>{new FilmRectangle(double.MaxValue/1000,double.MaxValue/1000), new FilmRectangle(double.MaxValue/1000,100) },
            new List<BaseAbstractShape>{new FilmRectangle(double.MaxValue/1000,double.MaxValue/1000), new FilmRectangle(double.MaxValue/1000,100) }
            }
        };

        private static readonly object[] _sourceShapeObjects =
        {
            new object[]
            {
                new BaseAbstractShape[]
                {
                    new FilmSquare(10), new FilmSquare(100), new FilmRectangle(11, 11),
                    new FilmSquare(double.MaxValue/1000), new FilmRectangle(double.MaxValue/1000, 20),
                    new PaperCircle(7, Color.White), new PaperCircle(8, Color.White), new PaperCircle(9, Color.White),   new PaperCircle(10, Color.White),
                    new PaperCircle(11, Color.White), new PaperCircle(12, Color.White), new PaperCircle(13, Color.White), new PaperCircle(14, Color.White),
                    new PaperCircle(15, Color.White), new PaperCircle(16, Color.White), new PaperCircle(17, Color.White), new PaperCircle(18, Color.White),
                    new PaperCircle(19, Color.White), new PaperCircle(20, Color.White), new PaperCircle(21, Color.White)
                },
                new List<BaseAbstractShape>
                {
                    new FilmSquare(10), new FilmSquare(100), new FilmRectangle(11, 11),
                    new FilmSquare(double.MaxValue/1000), new FilmRectangle(double.MaxValue/1000, 20),
                    new PaperCircle(7, Color.White), new PaperCircle(8, Color.White), new PaperCircle(9, Color.White), new PaperCircle(10, Color.White),
                    new PaperCircle(11, Color.White), new PaperCircle(12, Color.White), new PaperCircle(13, Color.White), new PaperCircle(14, Color.White),
                    new PaperCircle(15, Color.White), new PaperCircle(16, Color.White), new PaperCircle(17, Color.White), new PaperCircle(18, Color.White),
                    new PaperCircle(19, Color.White), new PaperCircle(20, Color.White), new PaperCircle(21, Color.White)
                }
            }
        };

        private static readonly List<BaseAbstractShape> _sourceShapeList = new List<BaseAbstractShape>
        {
            new FilmSquare(10), new FilmSquare(100), new PaperRectangle(11, 11, Color.White),
            new PaperSquare(1000000000000, Color.White), new PaperRectangle(1000000000000, 20, Color.White),
            new FilmRectangle(123,124), new PaperCircle(10, Color.White), new FilmCircle(11), new PaperCircle(12, Color.White)
        };

        /// <summary>
        /// Initial box for for shapes instance.
        /// </summary>
        /// <param name="actualShape">List with actual shapes.</param>
        /// <returns>Return box for shapes instance.</returns>
        public static ShapeBoxRepository InitialShapeBoxRepository(List<BaseAbstractShape> actualShape)
        {
            List<BaseAbstractShape> tmpShapes = new List<BaseAbstractShape>(actualShape);
            ShapeBoxRepository boxForShapes = new ShapeBoxRepository
            {
                BoxShapes = tmpShapes.ToArray()
            };
            return boxForShapes;
        }

        /// <summary>
        /// Test case for test <see cref="ShapeBoxRepository.BoxShapes"/>
        /// </summary>
        /// <param name="actualSquareBoxShapes">Sourece list with Square.</param>
        /// <param name="expectedSquareBoxShapes">Expected list with square</param>
        [Test, TestCaseSource(nameof(_sourceSquareBoxShapes))]
        public void GivenSquareList_WhenShapeIsSquare_ThenOutContainList(List<BaseAbstractShape> actualSquareBoxShapes, List<BaseAbstractShape> expectedSquareBoxShapes)
        {
            //Assert
            Assert.AreEqual(expectedSquareBoxShapes, actualSquareBoxShapes);
        }

        /// <summary>
        /// Test case fir test <see cref="ShapeBoxRepository.BoxShapes"/>
        /// </summary>
        /// <param name="actualRectangleBoxShapes">Source list with rectangle.</param>
        /// <param name="expectedRectangleBoxShapes">Expected list with rectangle.</param>
        [Test, TestCaseSource(nameof(_sourceRectangleBoxShapes))]
        public void GivenRectangleList_WhenShapeIsRectangle_ThenOutContainList(List<BaseAbstractShape> actualRectangleBoxShapes, List<BaseAbstractShape> expectedRectangleBoxShapes)
        {
            //Assert
            Assert.AreEqual(expectedRectangleBoxShapes, actualRectangleBoxShapes);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.AddShapeToBox(Shape)"/>
        /// </summary>
        /// <param name="actualShape">Input data with different shapes.</param>
        /// <param name="expectedRectangleBoxShapes">Expected shapes list.</param>
        [Test, TestCaseSource(nameof(_sourceShapeObjects))]
        public void GivenAddShapeToBox_WhenShapeIsDifferent_ThenOutIsBoxShapes(BaseAbstractShape[] actualShape, List<BaseAbstractShape> expectedRectangleBoxShapes)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = new ShapeBoxRepository();
            List<BaseAbstractShape> actualBoxList;

            //Act
            if (actualShape != null)
            {
                foreach (BaseAbstractShape item in actualShape)
                {
                    boxForShapes.AddShapeToBox(item);
                }
            }
            actualBoxList = boxForShapes.BoxShapes.ToList();

            //Assert
            Assert.AreEqual(expectedRectangleBoxShapes, actualBoxList);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.AddShapeToBox(Shape)"/>
        /// When shapes in the box more then 20. Then out is IndexOutOfRangeException.
        /// </summary>
        /// <param name="actualShape">Input data with different shapes.</param>
        /// <param name="expectedRectangleBoxShapes">Expected shape list.</param>
        [Test, TestCaseSource(nameof(_sourceShapeObjects))]
        public void GivenAddShapeToBox_WhenShapesMoreThen20_BoxShapeException(BaseAbstractShape[] actualShape, List<BaseAbstractShape> expectedRectangleBoxShapes)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = new ShapeBoxRepository();

            //Act
            if (actualShape != null)
            {
                foreach (BaseAbstractShape item in actualShape)
                {
                    boxForShapes.AddShapeToBox(item);
                }
            }
            //Assert
            Assert.Throws<BoxShapeException>(() => boxForShapes.AddShapeToBox(new PaperCircle(31, Color.White)));

        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.FindShapeById(int)"/>
        /// </summary>
        /// <param name="actualShape">Actual shape list.</param>
        /// <param name="shapeId">Shape id.</param>
        /// <returns>Returns shape which was found by id.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesFindShapeById")]
        public BaseAbstractShape GivenFindShapeById_WhenByIdThenOutIsShape(BaseAbstractShape[] actualShape, int shapeId)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = new ShapeBoxRepository();

            //Act
            if (actualShape != null)
            {
                foreach (BaseAbstractShape item in actualShape)
                {
                    boxForShapes.AddShapeToBox(item);
                }
            }

            //Assert
            return boxForShapes.FindShapeById(shapeId);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.ExecuteShapeById(int)"/>
        /// </summary>
        /// <param name="actualShape">Actual shape list.</param>
        /// <param name="shapeId">Shape id.</param>
        /// <returns>Returns shape which was found by id.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesExecuteShapeById")]
        public BaseAbstractShape GivenExecuteShapeById_WhenByIdThenOutIsShape(BaseAbstractShape[] actualShape, int shapeId)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = new ShapeBoxRepository();

            //Act
            if (actualShape != null)
            {
                foreach (BaseAbstractShape item in actualShape)
                {
                    boxForShapes.AddShapeToBox(item);
                }
            }

            //Assert
            return boxForShapes.ExecuteShapeById(shapeId);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.ExecuteShapeById(int)"/>
        /// </summary>
        /// <param name="actualShape">Actual shape list.</param>
        /// <param name="shapeId">Shape id.</param>
        /// <returns>Returns count shapes ramaining on the list.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesExecuteShapeByIdThennOutputListLessByOne")]
        public int GivenExecuteShapeById_WhenExecuteOneShapeThenOutputListLessByOne(List<BaseAbstractShape> actualShape, int shapeId)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            boxForShapes.ExecuteShapeById(shapeId);

            //Assert
            return boxForShapes.BoxShapes.Length;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.ReplaceById(int, BaseAbstractShape)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <param name="shapeId">Shape id which you want replace.</param>
        /// <param name="shape">The shape you want to put in the box.</param>
        /// <returns>The shape you want to put in the box.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesReplaceById")]
        public BaseAbstractShape GivenReplaceById_WhenByIdThenOutNewBoxShapes(List<BaseAbstractShape> actualShape, int shapeId, BaseAbstractShape shape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            boxForShapes.ReplaceById(shapeId, shape);

            //Assert
            return boxForShapes.BoxShapes[shapeId];
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.FindShapeByPattern(BaseAbstractShape)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <param name="shapePattern">Shape pattern.</param>
        /// <returns>Found shape by pattern</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesFindShapeAccordingToThePattern")]
        public BaseAbstractShape GiveFindShapeByPattern_WhenPatternIsValidThenOutShapeId(List<BaseAbstractShape> actualShape, BaseAbstractShape shapePattern)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            BaseAbstractShape shapeByPattern = boxForShapes.FindShapeByPattern(shapePattern);

            //Assert
            return shapeByPattern;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetNumOfShapesInBox"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Returns count of shape in the box.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetNumberOfShapesInTheBox")]
        public int GiveGetNumOfShapesInBox_WhenInputIsListShapesThenOutNumberOfShapes(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            int shapeCount = boxForShapes.GetNumOfShapesInBox();

            //Assert
            return shapeCount;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetTotalArea"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return the total area.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetSumAreaShapes")]
        public double GiveGetTotalArea_WhenInputIsListShapesThenOutIsValidSumOfArea(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            double shapeAreaCount = boxForShapes.GetTotalArea();

            //Assert
            return shapeAreaCount;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetTotalArea"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return the total area.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetSumAreaShapesOutIsInfinity")]
        public double GiveGetTotalArea_WhenInputIsListWithBigValuesShapesThenOutIsInfinity(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            double shapeAreaCount = boxForShapes.GetTotalArea();

            //Assert
            return shapeAreaCount;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetTotalPerimeter"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return the total perimeter.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetSumPerimetersShapes")]
        public double GiveGetTotalPerimeter_WhenInputIsListShapesThenOutIsValidSumOfArea(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            double shapePerimeterCount = boxForShapes.GetTotalPerimeter();

            //Assert
            return shapePerimeterCount;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetTotalPerimeter"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return the total perimeter.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetSumPerimetersShapesOutIsBigValue")]
        public double GiveGetTotalPerimeter_WhenInputIsListWithBigValuesShapesThenOutIsInfinity(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            double shapePerimeterCount = boxForShapes.GetTotalPerimeter();

            //Assert
            return shapePerimeterCount;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetAllCircles"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return list of all circles.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetAllCirclesThenOutIsEmpty")]
        public List<AbstractCircle> GiveGetAllCircles_WhenInputIsListWithoutCircleThenOutIsEmpty(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            List<AbstractCircle> shapeCircles = boxForShapes.GetAllCircles().ToList();

            //Assert
            return shapeCircles;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetAllCircles"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return list of all circles.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "TestCasesGetAllCirclesThenOutIsCircleList")]
        public List<AbstractCircle> GiveGetAllCircles_WhenInputIsListWithCircleThenOutIsCircleList(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            List<AbstractCircle> shapeCircles = boxForShapes.GetAllCircles().ToList();

            //Assert
            return shapeCircles;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetAllFilmShapes"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return list of all film shapes.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetAllFilmShapesThenOutIsEmpty")]
        public List<BaseAbstractShape> GiveGetAllFilmShapes_WhenInputListFithoutFilmShapesThenOutIsEmpty(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            List<BaseAbstractShape> filmShapes = boxForShapes.GetAllFilmShapes().ToList();

            //Assert
            return filmShapes;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.GetAllFilmShapes"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        /// <returns>Return list of all film shapes.</returns>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetAllFilmShapesThenOutIsFilmShapesList")]
        public List<BaseAbstractShape> GiveGetAllFilmShapes_WhenInputIsListShapesThenOutIsListFilmShapes(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);

            //Act
            List<BaseAbstractShape> filmShapes = boxForShapes.GetAllFilmShapes().ToList();

            //Assert
            return filmShapes;
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.SaveAllShapesInXmlUsingStreamWriter(string)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetSaveAllShapesInXmlUsingStreamWriter")]
        public void GiveSaveAllShapesInXmlUsingStreamWriter_WhenThenOut(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);
            string path = @"xmlData/allShapes.xml";

            //Act
            boxForShapes.SaveAllShapesInXmlUsingStreamWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.SaveFilmShapesInXmlUsingStreamWriter(string)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetSaveFilmShapesInXmlUsingStreamWriter")]
        public void GiveSaveFilmShapesInXmlUsingStreamWriter_WhenThenOut(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);
            string path = @"xmlData/allFilmShapes.xml";

            //Act
            boxForShapes.SaveAllFilmShapesInXmlUsingStreamWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.SavePaperShapesInXmlUsingStreamWriter(string)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetSavePaperShapesInXmlUsingStreamWriter")]
        public void GiveSavePaperShapesInXmlUsingStreamWriter_WhenThenOut(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);
            string path = @"xmlData/allPaperShapes.xml";

            //Act
            boxForShapes.SaveAllFilmShapesInXmlUsingStreamWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.SaveAllShapesInXmlUsingXmlWriter(string)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetSaveAllShapesInXmlUsingXmlWriter")]
        public void GiveSaveAllShapesInXmlUsingXmlWriterr_WhenThenOut(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);
            string path = @"xmlData/allShapesXmlWriter.xml";

            //Act
            boxForShapes.SaveAllShapesInXmlUsingXmlWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.SaveFilmShapesInXmlUsingXmlWriter(string)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetSaveAllShapesInXmlUsingXmlWriter")]
        public void GiveSaveFilmShapesInXmlUsingXmlWriter(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);
            string path = @"xmlData/allFilmShapesXmlWriter.xml";

            //Act
            boxForShapes.SaveAllFilmShapesInXmlUsingXmlWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.SaveAllPaperShapesInXmlUsingXmlWriter(string)"/>
        /// </summary>
        /// <param name="actualShape">The source of the list of shapes.</param>
        [Test, TestCaseSource(typeof(MyFactoryShapeBoxRepositoryTests), "GetSaveAllShapesInXmlUsingXmlWriter")]
        public void GiveSavePaperShapesInXmlUsingXmlWriter(List<BaseAbstractShape> actualShape)
        {
            //Arrange
            ShapeBoxRepository boxForShapes = InitialShapeBoxRepository(actualShape);
            string path = @"xmlData/allPaperShapesXmlWriter.xml";

            //Act
            boxForShapes.SaveAllPaperShapesInXmlUsingXmlWriter(path);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.LoadAllShapesFromXmlUsingStreamReader(string)"/>
        /// </summary>
        [TestCase()]
        public void GiveLoadAllShapesFromXmlUsingStreamReader_WhenThenOut()
        {
            //Arrange
            ShapeBoxRepository actualBoxForShapes = new ShapeBoxRepository();
            ShapeBoxRepository expectedBoxForShapes = InitialShapeBoxRepository(_sourceShapeList);
            string path = "xmlData/allShapes.xml";
            //Act
            actualBoxForShapes.LoadAllShapesFromXmlUsingStreamReader(path);
            var actualBox = actualBoxForShapes.BoxShapes;
            var expectedBox = expectedBoxForShapes.BoxShapes;
            //Assert
            CollectionAssert.AreEqual(expectedBox, actualBox);
        }

        /// <summary>
        /// Test case for method <see cref="ShapeBoxRepository.LoadAllShapesFromXmlUsingXmlReader(string)"/>
        /// </summary>
        [TestCase()]
        public void GiveLoadAllShapesFromXmlUsingXmlReader_WhenThenOut()
        {
            //Arrange
            ShapeBoxRepository actualBoxForShapes = new ShapeBoxRepository();
            ShapeBoxRepository expectedBoxForShapes = InitialShapeBoxRepository(_sourceShapeList);
            string path = "xmlData/allShapes.xml";
            //Act
            actualBoxForShapes.LoadAllShapesFromXmlUsingXmlReader(path);
            var actualBox = actualBoxForShapes.BoxShapes;
            var expectedBox = expectedBoxForShapes.BoxShapes;
            //Assert
            CollectionAssert.AreEqual(expectedBox, actualBox);
        }
    }
}
