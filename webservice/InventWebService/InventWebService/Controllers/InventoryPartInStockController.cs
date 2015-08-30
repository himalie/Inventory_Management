using InventWebService.BL;
using InventWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventWebService.Controllers
{
    public class InventoryPartInStockController : ApiController
    {
        IInventoryPartInStockRepository inventPartInStock = new InventoryPartInStockRepository();
        // GET api/inventorypartinstock
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse();

            List<InventoryPartInStock> partsInStock = inventPartInStock.GetInventoryPartsInStock();

            response = Request.CreateResponse(HttpStatusCode.OK, partsInStock);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // GET api/inventorypartinstock/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var response = Request.CreateResponse();
            List<InventoryPartInStock> parts = inventPartInStock.GetInStockPartByPart(id);

            response = Request.CreateResponse(HttpStatusCode.OK, parts);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // POST api/inventorypartinstock
        public void Post([FromBody]string value)
        {
        }

        // PUT api/inventorypartinstock/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/inventorypartinstock/5
        public void Delete(int id)
        {
        }
    }
}
