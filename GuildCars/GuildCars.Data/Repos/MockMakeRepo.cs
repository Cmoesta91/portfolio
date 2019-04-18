using GuildCars.Data.Interfaces;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace GuildCars.Data.Repos
{
    public class MockMakeRepo : IMake
    {
        private static List<Make> _make;

        static MockMakeRepo()
        {

            _make = new List<Make>()
            {

                new Make
                {
                    MakeID = 1,
                    MakeName = "Honda",
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Make
                {
                    MakeID = 2,
                    MakeName = "Ford",
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Make
                {
                    MakeID = 3,
                    MakeName = "Jeep",
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Make
                {
                    MakeID = 4,
                    MakeName = "Suzuki",
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Make
                {
                    MakeID = 5,
                    MakeName = "BMW",
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

                new Make
                {
                    MakeID = 6,
                    MakeName = "Tesla",
                    DateAdded = DateTime.ParseExact ("11/20/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    UserId = "1"
                },

            };
            
        }

        public Make Create(Make newMake)
        {
            if (_make.Any())
            {
                newMake.MakeID = _make.Max(c => c.MakeID) + 1;
            }
            else
            {
                newMake.MakeID = 0;
            }

            _make.Add(newMake);
            return newMake;
        }

        public IEnumerable<Make> Get()
        {
            return _make;
        }

        public Make GetById(int? id)
        {
            return _make.FirstOrDefault(c => c.MakeID == id); ;
        }
    }
}