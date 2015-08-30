using InventWebService.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventWebService.BL
{
    public class InventoryPartRepository :IInventoryPartRepository
    {
        MongoServer objServer;
        MongoDatabase objDatabse;

        public InventoryPartRepository()
        {            
            try
            {
                objServer = MongoServer.Create("Server=localhost:27017");
                objDatabse = objServer.GetDatabase("invent");                                
            }

            catch (Exception ex)
            {
                throw;
            }
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

            IMongoQuery query = Query.EQ("part_no", id);
            var part = collection.Find(query);            
            return part.First();

        }
    }
}