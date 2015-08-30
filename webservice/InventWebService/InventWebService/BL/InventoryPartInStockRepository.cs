using InventWebService.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventWebService.BL
{
    public class InventoryPartInStockRepository : IInventoryPartInStockRepository
    {
        MongoServer objServer;
        MongoDatabase objDatabse;
        MongoCollection<InventoryPartInStock> collection;
        public InventoryPartInStockRepository()
        {
            try
            {
                objServer = MongoServer.Create("Server=localhost:27017");
                objDatabse = objServer.GetDatabase("invent");
                collection = objDatabse.GetCollection<InventoryPartInStock>("invent");
            }

            catch (Exception ex)
            {
                throw;
            }
        }


        public Boolean InsertInventoryPartInStock(InventoryPartInStock inventPartInStock)
        {
            try
            {
                MongoCollection<InventoryPartInStock> part_coll = objDatabse.GetCollection<InventoryPartInStock>("invent");
                part_coll.Insert<InventoryPartInStock>(inventPartInStock);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<InventoryPartInStock> GetInventoryPartsInStock()
        {
            List<InventoryPartInStock> list = new List<InventoryPartInStock>();
            
            
            foreach (InventoryPartInStock prt in collection.FindAll())
            {
                list.Add(prt);
            }
            return list;
        }
        public List<InventoryPartInStock> GetInStockPartByPart(string id)
        {
            List<InventoryPartInStock> list = new List<InventoryPartInStock>();
            //var collection = objDatabse.GetCollection<InventoryPartInStock>("invent");

            //var filter = new BsonDocument("part_no", "P001");
            IMongoQuery query = Query.EQ("part_no", id);
            var part = collection.Find(query);
            foreach (InventoryPartInStock prt in part)
            {
                list.Add(prt);
            }
            return list;
        }
        public InventoryPartInStock GetPartBySerialNo(string serial_no)
        {
            List<InventoryPartInStock> list = new List<InventoryPartInStock>();
            //var collection = objDatabse.GetCollection<InventoryPartInStock>("invent");

            IMongoQuery query = Query.EQ("serial_no", serial_no);
            var part = collection.Find(query);
            return part.First();
        }
        public DateTime GetManufDate(string serial_no)
        {
            List<InventoryPartInStock> list = new List<InventoryPartInStock>();
            //var collection = objDatabse.GetCollection<InventoryPartInStock>("invent");

            IMongoQuery query = Query.EQ("serial_no", serial_no);
            var part = collection.Find(query);
            return part.First().manuf_date;
        }
        public DateTime GetExpiaryDate(string serial_no)
        {
            List<InventoryPartInStock> list = new List<InventoryPartInStock>();
            //var collection = objDatabse.GetCollection<InventoryPartInStock>("invent");

            IMongoQuery query = Query.EQ("serial_no", serial_no);
            var part = collection.Find(query);
            return part.First().expiary_date;
        }
    }
}