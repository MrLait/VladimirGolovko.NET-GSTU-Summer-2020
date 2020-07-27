using Shapes.Data.UserException;
using Shapes.Data.Util;
using Shapes.Domain.Interfaces;
using Shapes.Domain.Shape.AbstractShapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes.Data.Repository
{
    /// <summary>
    /// Shape box class.
    /// </summary>
    public class ShapeBoxRepository
    {
        /// <summary>
        /// Box size.
        /// </summary>
        public const int MaxBoxSizeIsTwenty = 20;
        /// <summary>
        /// Property with BoxShapes array.
        /// </summary>
        public BaseAbstractShape[] BoxShapes { get; set; }

        /// <summary>
        /// Constructor for init shape box array.
        /// </summary>
        public ShapeBoxRepository()
        {
            BoxShapes = new BaseAbstractShape[MaxBoxSizeIsTwenty];
        }

        /// <summary>
        /// Add a shape, you cannot add the same shape twice.
        /// </summary>
        /// <param name="shape">Geometric shape.</param>
        public void AddShapeToBox(BaseAbstractShape shape)
        {
            if (shape == null)
                throw new ArgumentNullException("Shape is null");
            if (BoxShapes.Contains(shape))
                throw new BoxShapeException("The shape box already contains this shape");
            var boxShapeIsFull = true;

            for (int i = 0; i < BoxShapes.Length; i++)
            {
                if (BoxShapes[i] == null)
                {
                    BoxShapes[i] = shape;
                    boxShapeIsFull = false;
                    break;
                }
            }
            if (boxShapeIsFull)
                throw new BoxShapeException($"The box can't contain more then '{MaxBoxSizeIsTwenty}' shapes.");
        }

        /// <summary>
        /// View by number. The shape remains in the box.
        /// </summary>
        /// <param name="id">The id of the shape in the box.</param>
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
        /// Extract by number. The shape is removed from the box.
        /// </summary>
        /// <param name="id">The id of the shape in the box.</param>
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
        /// Replce shape in the box by id.
        /// </summary>
        /// <param name="id">The id shape in the box/</param>
        /// <param name="shape">The shape you want to place in the box.</param>
        public void ReplaceById(int id, BaseAbstractShape shape)
        {
            if (id < 0)
                throw new BoxShapeException("Id can't be less then zero");
            if (id > BoxShapes.Length - 1)
                throw new BoxShapeException($"Id can't be more then '{BoxShapes.Length - 1 }'.");

            BoxShapes[id] = shape;
        }

        /// <summary>
        ///Find a shape according to the pattern equivalent in its characteristics.
        /// </summary>
        /// <param name="shapePattern">Shape pattern.</param>
        /// <returns>Found shape according to the pattern.</returns>
        public BaseAbstractShape FindShapeByPattern(BaseAbstractShape shapePattern)
        {
            int index = BoxShapes.ToList().IndexOf(shapePattern);
            
            if (index == -1)
                throw new BoxShapeException("There is not such shape.");

            return FindShapeById(index);
        }

        /// <summary>
        ///Show available number of shapes.
        /// </summary>
        /// <returns>Number of shapes.</returns>
        public int GetNumOfShapesInBox()
        {
            int shapeCounter = 0;

            foreach (var item in BoxShapes)
            {
                if (item != null)
                    shapeCounter++;
            }

            return shapeCounter;
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
        /// Get all film shapes from the box.
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
        /// Save all shapes in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllShapesInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterArrayToXmlIO.AddShapesInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all film shapes in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFilmShapesInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterArrayToXmlIO.AddFilmShapesInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all paper shapes in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllPaperShapesInXmlUsingStreamWriter(string path)
        {
            StreamIO.SaveXmlDocumentUsingStreamWriter(ConverterArrayToXmlIO.AddPaperShapesInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all shapes in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllShapesInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterArrayToXmlIO.AddShapesInXml(BoxShapes), path);
        }

        /// <summary>
        /// Save of all film shapes in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllFilmShapesInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterArrayToXmlIO.AddFilmShapesInXml(BoxShapes), path);
        }
        /// <summary>
        /// Save of all paper shapes in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        public void SaveAllPaperShapesInXmlUsingXmlWriter(string path)
        {
            XmlIO.SaveXmlDocumentUsingXmlWriter(ConverterArrayToXmlIO.AddPaperShapesInXml(BoxShapes), path);
        }

        /// <summary>
        /// Load of all shapes to the box using Stream Reader.
        /// </summary>
        public void LoadAllShapesFromXmlUsingStreamReader(string path)
        {
            BoxShapes = ConverterArrayToXmlIO.ParsXmlDocToShapeList(StreamIO.LoadXmlDocumentUsingStreamReader(path)).ToArray();
        }

        /// <summary>
        /// Load of all shapes to the box using XML Reader.
        /// </summary>
        public void LoadAllShapesFromXmlUsingXmlReader(string path)
        {
            BoxShapes = ConverterArrayToXmlIO.ParsXmlDocToShapeList(XmlIO.LoadXmlDocumentUsingXmlReader(path)).ToArray();
        }
    }
}
