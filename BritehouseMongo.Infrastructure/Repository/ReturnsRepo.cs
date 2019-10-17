using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Britehouse.DomainLogic;
using Britehouse.DomainLogic.Interfaces;
using BritehouseMongo.DomainLogic;
using BritehouseMongo.Infrastructure;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BritehouseMongo.Infrastructure.Repository
{
    public class ReturnsRepo: IReturns
    {
        private MongoConnect context;

        private IMongoCollection<ReturnsMod> returnsCollection;
        public ReturnsRepo()
        {
            this.context = new MongoConnect();
        }
        public async Task<List<ReturnsMod>> GetAsync()
        {

            returnsCollection = context.database.GetCollection<ReturnsMod>("returns");
            List<ReturnsMod> myReturns = await returnsCollection.AsQueryable<ReturnsMod>().Take(10).ToListAsync();//.Where(e => e.Region == "Yes").ToListAsync();
            return myReturns;


        }

        
    }
   
}
