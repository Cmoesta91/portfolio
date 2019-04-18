using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLib.Models
{
    public class DVDRepo : IDVDRepo
    {
        private static List<DVD> _DVD;

        static DVDRepo()
        {
            _DVD = new List<DVD>()
            {
                new DVD { Title="A Good Tale", RealeaseYear="2012", Director="Joe Smith", Rating="PG-13", Notes="This is a good tale!", DvdId=1 },
                new DVD { Title="A Great Tale", RealeaseYear="2015", Director="Sam Jones", Rating="PG", Notes="", DvdId=2 },
            };
        }

        public IEnumerable<DVD> Get()
        {

            return _DVD;
        }

        public DVD GetById(int DVDId)
        {
            return _DVD.FirstOrDefault(c => c.DvdId == DVDId);
        }

        public DVD Create(DVD newDVD)
        {
            if (_DVD.Any())
            {
                newDVD.DvdId = _DVD.Max(c => c.DvdId) + 1;
            }
            else
            {
                newDVD.DvdId = 0;
            }

            _DVD.Add(newDVD);
            return newDVD;
        }

        public void Update(DVD updatedDVD)
        {
            _DVD.RemoveAll(c => c.DvdId == updatedDVD.DvdId);
            _DVD.Add(updatedDVD);
        }

        public void Delete(int DVDId)
        {
            _DVD.RemoveAll(c => c.DvdId == DVDId);
        }

        public IEnumerable<DVD> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByYear(string year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByRating(string rating)
        {
            throw new NotImplementedException();
        }
    }
}