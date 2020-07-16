using Shapes.Data.Interfaces;
using Shapes.Data.Util;
using Shapes.Domain;
using Shapes.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Shapes.Data.Repositories
{
    public class TxtShapeRepository : IRepository<BaseShape>
    {
        private TxtFileReader _txtFileReader;

        public TxtShapeRepository(string pathToTxtFile)
        {
            _txtFileReader = new TxtFileReader(pathToTxtFile);
        }

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
