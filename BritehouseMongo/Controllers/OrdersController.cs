using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
//using BritehouseMongo.Models;
//using BritehouseMongo.App_Start;
using PagedList;
using PagedList.Mvc;
//using BritehouseMongo.ViewModels;
//using BritehouseMongo.App_Start;
using BritehouseMongo.DomainLogic;
using BritehouseMongo.Infrastructure;
using BritehouseMongo.Infrastructure.Repository;
using System.Threading.Tasks;
using BritehouseMongo.Controllers;

namespace BritehouseMongo.Controllers
{
    public class OrdersController : Controller
    {

        private MongoConnect dBContext;
        private IMongoCollection<OrdersMod> ordersCollection;
        private OrdersRepo ordersRepo;
       

        public OrdersController()
        {
            dBContext = new MongoConnect();
            ordersCollection = dBContext.database.GetCollection<OrdersMod>("orders");
            ordersRepo = new OrdersRepo();
            
        }

        public async Task<ActionResult> DisplayOrders()
        {
            // return Task<List<OrdersMod>> GetAsync();
           

            return View(await ordersRepo.GetAsync() );
        }
    }
}