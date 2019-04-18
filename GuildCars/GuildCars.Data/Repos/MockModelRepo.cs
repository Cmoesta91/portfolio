using GuildCars.Data.Interfaces;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GuildCars.Data.Repos
{
    public class MockModelRepo : IModel
    {
        private static List<Model> _model;

        static MockModelRepo()
        {

            _model = new List<Model>
            {
                new Model
                {
                    ModelID = 1,
                    ModelName = "Civic",
                    MakeID = 1,
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Model
                {
                    ModelID = 2,
                    ModelName = "F-150",
                    MakeID = 2,
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Model
                {
                    ModelID = 3,
                    ModelName = "Wrangler",
                    MakeID = 3,
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },
                
                new Model
                {
                    ModelID = 4,
                    ModelName = "Grand Vitara",
                    MakeID = 4,
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Model
                {
                    ModelID = 5,
                    ModelName = "X5",
                    MakeID = 5,
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Model
                {
                    ModelID = 6,
                    ModelName = "Model X",
                    MakeID = 6,
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                }

            };

        }

        public Model Create(Model newModel)
        {
            if (_model.Any())
            {
                newModel.ModelID = _model.Max(c => c.ModelID) + 1;
            }
            else
            {
                newModel.ModelID = 0;
            }

            _model.Add(newModel);
            return newModel;
        }

        public IEnumerable<Model> Get()
        {
            return _model;
        }

        public Model GetByID(int? id)
        {
            return _model.FirstOrDefault(m => m.ModelID == id);
        }

        public IEnumerable<Model> GetByMakeID(int makeId)
        {
            return _model.Where(m => m.MakeID == makeId);
        }
    }
}