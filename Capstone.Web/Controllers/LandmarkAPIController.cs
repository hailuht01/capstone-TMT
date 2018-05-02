using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone.Web.Controllers
{
    public class LandmarkAPIController : ApiController
    {
        ILandmarkDAL landmarkDAL;
        public LandmarkAPIController(ILandmarkDAL _landmarkDAL)
        {
            this.landmarkDAL = _landmarkDAL;
        }

        // GET api/<controller>
        public Landmark Get()
        {
            return new Landmark() { };
        }

        // GET api/<controller>/5
        [Route("api/Landmark/id")]
        public Landmark Get(string id)
        {
            return landmarkDAL.GetLandmark(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}