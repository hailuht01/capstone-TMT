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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Landmark/add")]
        public HttpResponseMessage Post(Landmark landmark)
        {
            

            if ( !(landmarkDAL.CreateLandmark(landmark) > 0) )
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
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