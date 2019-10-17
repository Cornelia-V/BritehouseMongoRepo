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
    public class PeopleRepo: IPeople
    {
        private MongoConnect context;

        private IMongoCollection<PeopleMod> peopleCollection;
        public PeopleRepo()
        {
            this.context = new MongoConnect();
        }

        public async Task<List<PeopleMod>> GetAsync()
        {
            peopleCollection = context.database.GetCollection<PeopleMod>("people");
            List<PeopleMod> myOrders = await peopleCollection.AsQueryable<PeopleMod>().Where(x => x.Region.Contains("Africa")).Take(10).ToListAsync();
            return myOrders;
        }
    }

   
}
