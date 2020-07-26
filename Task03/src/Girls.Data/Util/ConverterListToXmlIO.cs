using Shapes.Domain.Enum;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Girls.Data.Util
{
    public class ConverterListToXmlIO
    {
        public static XDocument AddFiguresInXml(BaseAbstractShape[] _figureList)
        {
            List<XElement> xElementsFigures = new List<XElement>();
            for (int i = 0; i < _figureList.Length; i++)
            {
                if (_figureList[i] != null)
                    PrepareFigureToXml(_figureList[i], xElementsFigures, i);
            }

            var xdoc = ConvertXElementsToXDocument(xElementsFigures, "Shapes");

            return xdoc;
        }

        public static XDocument AddFilmFiguresInXml(BaseAbstractShape[] _figureList)
        {
            List<XElement> xElementsFigures = new List<XElement>();
            int indexXElement = 0;

            for (int i = 0; i < _figureList.Length; i++)
            {
                if (_figureList[i] != null && _figureList[i] is IFilm)
                { 
                    PrepareFigureToXml(_figureList[i], xElementsFigures, indexXElement);
                    indexXElement++;
                }
            }

            var xdoc = ConvertXElementsToXDocument(xElementsFigures, "Shapes");
            return xdoc;
        }

        public static XDocument AddPaperFiguresInXml(BaseAbstractShape[] _figureList)
        {
            List<XElement> xElementsFigures = new List<XElement>();
            int indexXElement = 0;

            for (int i = 0; i < _figureList.Length; i++)
            {
                if (_figureList[i] != null && _figureList[i] is IPaper)
                {
                    PrepareFigureToXml(_figureList[i], xElementsFigures, indexXElement);
                    indexXElement++;
                }
            }
            var xdoc = ConvertXElementsToXDocument(xElementsFigures, "Shapes");
            return xdoc;
        }

        public static List<XElement> PrepareFigureToXml(BaseAbstractShape figure, List<XElement> xElementsFigures, int indexXElement)
        {
            string[] shapeParams = figure.ToString().Split(';');
            string[] squerePaperParams = { "Name", "Material", "Side", "Color" };
            string[] squereFilmParams = { "Name", "Material", "Side" };
            string[] rectanglePaperParams = { "Name", "Material", "Length", "Width", "Color" };
            string[] rectangleFilmParams = { "Name", "Material", "Length", "Width" };
            string[] circlePaperParams = { "Name", "Material", "Radius", "Color" };
            string[] circleFilmParams = { "Name", "Material", "Radius" };

            xElementsFigures.Add(new XElement(shapeParams[0]));
            XAttribute nameFigure = new XAttribute("Name", shapeParams[0]);
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

            xElementsFigures[indexXElement].Add(nameFigure);

            foreach (var item in xElements)
                xElementsFigures[indexXElement].Add(item);

            return xElementsFigures;
        }

        public static IEnumerable<BaseAbstractShape> ParsXmlDocToFigureList(XmlDocument xmlDocument)
        {
            List<BaseAbstractShape> figures = new List<BaseAbstractShape>();
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
                                figures.Add(new FilmCircle(double.Parse(childnodes[i].ChildNodes[2].InnerText)));
                                break;
                            case ShapeEnum.PaperCircle:
                                figures.Add(new PaperCircle(double.Parse(childnodes[i].ChildNodes[2].InnerText), ConvStrToColorEnum(childnodes[i].ChildNodes[3].InnerText)));
                                break;
                            case ShapeEnum.FilmSquare:
                                figures.Add(new FilmSquare(double.Parse(childnodes[i].ChildNodes[2].InnerText)));
                                break;
                            case ShapeEnum.PaperSquare:
                                figures.Add(new PaperSquare(double.Parse(childnodes[i].ChildNodes[2].InnerText), ConvStrToColorEnum(childnodes[i].ChildNodes[3].InnerText)));
                                break;
                            case ShapeEnum.FilmRectangle:
                                figures.Add(new FilmRectangle(
                                    double.Parse(childnodes[i].ChildNodes[2].InnerText), 
                                    double.Parse(childnodes[i].ChildNodes[3].InnerText)));
                                break;
                            case ShapeEnum.PaperRectangle:
                                figures.Add(new PaperRectangle(
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
            return figures;
        }

        private static Color ConvStrToColorEnum(string shapeColor)
        {
            return (Color)Enum.Parse(typeof(Color), shapeColor);
        }

        private static List<XElement> GetXElementShapeParams(string[] figureShapeParams, string[] shapeParams, string shapeName, string shapeMaterial)
        {
            List<XElement> xElements = new List<XElement>();
            xElements.Add(new XElement(figureShapeParams[0], shapeName));
            xElements.Add(new XElement(figureShapeParams[1], shapeMaterial));

            for (int i = 2; i < figureShapeParams.Length; i++)
                xElements.Add(new XElement(figureShapeParams[i], shapeParams[i - 1]));

            return xElements;
        }

        private static XDocument ConvertXElementsToXDocument(List<XElement> xElements, string xElementName)
        {
            XDocument xdoc = new XDocument();
            XElement figures = new XElement(xElementName);

            foreach (var item in xElements)
            {
                figures.Add(item);
            }

            xdoc.Add(figures);
            return xdoc;
        }

    }
}
