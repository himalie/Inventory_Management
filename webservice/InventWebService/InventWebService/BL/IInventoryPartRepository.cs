using InventWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventWebService.BL
{
    public interface IInventoryPartRepository
    {
        Boolean InsertInventoryPart(InventoryPart inventPart);
        List<InventoryPart> GetInventoryParts();
        InventoryPart GetInventoryPartByPart(string id);
    }
}