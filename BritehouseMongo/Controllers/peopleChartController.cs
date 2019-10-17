using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BritehouseMongo.App_Start;
using BritehouseMongo.Models;
using MongoDB.Driver;
using PagedList;
using PagedList.Mvc;
using BritehouseMongo.ViewModel;
using Britehouse.DomainLogic;

namespace BritehouseMongo.Controllers
{
    public class peopleChartController : Controller
    {
        private MongoConnect dBContext;
        private IMongoCollection<PeopleMod1> peopleCollection;
        private IMongoCollection<ReturnsMod1> retCollection;

        private IMongoCollection<DomainLogic.OrdersMod> oCollection;
        private IMongoCollection<DomainLogic.PeopleMod> pCollection;
        private IMongoCollection<DomainLogic.ReturnsMod> rCollection;

        PeopleViewModelChart viewPpl = new PeopleViewModelChart();
        


        public peopleChartController()
        {
            dBContext = new MongoConnect();
            peopleCollection = dBContext.database.GetCollection<PeopleMod1>("people");
            retCollection = dBContext.database.GetCollection<ReturnsMod1>("returns");

            pCollection = dBContext.database.GetCollection<DomainLogic.PeopleMod>("people");
            rCollection = dBContext.database.GetCollection<DomainLogic.ReturnsMod>("returns");
            oCollection = dBContext.database.GetCollection<DomainLogic.OrdersMod>("orders");
        }
        public ActionResult Index()
        {
            List<PeopleMod1> myPeople = peopleCollection.AsQueryable<PeopleMod1>().ToList();
            int totalAfrica = (from x in myPeople.Where(x => x.Region.Contains("Africa")) select x.Person).Count();
            int Europe = (from x in myPeople.Where(x => x.Region.Contains("Europe")) select x.Person).Count();
            int USA = (from x in myPeople.Where(x => x.Region.Contains("US") || x.Region.Contains("America")) select x.Person).Count();
            int Asia = (from x in myPeople.Where(x => x.Region.Contains("Asia")) select x.Person).Count();
            int Oceania = (from x in myPeople.Where(x => x.Region.Contains("Oceania")) select x.Person).Count();
            int Caribbean = (from x in myPeople.Where(x => x.Region.Contains("Caribbean")) select x.Person).Count();
            //figure out how to group regions together
            // List<PeopleMod1> myPeople = peopleCollection.AsQueryable<PeopleMod1>().GroupBy((r => r.Region select r=> r.Region. Count();

            viewPpl.Africa_count = totalAfrica;
            viewPpl.Asia_count = Asia;
            viewPpl.Europe_count = Europe;
            viewPpl.Canada_count = Caribbean;
            viewPpl.USA_count = USA;
            viewPpl.Oceania_count = Oceania;

            List<ReturnsMod1> ret = retCollection.AsQueryable<ReturnsMod1>().ToList();
            double rAfrica = (from x in ret.Where(x => x.Region.Contains("Africa")) select x.OrderID).Count();
            double rEurope = (from x in ret.Where(x => x.Region.Contains("Europe")) select x.OrderID).Count();
            double rUSA = (from x in ret.Where(x => x.Region.Contains("US") || x.Region.Contains("America")) select x.OrderID).Count();
            double rAsia = (from x in ret.Where(x => x.Region.Contains("Asia")) select x.OrderID).Count();
            double rOceania = (from x in ret.Where(x => x.Region.Contains("Oceania")) select x.OrderID).Count();
            double rCaribbean = (from x in ret.Where(x => x.Region.Contains("Caribbean")) select x.OrderID).Count();

            viewPpl.AfricaR = rAfrica;
            viewPpl.AsiaR = rAsia;
            viewPpl.EuropeR = rEurope;
            viewPpl.CanadaR = rCaribbean;
            viewPpl.USAR = rUSA;
            viewPpl.OceaniaR = rOceania;

           List<DomainLogic.ReturnsMod> r = rCollection.AsQueryable<DomainLogic.ReturnsMod>().ToList();
            int rc = (from x in r.Where(x => x.Returned.Contains("yes")) select x.OrderID).Count();
            viewPpl.cr = rc;

            List<DomainLogic.PeopleMod> p = pCollection.AsQueryable<DomainLogic.PeopleMod>().ToList();
            int pc = (from x in p.Where(x => x.Person.Contains("")) select x.Person).Count();
            viewPpl.cp = pc;

            //List<DomainLogic.OrdersMod> o = oCollection.AsQueryable<DomainLogic.OrdersMod>().ToList();
            //int oc = (from x in o.Where(x => x.Region.Contains("")) select x.Region).Count();
            //viewPpl.co = oc;




            return View(viewPpl);
        }

