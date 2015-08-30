using InventWebService.Models;
using InventWebService.BL;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InventWebService.Controllers
{
    public class InventoryPartController : ApiController
    {
        IInventoryPartRepository inventory_part = new InventoryPartRepository();
        // GET api/inventorypart
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse();

            List<InventoryPart> parts = inventory_part.GetInventoryParts();

            response = Request.CreateResponse(HttpStatusCode.OK, parts);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // GET api/inventorypart/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse();
            InventoryPart part = inventory_part.GetInventoryPartByPart(id);

            response = Request.CreateResponse(HttpStatusCode.OK, part);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post(InventoryPart part)
        {
            if (!this.ModelState.IsValid)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));

            Boolean result = inventory_part.InsertInventoryPart(part);            

            HttpContext context = HttpContext.Current;

            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            return response;
        }

        // PUT api/inventorypart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/inventorypart/5
        public void Delete(int id)
        {
        }
    }
}
