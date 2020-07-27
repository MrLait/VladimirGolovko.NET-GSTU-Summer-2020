using Shapes.Domain.Shape.AbstractShapes;
using System.Collections.Generic;

namespace Shapes.Data.Repository
{
    /// <summary>
    /// interface Shape box class.
    /// </summary>
    public interface IShapeBoxRepository
    {
        /// <summary>
        /// Add a shape, you cannot add the same shape twice.
        /// </summary>
        /// <param name="shape">Geometric shape.</param>
        void AddShapeToBox(BaseAbstractShape shape);

        /// <summary>
        /// View by number. The shape remains in the box.
        /// </summary>
        /// <param name="id">The id of the shape in the box.</param>
        /// <returns>Shape that is found by id.</returns>
        BaseAbstractShape ExecuteShapeById(int id);

        /// <summary>
        /// View by number. The shape remains in the box.
        /// </summary>
        /// <param name="id">The id of the shape in the box.</param>
        /// <returns>Shape that is found by id.</returns>
        BaseAbstractShape FindShapeById(int id);

        /// <summary>
        ///Find a shape according to the pattern equivalent in its characteristics.
        /// </summary>
        /// <param name="shapePattern">Shape pattern.</param>
        /// <returns>Found shape according to the pattern.</returns>
        BaseAbstractShape FindShapeByPattern(BaseAbstractShape shapePattern);

        /// <summary>
        /// Get all circles from the box.
        /// </summary>
        /// <returns>List of all circles from the box.</returns>
        IEnumerable<AbstractCircle> GetAllCircles();
        /// <summary>
        /// Get all film shapes from the box.
        /// </summary>
        /// <returns>List of all film gigures from the box.</returns>
        IEnumerable<BaseAbstractShape> GetAllFilmShapes();

        /// <summary>
        ///Show available number of shapes.
        /// </summary>
        /// <returns>Number of shapes.</returns>
        int GetNumOfShapesInBox();

        /// <summary>
        /// Calculate the total area.
        /// </summary>
        /// <returns>The total area.</returns>
        double GetTotalArea();

        /// <summary>
        /// Calculate the total perimeter.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        double GetTotalPerimeter();

        /// <summary>
        /// Load of all shapes to the box using Stream Reader.
        /// </summary>
        void LoadAllShapesFromXmlUsingStreamReader(string path);

        /// <summary>
        /// Load of all shapes to the box using XML Reader.
        /// </summary>
        void LoadAllShapesFromXmlUsingXmlReader(string path);

        /// <summary>
        /// Replce shape in the box by id.
        /// </summary>
        /// <param name="id">The id shape in the box/</param>
        /// <param name="shape">The shape you want to place in the box.</param>
        void ReplaceById(int id, BaseAbstractShape shape);

        /// <summary>
        /// Save of all film shapes in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        void SaveAllFilmShapesInXmlUsingStreamWriter(string path);

        /// <summary>
        /// Save of all film shapes in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        void SaveAllFilmShapesInXmlUsingXmlWriter(string path);
        /// <summary>
        /// Save of all paper shapes in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        void SaveAllPaperShapesInXmlUsingStreamWriter(string path);

        /// <summary>
        /// Save of all paper shapes in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        void SaveAllPaperShapesInXmlUsingXmlWriter(string path);

        /// <summary>
        /// Save all shapes in XML format using Stream Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        void SaveAllShapesInXmlUsingStreamWriter(string path);

        /// <summary>
        /// Save of all shapes in XML format using XML Writer.
        /// </summary>
        /// <param name="path">Is the path to xml file.</param>
        void SaveAllShapesInXmlUsingXmlWriter(string path);
    }
}