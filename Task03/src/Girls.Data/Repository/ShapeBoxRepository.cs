using Girls.Data.UserException;
using Girls.Data.Util;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girls.Data.Repository
{
    public class ShapeBoxRepository
    {
        public BaseAbstractShape[] BoxShapes { get; set; }

        public ShapeBoxRepository()
        {
            BoxShapes = new BaseAbstractShape[20];
        }

        /// <summary>
        /// Add a figure, you cannot add the same figure twice.
        /// </summary>
        /// <param name="shape">Geometric figure.</param>
        public void AddShapeToBox(BaseAbstractShape shape)
        {
            if (shape == null)
                throw new ArgumentNullException("Shape is null");
            if (BoxShapes.Contains(shape))
                throw new BoxShapeException("The shape box already contains this shape");

            for (int i = 0; i < BoxShapes.Length; i++)
            {
                if (BoxShapes[i] == null)
                {
                    BoxShapes[i] = shape;
                    break;
                }
            }
        }

        /// <summary>
        /// View by number. The figure remains in the box.
        /// </summary>
        /// <param name="id">The id of the figure in the box.</param>
        /// <returns>Shape that is found by id.</returns>
        public BaseAbstractShape FindShapeById(int id)
        {
            if (id < 0)
                throw new BoxShapeException("Id can't be less then zero");
            if (id > BoxShapes.Length-1)
                throw new BoxShapeException($"Id can't be more then '{BoxShapes.Length - 1 }'.");

            if (BoxShapes.ElementAt(id) == null)
                throw new BoxShapeException("There is not such shape.");

            return BoxShapes.ElementAt(id);
        }

        /// <summary>
        /// Extract by number. The figure is removed from the box.
        /// </summary>
        /// <param name="id">The id of the figure in the box.</param>
        /// <returns>Shape that is found by id.</returns>
        public BaseAbstractShape ExecuteShapeById(int id)
        {
            if (id < 0)
                throw new BoxShapeException("Id can't be less then zero");
            if (id > BoxShapes.Length - 1)
                throw new BoxShapeException($"Id can't be more then '{BoxShapes.Length - 1 }'.");

            BaseAbstractShape tmpShape = FindShapeById(id);

            BoxShapes[id] = null;
            return tmpShape;
        }

        /// <summary>
        /// Replce figure in the box by id.
        /// </summary>
        /// <param name="id">The id figure in the box/</param>
        /// <param name="figure">The figure you want to place in the box.</param>
        public void ReplaceById(int id, BaseAbstractShape figure)
        {
            if (id < 0)
                throw new BoxShapeException("Id can't be less then zero");
            if (id > BoxShapes.Length - 1)
                throw new BoxShapeException($"Id can't be more then '{BoxShapes.Length - 1 }'.");

            BoxShapes[id] = figure;
        }

        /// <summary>
        ///Find a figure according to the pattern equivalent in its characteristics.
        /// </summary>
        /// <param name="figurePattern">Shape pattern.</param>
        /// <returns>Found figure according to the pattern.</returns>
        public BaseAbstractShape FindShapeByPattern(BaseAbstractShape figurePattern)
        {
            int index = BoxShapes.ToList<BaseAbstractShape>().IndexOf(figurePattern);
            
            if (index == -1)
                throw new BoxShapeException("There is not such shape.");

            return FindShapeById(index);
        }

        /// <summary>
        ///Show available number of figures.
        /// </summary>
        /// <returns>Number of figures.</returns>
        public int GetNumOfShapesInBox()
        {
            int figureCounter = 0;

            foreach (var item in BoxShapes)
            {
                if (item != null)
                    figureCounter++;
            }

            return figureCounter;
        }

        /// <summary>
        /// Calculate the total area.
        /// </summary>
        /// <returns>The total area.</returns>
        public double GetTotalArea()
        {
            double tmpSumAreaShapes = 0;

            foreach (var item in BoxShapes)
            {
                if (item != null)
                    tmpSumAreaShapes += item.Area;
            }

            return tmpSumAreaShapes;
        }

        /// <summary>
        /// Calculate the total perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public double GetTotalPerimeter()
        {
            double tmpSumPerimeterShapes = 0;

            foreach (var item in BoxShapes)
            {
                if (item != null)
                    tmpSumPerimeterShapes += item.Perimeter;
            }

            return tmpSumPerimeterShapes;
        }

        /// <summary>
        /// Get all circles from the box.
        /// </summary>
        /// <returns>List of all circles from the box.</returns>
        public IEnumerable<AbstractCircle> GetAllCircles()
        {
            List<AbstractCircle> tmpCircleShapes = new List<AbstractCircle>();

            foreach (var item in BoxShapes)
            {
                if (item is AbstractCircle)
                    tmpCircleShapes.Add((AbstractCircle)item);
            }

            return tmpCircleShapes;
        }

        /// <summary>
        /// Get all film figures from the box.
        /// </summary>
        /// <returns>List of all film gigures from the box.</returns>
        public IEnumerable<BaseAbstractShape> GetAllFilmShapes()
        {
            List<BaseAbstractShape> tmpFilmShapes = new List<BaseAbstractShape>();

            foreach (var item in BoxShapes)
            {
                if (item is IFilm)
                    tmpFilmShapes.Add(item);
            }

            return tmpFilmShapes;
        }

        /// <summary>
        /// Save all figures in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFiguresInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all film figures in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFilmFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddFilmFiguresInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all paper figures in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllPaperFiguresInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterListToXmlIO.AddPaperFiguresInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all figures in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFiguresInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all film figures in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFilmFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddFilmFiguresInXml(BoxShapes), path);
        }
        /// <summary>
        /// Save of all paper figures in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllPaperFiguresInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterListToXmlIO.AddPaperFiguresInXml(BoxShapes), path);
        }

        /// <summary>
        /// Load of all figures to the box using Stream Reader.
        /// </summary>
        public void LoadAllFiguresFromXmlUsingStreamReader(string path)
        {
            BoxShapes = ConverterListToXmlIO.ParsXmlDocToFigureList(StreamIO.LoadXmlDocumentUsingStreamReader(path)).ToArray();
        }

        /// <summary>
        /// Load of all figures to the box using XML Reader.
        /// </summary>
        public void LoadAllFiguresFromXmlUsingXmlReader(string path)
        {
            BoxShapes = ConverterListToXmlIO.ParsXmlDocToFigureList(XmlIO.LoadXmlDocumentUsingXmlReader(path)).ToArray();
        }
    }
}
