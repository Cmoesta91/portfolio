using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IModel
    {
        IEnumerable<Model> Get();
        Model Create(Model model);
        Model GetByID(int? id);
        IEnumerable<Model> GetByMakeID(int makeId);
    }
}