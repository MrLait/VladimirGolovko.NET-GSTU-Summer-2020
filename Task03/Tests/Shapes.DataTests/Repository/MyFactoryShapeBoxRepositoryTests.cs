using NUnit.Framework;
using Shapes.Data.Repository;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using System.Collections;
using System.Collections.Generic;

namespace Shapes.DataTests.Repository
{
    /// <summary>
    /// Factory test cases for Type <see cref="MyFactoryShapeBoxRepositoryTests"/>
    /// </summary>
    public static class MyFactoryShapeBoxRepositoryTests
    {
        private static readonly BaseAbstractShape[] _sourceShapes = new BaseAbstractShape[]
        {
            new FilmSquare(10), new FilmSquare(100), new FilmRectangle(11, 11),
            new FilmSquare(double.MaxValue/1113), new FilmRectangle(double.MaxValue/1113, 20)
        };

        private static readonly List<BaseAbstractShape> _sourceShapeList = new List<BaseAbstractShape>
        {
            new FilmSquare(10), new FilmSquare(100), new PaperRectangle(11, 11, Color.White),
            new PaperSquare(1000000000000, Color.White), new PaperRectangle(1000000000000, 20, Color.White),
            new FilmRectangle(123,124), new PaperCircle(10, Color.White), new FilmCircle(11), new PaperCircle(12, Color.White)
        };

        private static readonly List<BaseAbstractShape> _sourceShapeListWithOutCircle = new List<BaseAbstractShape>
        {
            new FilmSquare(10), new FilmSquare(100), new PaperRectangle(11, 11, Color.White),
            new PaperSquare(double.MaxValue/1113, Color.White), new PaperRectangle(double.MaxValue/1113, 20, Color.White)
        };

        private static readonly List<BaseAbstractShape> _sourceShapeListWithOutBigValue = new List<BaseAbstractShape>
        {
            new FilmSquare(10), new FilmSquare(100), new FilmRectangle(11, 11),
            new FilmSquare(1113000000), new FilmRectangle(200000000000000, 20)
        };

        private static readonly List<BaseAbstractShape> _sourceShapeWithCircleList = new List<BaseAbstractShape>
        {
            new FilmSquare(10), new PaperSquare(100, Color.White), new FilmCircle(1),
            new PaperRectangle(11, 11, Color.White), new PaperSquare(double.MaxValue/1113, Color.White),
            new FilmRectangle(double.MaxValue/1113, 20), new FilmCircle(10), new PaperCircle(100, Color.White)
        };

        private static readonly List<BaseAbstractShape> _sourceShapeCircleList = new List<BaseAbstractShape>
        {
            new FilmCircle(1), new FilmCircle(10), new PaperCircle(100, Color.White)
        };

        private static readonly List<BaseAbstractShape> _sourceFilmShapes = new List<BaseAbstractShape>
        {
            new FilmSquare(10), new FilmSquare(100), new FilmRectangle(123,124), new FilmCircle(11)
        };

