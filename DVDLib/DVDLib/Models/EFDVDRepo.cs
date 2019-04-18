using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLib.Models
{
    public class EFDVDRepo : IDVDRepo
    {
        public DVD Create(DVD dvd)
        {
            var repository = new DVDLibraryEntities();

            DVD model = repository.DVDs.Add(dvd);

            repository.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var repository = new DVDLibraryEntities();

            DVD model = repository.DVDs.FirstOrDefault(d => d.DvdId == id);

            repository.DVDs.Remove(model);

            repository.SaveChanges();
        }

        public DVD GetById(int id)
        {
            var repository = new DVDLibraryEntities();

            DVD model = repository.DVDs.FirstOrDefault(d => d.DvdId == id);


            return model;
        }

        public IEnumerable<DVD> Get()
        {
            var repository = new DVDLibraryEntities();
            return repository.DVDs;
        }

        public IEnumerable<DVD> GetByDirector(string director)
        {
            var repository = new DVDLibraryEntities();

           IEnumerable<DVD> model = repository.DVDs.Where(d => d.Director == director);


            return model;
        }

        public IEnumerable<DVD> GetByRating(string rating)
        {
            var repository = new DVDLibraryEntities();

            IEnumerable<DVD> model = repository.DVDs.Where(d => d.Rating == rating);


            return model;
        }

        public IEnumerable<DVD> GetByTitle(string title)
        {
            var repository = new DVDLibraryEntities();

            IEnumerable<DVD> model = repository.DVDs.Where(d => d.Title == title);


            return model;
        }

        public IEnumerable<DVD> GetByYear(string year)
        {
            var repository = new DVDLibraryEntities();

            IEnumerable<DVD> model = repository.DVDs.Where(d => d.RealeaseYear == year);


            return model;
        }

        public void Update(DVD dvd)
        {
            using (var ctx = new DVDLibraryEntities())
            {
                var result = ctx.DVDs.SingleOrDefault(d => d.DvdId == dvd.DvdId);
                if (result != null)
                {
                    result.DvdId = dvd.DvdId;
                    result.Title = dvd.Title;
                    result.RealeaseYear = dvd.RealeaseYear;
                    result.Director = dvd.Director;
                    result.Rating = dvd.Rating;
                    result.Notes = dvd.Notes;

                    ctx.SaveChanges();
                }
            }
        }
    }
}