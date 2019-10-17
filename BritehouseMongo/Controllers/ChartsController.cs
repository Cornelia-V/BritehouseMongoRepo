using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using BritehouseMongo.Models;
using BritehouseMongo.App_Start;

namespace BritehouseMongo.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        private MongoConnect dBContext;
        private IMongoCollection<PeopleMod1> peopleCollection;

        public ActionResult Index()
        {
            dBContext = new MongoConnect();
            peopleCollection = dBContext.database.GetCollection<PeopleMod1>("people");
            List<PeopleMod1> myPeople = peopleCollection.AsQueryable<PeopleMod1>().ToList();

            
                return View(myPeople);
            
        }
    }
}