using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BritehouseMongo.DomainLogic;

namespace Britehouse.DomainLogic.Interfaces
{
    public interface IOrders
    {//get table get list
        Task<List<OrdersMod>> GetAsync();
    }
}