        public ActionResult NotAdmin()
        {
            List<PeopleMod1> myPeople = peopleCollection.AsQueryable<PeopleMod1>().ToList();
            int totalAfrica = (from x in myPeople.Where(x => x.Region.Contains("Africa")) select x.Person).Count();
            int Europe = (from x in myPeople.Where(x => x.Region.Contains("Europe")) select x.Person).Count();
            int USA = (from x in myPeople.Where(x => x.Region.Contains("US") || x.Region.Contains("America")) select x.Person).Count();
            int Asia = (from x in myPeople.Where(x => x.Region.Contains("Asia")) select x.Person).Count();
            int Oceania = (from x in myPeople.Where(x => x.Region.Contains("Oceania")) select x.Person).Count();
            int Caribbean = (from x in myPeople.Where(x => x.Region.Contains("Caribbean")) select x.Person).Count();
            //figure out how to group regions together
            // List<PeopleMod1> myPeople = peopleCollection.AsQueryable<PeopleMod1>().GroupBy((r => r.Region select r=> r.Region. Count();

            viewPpl.Africa_count = totalAfrica;
            viewPpl.Asia_count = Asia;
            viewPpl.Europe_count = Europe;
            viewPpl.Canada_count = Caribbean;
            viewPpl.USA_count = USA;
            viewPpl.Oceania_count = Oceania;

            List<ReturnsMod1> ret = retCollection.AsQueryable<ReturnsMod1>().ToList();
            double rAfrica = (from x in ret.Where(x => x.Region.Contains("Africa")) select x.OrderID).Count();
            double rEurope = (from x in ret.Where(x => x.Region.Contains("Europe")) select x.OrderID).Count();
            double rUSA = (from x in ret.Where(x => x.Region.Contains("US") || x.Region.Contains("America")) select x.OrderID).Count();
            double rAsia = (from x in ret.Where(x => x.Region.Contains("Asia")) select x.OrderID).Count();
            double rOceania = (from x in ret.Where(x => x.Region.Contains("Oceania")) select x.OrderID).Count();
            double rCaribbean = (from x in ret.Where(x => x.Region.Contains("Caribbean")) select x.OrderID).Count();

            viewPpl.AfricaR = rAfrica;
            viewPpl.AsiaR = rAsia;
            viewPpl.EuropeR = rEurope;
            viewPpl.CanadaR = rCaribbean;
            viewPpl.USAR = rUSA;
            viewPpl.OceaniaR = rOceania;

            List<DomainLogic.ReturnsMod> r = rCollection.AsQueryable<DomainLogic.ReturnsMod>().ToList();
            int rc = (from x in r.Where(x => x.Returned.Contains("yes")) select x.OrderID).Count();
            viewPpl.cr = rc;

            List<DomainLogic.PeopleMod> p = pCollection.AsQueryable<DomainLogic.PeopleMod>().ToList();
            int pc = (from x in p.Where(x => x.Person.Contains("")) select x.Person).Count();
            viewPpl.cp = pc;

            //List<DomainLogic.OrdersMod> o = oCollection.AsQueryable<DomainLogic.OrdersMod>().ToList();
            //int oc = (from x in o.Where(x => x.Region.Contains("")) select x.Region).Count();
            //viewPpl.co = oc;




            return View(viewPpl);
        }
    }
}