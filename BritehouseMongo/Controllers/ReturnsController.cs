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

namespace BritehouseMongo.Controllers
{
    public class ReturnsController : Controller
    {
        private MongoConnect dBContext;
        private IMongoCollection<ReturnsMod> returnsCollection;
        private ReturnsRepo returnsRepo;
        

        public ReturnsController()
        {
            dBContext = new MongoConnect();
            returnsCollection = dBContext.database.GetCollection<ReturnsMod>("returns");
            returnsRepo = new ReturnsRepo();
        }
         public async Task<ActionResult> DisplayReturns()
        {
            //List<ReturnsMod> myReturns = returnsCollection.AsQueryable<ReturnsMod>().ToList();


            return View(await returnsRepo.GetAsync());
        }
    }
    }
