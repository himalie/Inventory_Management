using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventWebService.Models
{
    public class InventoryPartInStock
    {
        public InventoryPartInStock()
        { }
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }
        //public string part_no { get; set; }
        public string serial_no { get; set; }
        public DateTime manuf_date { get; set; }
        public DateTime expiary_date { get; set; }
        public DateTime stock_in_date { get; set; }
        public int quantity { set; get; }


       // public virtual InventoryPart InventPart { get; set; }
    }
}