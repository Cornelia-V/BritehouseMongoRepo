using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using PagedList;
using PagedList.Mvc;
using BritehouseMongo.DomainLogic;
using BritehouseMongo.Infrastructure;
using BritehouseMongo.Infrastructure.Repository;
using System.Threading.Tasks;



namespace BritehouseMongo.Controllers
{
    public class PeopleController : Controller
    {
   
        private MongoConnect dBContext;
        private IMongoCollection<PeopleMod> peopleCollection;
        public PeopleRepo peopleRepo;
        


        // GET: people
        public PeopleController()
        {
            dBContext = new MongoConnect();
            peopleCollection = dBContext.database.GetCollection<PeopleMod>("people");
            peopleRepo = new PeopleRepo();
        }

        public async Task<ActionResult> DisplayAll()
        {
            //List<PeopleMod> myPeople = peopleCollection.AsQueryable<PeopleMod>().ToList();


            return View(await peopleRepo.GetAsync());
        }
    }

    
}