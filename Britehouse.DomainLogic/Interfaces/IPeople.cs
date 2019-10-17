using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BritehouseMongo.DomainLogic;

namespace Britehouse.DomainLogic.Interfaces
{
    public interface IPeople
    {
        Task<List<PeopleMod>> GetAsync();
    }
}
