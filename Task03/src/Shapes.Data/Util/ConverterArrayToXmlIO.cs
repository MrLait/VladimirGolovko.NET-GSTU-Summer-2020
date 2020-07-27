using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Shapes.Data.Util
{
    /// <summary>
    /// Class for converting boxshape array in xml format.
    /// </summary>
    public class ConverterArrayToXmlIO
    {
        /// <summary>
        /// Converting all shapes to Xml format.
        /// </summary>
        /// <param name="_shapeList">Array with shapes.</param>
        /// <returns>Returns xml.</returns>
        public static XDocument AddShapesInXml(BaseAbstractShape[] _shapeList)
        {
            List<XElement> xElementsShapes = new List<XElement>();
            for (int i = 0; i < _shapeList.Length; i++)
            {
                if (_shapeList[i] != null)
                    PrepareShapeToXml(_shapeList[i], xElementsShapes, i);
            }

            var xdoc = ConvertXElementsToXDocument(xElementsShapes, "Shapes");

            return xdoc;
        }

        /// <summary>
        /// Converting all film shapes to Xml format.
        /// </summary>
        /// <param name="_shapeList">Array with shapes.</param>
        /// <returns>Returns xml.</returns>
        public static XDocument AddFilmShapesInXml(BaseAbstractShape[] _shapeList)
        {
            List<XElement> xElementsShapes = new List<XElement>();
            int indexXElement = 0;

            for (int i = 0; i < _shapeList.Length; i++)
            {
                if (_shapeList[i] != null && _shapeList[i] is IFilm)
                { 
                    PrepareShapeToXml(_shapeList[i], xElementsShapes, indexXElement);
                    indexXElement++;
                }
            }

            var xdoc = ConvertXElementsToXDocument(xElementsShapes, "Shapes");
            return xdoc;
        }

        /// <summary>
        /// Converting all paper shapes to Xml format.
        /// </summary>
        /// <param name="_shapeList">Array with shapes.</param>
        /// <returns>Returns xml.</returns>
        public static XDocument AddPaperShapesInXml(BaseAbstractShape[] _shapeList)
        {
            List<XElement> xElementsShapes = new List<XElement>();
            int indexXElement = 0;

            for (int i = 0; i < _shapeList.Length; i++)
            {
                if (_shapeList[i] != null && _shapeList[i] is IPaper)
                {
                    PrepareShapeToXml(_shapeList[i], xElementsShapes, indexXElement);
                    indexXElement++;
                }
            }
            var xdoc = ConvertXElementsToXDocument(xElementsShapes, "Shapes");
            return xdoc;
        }

        /// <summary>
        /// Converting xml to shapes array.
        /// </summary>
        /// <param name="xmlDocument">Xml.</param>
        /// <returns>Returns shapes array.</returns>
        public static IEnumerable<BaseAbstractShape> ParsXmlDocToShapeList(XmlDocument xmlDocument)
        {
            List<BaseAbstractShape> shapes = new List<BaseAbstractShape>();
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");

            try
            {
                for (int i = 0; i < childnodes.Count; i++)
                {
                    string typeOfShape = childnodes[i].Name;

                    if (Enum.IsDefined(typeof(ShapeEnum), typeOfShape))
                    {
                        switch ((ShapeEnum)Enum.Parse(typeof(ShapeEnum), typeOfShape))
                        {
                            case ShapeEnum.FilmCircle:
                                shapes.Add(new FilmCircle(double.Parse(childnodes[i].ChildNodes[2].InnerText)));
                                break;
                            case ShapeEnum.PaperCircle:
                                shapes.Add(new PaperCircle(double.Parse(childnodes[i].ChildNodes[2].InnerText), ConvStrToColorEnum(childnodes[i].ChildNodes[3].InnerText)));
                                break;
                            case ShapeEnum.FilmSquare:
                                shapes.Add(new FilmSquare(double.Parse(childnodes[i].ChildNodes[2].InnerText)));
                                break;
                            case ShapeEnum.PaperSquare:
                                shapes.Add(new PaperSquare(double.Parse(childnodes[i].ChildNodes[2].InnerText), ConvStrToColorEnum(childnodes[i].ChildNodes[3].InnerText)));
                                break;
                            case ShapeEnum.FilmRectangle:
                                shapes.Add(new FilmRectangle(
                                    double.Parse(childnodes[i].ChildNodes[2].InnerText),
                                    double.Parse(childnodes[i].ChildNodes[3].InnerText)));
                                break;
                            case ShapeEnum.PaperRectangle:
                                shapes.Add(new PaperRectangle(
                                    double.Parse(childnodes[i].ChildNodes[2].InnerText),
                                    double.Parse(childnodes[i].ChildNodes[3].InnerText),
                                    ConvStrToColorEnum(childnodes[i].ChildNodes[4].InnerText)));
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            return shapes;
        }

        /// <summary>
        /// Prepear shape to xElement.
        /// </summary>
        /// <param name="shape">Shape object.</param>
        /// <param name="xElementsShapes">XElement with shepes</param>
        /// <param name="indexXElement">Index xElement</param>
        /// <returns>Reruns array shapes in array xml format.</returns>
        private static List<XElement> PrepareShapeToXml(BaseAbstractShape shape, List<XElement> xElementsShapes, int indexXElement)
        {
            string[] shapeParams = shape.ToString().Split(';');
            string[] squerePaperParams = { "Name", "Material", "Side", "Color" };
            string[] squereFilmParams = { "Name", "Material", "Side" };
            string[] rectanglePaperParams = { "Name", "Material", "Length", "Width", "Color" };
            string[] rectangleFilmParams = { "Name", "Material", "Length", "Width" };
            string[] circlePaperParams = { "Name", "Material", "Radius", "Color" };
            string[] circleFilmParams = { "Name", "Material", "Radius" };

            xElementsShapes.Add(new XElement(shapeParams[0]));
            XAttribute nameShape = new XAttribute("Name", shapeParams[0]);
            List<XElement> xElements = new List<XElement>();

            string typeOfShape = shapeParams[0];

            if (Enum.IsDefined(typeof(ShapeEnum), typeOfShape))
            {
                switch ((ShapeEnum)Enum.Parse(typeof(ShapeEnum), typeOfShape))
                {
                    case ShapeEnum.PaperCircle:
                        xElements = GetXElementShapeParams(circlePaperParams, shapeParams, "Circle", "Paper");
                        break;
                    case ShapeEnum.FilmCircle:
                        xElements = GetXElementShapeParams(circleFilmParams, shapeParams, "Circle", "Film");
                        break;
                    case ShapeEnum.PaperSquare:
                        xElements = GetXElementShapeParams(squerePaperParams, shapeParams, "Square", "Paper");
                        break;
                    case ShapeEnum.FilmSquare:
                        xElements = GetXElementShapeParams(squereFilmParams, shapeParams, "Square", "Film");
                        break;
                    case ShapeEnum.PaperRectangle:
                        xElements = GetXElementShapeParams(rectanglePaperParams, shapeParams, "Rectangle", "Paper");
                        break;
                    case ShapeEnum.FilmRectangle:
                        xElements = GetXElementShapeParams(rectangleFilmParams, shapeParams, "Rectangle", "Film");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new FormatException();
            }

            xElementsShapes[indexXElement].Add(nameShape);

            foreach (var item in xElements)
                xElementsShapes[indexXElement].Add(item);

            return xElementsShapes;
        }

        /// <summary>
        /// Converting string to enum color.
        /// </summary>
        /// <param name="shapeColor">Color ins string format.</param>
        /// <returns></returns>
        private static Color ConvStrToColorEnum(string shapeColor)
        {
            return (Color)Enum.Parse(typeof(Color), shapeColor);
        }

        private static List<XElement> GetXElementShapeParams(string[] shapeShapeParams, string[] shapeParams, string shapeName, string shapeMaterial)
        {
            List<XElement> xElements = new List<XElement>
            {
                new XElement(shapeShapeParams[0], shapeName),
                new XElement(shapeShapeParams[1], shapeMaterial)
            };

            for (int i = 2; i < shapeShapeParams.Length; i++)
                xElements.Add(new XElement(shapeShapeParams[i], shapeParams[i - 1]));

            return xElements;
        }

        /// <summary>
        /// Convert xElement array to xml document.
        /// </summary>
        /// <param name="xElements">Array xElement.</param>
        /// <param name="xElementName">Name of xElement.</param>
        /// <returns>Returns xDocement.</returns>
        private static XDocument ConvertXElementsToXDocument(List<XElement> xElements, string xElementName)
        {
            XDocument xdoc = new XDocument();
            XElement shapes = new XElement(xElementName);

            foreach (var item in xElements)
            {
                shapes.Add(item);
            }

            xdoc.Add(shapes);
            return xdoc;
        }

    }
}
