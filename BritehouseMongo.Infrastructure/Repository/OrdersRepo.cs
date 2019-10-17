using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Britehouse.DomainLogic;
using Britehouse.DomainLogic.Interfaces;
using BritehouseMongo.DomainLogic;

namespace BritehouseMongo.Infrastructure.Repository
{
    public class OrdersRepo : IOrders
    {
        private MongoConnect context;

        private IMongoCollection<OrdersMod> ordersCollection;
        public OrdersRepo()
        {
            this.context = new MongoConnect();
        }
        
        public async Task<List<OrdersMod>> GetAsync()
        {
            
            ordersCollection = context.database.GetCollection<OrdersMod>("orders");
            var myOrders =  ordersCollection.AsQueryable<OrdersMod>().Where(e => e.RowID <= 10).Take(10).ToListAsync();
            return await myOrders;

           
        }

    }
}
