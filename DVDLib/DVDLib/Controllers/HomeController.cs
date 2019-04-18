using DVDLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLib.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.Get());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.GetById(id));

        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(string title)
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.GetByTitle(title));

        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(string year)
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.GetByYear(year));

        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.GetByDirector(director));

        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.GetByRating(rating));

        }

        [Route("dvd/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add([FromBody] DVD dvd)
        {
            IDVDRepo repo = Factory.Create();
            return Ok(repo.Create(dvd));
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(DVD dvd)
        {
            IDVDRepo repo = Factory.Create();
            repo.Update(dvd);

        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            IDVDRepo repo = Factory.Create();
            repo.Delete(id);
        }
    }
}
