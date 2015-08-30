using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using InventWebService.BL;
//using MongoDB.Driver.Builders;

namespace InventWebService.Models
{
    public class InventoryPart 
    {
       
        public InventoryPart()
        {
            this.InvPartInStock = new HashSet<InventoryPartInStock>();
        }
        public InventoryPart(InventoryPart part)
        {
            this.InvPartInStock = new HashSet<InventoryPartInStock>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("part_no")]        
        public string part_no { get;set; }
        public string description {get; set;}        

        public virtual ICollection<InventoryPartInStock> InvPartInStock { get; set; }
    }
}