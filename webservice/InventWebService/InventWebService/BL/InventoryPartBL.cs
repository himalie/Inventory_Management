using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventWebService.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;

namespace InventWebService.BL
{
    public class InventoryPartBL 
    {
        MongoServer objServer;
        MongoDatabase objDatabse;

        public InventoryPartBL()
        {

            objServer = MongoServer.Create("Server=localhost:27017");
            objDatabse = objServer.GetDatabase("invent");
        }

        public Boolean InsertInventoryPart(InventoryPart inventPart)
        {
            try
            {
                MongoCollection<InventoryPart> part_coll = objDatabse.GetCollection<InventoryPart>("invent");
                part_coll.Insert<InventoryPart>(inventPart);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public List<InventoryPart> GetInventoryParts()
        {
            
                List<InventoryPart> list = new List<InventoryPart>();
                var collection = objDatabse.GetCollection<InventoryPart>("invent");
                var test = collection.FindAllAs<InventoryPart>();
                foreach (InventoryPart prt in collection.FindAll())
                {
                    list.Add(prt);
                }
                return list;
            
        }
        public InventoryPart GetInventoryPartByPart(string id)
        {

            List<InventoryPart> list = new List<InventoryPart>();
            var collection = objDatabse.GetCollection<InventoryPart>("invent");

            var filter = new BsonDocument("part_no", "P001");
            IMongoQuery query = Query.EQ("part_no", "P001");
            var part = collection.Find(query);            
            return part.First();

        }
    }
}