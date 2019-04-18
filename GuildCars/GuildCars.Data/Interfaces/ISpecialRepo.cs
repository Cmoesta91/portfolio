using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialRepo
    {
        IEnumerable<Special> Get();
        Special GetById(int id);
        Special Create(Special special);
        void Delete(int id);

    }
}