        private static readonly List<BaseAbstractShape> _sourcePaperShapes = new List<BaseAbstractShape>
        {
            new PaperSquare(10, Color.White), new PaperSquare(100, Color.White)
        };

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository"/>
        /// </summary>
        public static IEnumerable TestCasesFindShapeById
        {
            get
            {
                yield return new TestCaseData(_sourceShapes, 0).Returns(_sourceShapes[0]);
                yield return new TestCaseData(_sourceShapes, 1).Returns(_sourceShapes[1]);
                yield return new TestCaseData(_sourceShapes, 2).Returns(_sourceShapes[2]);
                yield return new TestCaseData(_sourceShapes, 3).Returns(_sourceShapes[3]);
                yield return new TestCaseData(_sourceShapes, 4).Returns(_sourceShapes[4]);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.ExecuteShapeById(int)"/>
        /// </summary>
        public static IEnumerable TestCasesExecuteShapeById
        {
            get
            {
                yield return new TestCaseData(_sourceShapes, 0).Returns(_sourceShapes[0]);
                yield return new TestCaseData(_sourceShapes, 1).Returns(_sourceShapes[1]);
                yield return new TestCaseData(_sourceShapes, 2).Returns(_sourceShapes[2]);
                yield return new TestCaseData(_sourceShapes, 3).Returns(_sourceShapes[3]);
                yield return new TestCaseData(_sourceShapes, 4).Returns(_sourceShapes[4]);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.ExecuteShapeById(int)"/>
        /// </summary>
        public static IEnumerable TestCasesExecuteShapeByIdThennOutputListLessByOne
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList, 4).Returns(_sourceShapeList.Count);
                yield return new TestCaseData(_sourceShapeList, 3).Returns(_sourceShapeList.Count);
                yield return new TestCaseData(_sourceShapeList, 2).Returns(_sourceShapeList.Count);
                yield return new TestCaseData(_sourceShapeList, 1).Returns(_sourceShapeList.Count);
                yield return new TestCaseData(_sourceShapeList, 0).Returns(_sourceShapeList.Count);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.ReplaceById(int, BaseAbstractShape)"/>
        /// </summary>
        public static IEnumerable TestCasesReplaceById
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList, 4, new FilmSquare(111)).Returns(new FilmSquare(111));
                yield return new TestCaseData(_sourceShapeList, 3, new FilmSquare(111)).Returns(new FilmSquare(111));
                yield return new TestCaseData(_sourceShapeList, 2, new FilmSquare(111)).Returns(new FilmSquare(111));
                yield return new TestCaseData(_sourceShapeList, 1, new PaperRectangle(111, 111, Color.White)).Returns(new PaperRectangle(111, 111, Color.White));
                yield return new TestCaseData(_sourceShapeList, 0, new PaperSquare(111, Color.White)).Returns(new PaperSquare(111, Color.White));
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.FindShapeByPattern(BaseAbstractShape)"/>
        /// </summary>
        public static IEnumerable TestCasesFindShapeAccordingToThePattern
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList, new FilmSquare(10)).Returns(new FilmSquare(10));
                yield return new TestCaseData(_sourceShapeList, new FilmSquare(100)).Returns(new FilmSquare(100));
                yield return new TestCaseData(_sourceShapeList, new PaperSquare(1000000000000, Color.White)).Returns(new PaperSquare(1000000000000, Color.White));
                yield return new TestCaseData(_sourceShapeList, new PaperRectangle(11, 11, Color.White)).Returns(new PaperRectangle(11, 11, Color.White));
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetNumOfShapesInBox"/>
        /// </summary>
        public static IEnumerable TestCasesGetNumberOfShapesInTheBox
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList).Returns(9);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetTotalArea"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumAreaShapes
        {
            get
            {
                yield return new TestCaseData(_sourceShapeListWithOutBigValue).Returns(1.2427690000000102E+18d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetTotalArea"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumAreaShapesOutIsInfinity
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList).Returns(1.00000000002E+24d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetTotalPerimeter"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumPerimetersShapes
        {
            get
            {
                yield return new TestCaseData(_sourceShapeListWithOutBigValue).Returns(400004452000524.0d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetTotalPerimeter"/>
        /// </summary>
        public static IEnumerable TestCasesGetSumPerimetersShapesOutIsBigValue
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList).Returns(6000000001225.3506d);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetAllCircles"/>
        /// </summary>
        public static IEnumerable TestCasesGetAllCirclesThenOutIsEmpty
        {
            get
            {
                yield return new TestCaseData(_sourceShapeListWithOutCircle).Returns(new List<AbstractCircle> { });
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetAllCircles"/>
        /// </summary>
        public static IEnumerable TestCasesGetAllCirclesThenOutIsCircleList
        {
            get
            {
                yield return new TestCaseData(_sourceShapeWithCircleList).Returns(_sourceShapeCircleList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetAllFilmShapes"/>
        /// </summary>
        public static IEnumerable GetAllFilmShapesThenOutIsEmpty
        {
            get
            {
                yield return new TestCaseData(_sourcePaperShapes).Returns(new List<BaseAbstractShape> { });
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.GetAllFilmShapes"/>
        /// </summary>
        public static IEnumerable GetAllFilmShapesThenOutIsFilmShapesList
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList).Returns(_sourceFilmShapes);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.SaveAllShapesInXmlUsingStreamWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSaveAllShapesInXmlUsingStreamWriter
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.SaveAllFilmShapesInXmlUsingStreamWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSaveFilmShapesInXmlUsingStreamWriter
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.SaveAllPaperShapesInXmlUsingStreamWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSavePaperShapesInXmlUsingStreamWriter
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList);
            }
        }

        /// <summary>
        /// Test cases for method <see cref="ShapeBoxRepository.SaveAllShapesInXmlUsingXmlWriter(string)"/>
        /// </summary>
        public static IEnumerable GetSaveAllShapesInXmlUsingXmlWriter
        {
            get
            {
                yield return new TestCaseData(_sourceShapeList);
            }
        }
    }
}
