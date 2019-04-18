using GuildCars.Data.Interfaces;
using GuildCars.Models;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class APIController : ApiController
    {
        public ICarRepo MockCarRepo = Factory.Create();
        public IModel MockModelRepo = Factory.ModelRepo();

        [AcceptVerbs("GET")]
        [Route("api/inventory/search/{searchtype}/{term}/{minPriceBar}/{maxPriceBar}/{minYearBar}/{maxYearBar}")]
        public IHttpActionResult FindCar(string searchtype, string term, decimal minPriceBar, decimal maxPriceBar, string minYearBar, string maxYearBar)
        {
            IEnumerable<Car> found = MockCarRepo.Search(searchtype, term, minPriceBar, maxPriceBar, minYearBar, maxYearBar);

            if(found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [AcceptVerbs("GET")]
        [Route("api/admin/modellist/{makeId}")]
        public IHttpActionResult FindModel(int makeId)
        {
            IEnumerable<Model> found = MockModelRepo.GetByMakeID(makeId);

            if(found == null)
            {
                return NotFound();
            }
            return Ok(found);

        }

    }
   
}
