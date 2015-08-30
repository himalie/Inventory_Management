using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Web;
using InventWebService.Models;
using InventWebService.BL;

namespace InventWebService.Controllers
{
    public class ValuesController : ApiController
    {
        //InventoryPartBL invPart = new InventoryPartBL();
        InventoryPartRepository partt = new InventoryPartRepository();
        //IRepository<InventoryPart> partt = new MongoDbRepository<InventoryPart>();
        // GET api/values
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse();

           // InventoryPart p = invPart.GetInventoryPartByPart("1");
            IList<InventoryPart> pp = partt.GetInventoryParts();
            response = Request.CreateResponse(HttpStatusCode.OK, pp);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse();
            //Console.WriteLine(" consoleeee");
            //// create a client connection
            //var cal = new MongoClient();
            //// fetch a particular db
            //var db = cal.GetDatabase("invent");
            //// retrieve a collection from the db
            //var col = db.GetCollection<BsonDocument>("invent");
            //var part = new List<InventoryPart>();

            //var doc = new BsonDocument { {"part_no", "P002"}, {"description", "part two"} };
            //MongoCollection
            //col.InsertOneAsync(doc);


            // find
            //col = db.GetCollection<BsonDocument>("invent");
            //var filter = new BsonDocument("part_no", "P001");
            //var list = col.Find(filter).ToListAsync();
           
            //var t = list.ToJson();
           // Console.WriteLine(list);


            //////MongoServer objServer = MongoServer.Create("Server=localhost:27017");
            //////MongoDatabase objDatabse = objServer.GetDatabase("invent");
            ////////List<InventoryPart> parts = objDatabse.GetCollection("invent").FindAll().ToBsonDocument()();
            //////List<InventoryPart> list = new List<InventoryPart>();
            //////var collection = objDatabse.GetCollection<InventoryPart>("invent");
            //////var test = collection.FindAllAs<InventoryPart>();
            //////foreach (InventoryPart emp in collection.FindAll())
            //////{
            //////    list.Add(emp);
            //////}

           // var list = invPart.GetInventoryParts();
            var list = partt.GetInventoryParts();
            
            //return list;


            //-------------- comming return part for http
            HttpContext context = HttpContext.Current;

            response = Request.CreateResponse(HttpStatusCode.OK, list);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post(InventoryPart part)
        {
            if (!this.ModelState.IsValid)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));

            //invPart.InsertInventoryPart(part);
            partt.InsertInventoryPart(part);

            HttpContext context = HttpContext.Current;

            var response = Request.CreateResponse(HttpStatusCode.Created, true);
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}