using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLib.Models
{
    public interface IDVDRepo  
    {
        DVD Create(DVD dvd);
        void Update(DVD dvd);
        void Delete(int id);
        DVD GetById(int id);
        IEnumerable<DVD> Get();
        IEnumerable<DVD> GetByTitle(string title);
        IEnumerable<DVD> GetByYear(string year);
        IEnumerable<DVD> GetByDirector(string director);
        IEnumerable<DVD> GetByRating(string rating);
    }
}