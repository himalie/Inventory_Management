using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventWebService.Models;

namespace InventWebService.BL
{
    public interface IInventoryPartInStockRepository
    {
        Boolean InsertInventoryPartInStock(InventoryPartInStock inventPart);
        List<InventoryPartInStock> GetInventoryPartsInStock();
        List<InventoryPartInStock> GetInStockPartByPart(string id);
        InventoryPartInStock GetPartBySerialNo(string serial_no);
        DateTime GetManufDate(string serial_no);
        DateTime GetExpiaryDate(string serial_no);        
    }
}