using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IMake
    {
        IEnumerable<Make> Get();
        Make Create(Make make);
      
        Make GetById(int? makeID);
    }
}
