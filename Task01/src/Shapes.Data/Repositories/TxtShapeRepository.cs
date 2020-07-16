using Shapes.Data.Interfaces;
using Shapes.Data.Util;
using Shapes.Domain;
using Shapes.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Shapes.Data.Repositories
{
    /// <summary>
    /// A class to get all shapes from a text file in array.
    /// </summary>
    public class TxtShapeRepository : IRepository<BaseShape>
    {
        /// <summary>
        /// Field TxtFileReader
        /// </summary>
        private TxtFileReader _txtFileReader;

        /// <summary>
        /// Constructor to initialize field _txtFileReader.
        /// </summary>
        /// <param name="pathToTxtFile">Parameter path to the file.</param>
        public TxtShapeRepository(string pathToTxtFile)
        {
            _txtFileReader = new TxtFileReader(pathToTxtFile);
        }

        /// <summary>
        /// Method to parsing txt file in object array. 
        /// </summary>
        /// <returns>Returns IEnumerable list with shapes.</returns>
        public IEnumerable<BaseShape> GetShapeList()
        {
            string[] dataFromTxt = _txtFileReader.GetAllRow();
            List<BaseShape> shapes = new List<BaseShape>();

            try
            {
                foreach (var rowItem in dataFromTxt)
                {
                    string[] shapeParameters = rowItem.Split(';');

                    string typeOfShape = shapeParameters[0];

                    if (Enum.IsDefined(typeof(ShapeEnum), typeOfShape))
                    {
                        switch ((ShapeEnum)Enum.Parse(typeof(ShapeEnum), typeOfShape))
                        {
                            case ShapeEnum.Circle:
                                shapes.Add(new Circle(Convert.ToDouble(shapeParameters[1])));
                                break;
                            case ShapeEnum.Rectangle:
                                shapes.Add(new Rectangle(Convert.ToDouble(shapeParameters[1]), Convert.ToDouble(shapeParameters[2])));
                                break;
                            case ShapeEnum.Square:
                                shapes.Add(new Square(Convert.ToDouble(shapeParameters[1])));
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
                throw new FormatException("The input string was in the wrong format.");
            }
            return shapes;
        }
    }
}
