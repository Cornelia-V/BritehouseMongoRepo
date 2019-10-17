using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Authenticator;
using BritehouseMongo.ViewModel;
using BritehouseMongo.Models;
using MongoDB.Driver;
using PagedList;
using PagedList.Mvc;
using Britehouse.DomainLogic;
using BritehouseMongo.App_Start;


namespace BritehouseMongo.Controllers 
{
    public class HomeController : Controller
    {
        private const string key = "iou274!*/a*1";
        private MongoConnect dBContext;
        private IMongoCollection<UserMod> userCollection;
        UserMod viewUser = new UserMod();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserMod user)
        {
            dBContext = new MongoConnect();
            userCollection = dBContext.database.GetCollection<UserMod>("users");
            userCollection.InsertOne(user);
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Login()
        {
            dBContext = new MongoConnect();
            userCollection = dBContext.database.GetCollection<UserMod>("users");
            return View();
        }
        public ActionResult DPeople()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            dBContext = new MongoConnect();
            userCollection = dBContext.database.GetCollection<UserMod>("users");

            string message = "";
            bool status = false;
            if (login.Username == "Admin@gmail.com" && login.Password == "Password1")
            {
                status = true;
                message = "Two-Factor Authentication";
                Session["Username"] = login.Username;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string UserUniqueKey = login.Username + key;
                Session["UserUniqueKey"] = UserUniqueKey;
                var setUpInfo = tfa.GenerateSetupCode("Dotnet awesome", login.Username, UserUniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setUpInfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setUpInfo.ManualEntryKey;
            }


            //var varE =  from x in userCollection.AsQueryable<UserMod>()
            //          where x.Email.Contains(login.Username) select x.Email ;
            //var varP = from x in userCollection.AsQueryable<UserMod>()
            //         where x.Password.Contains(login.Password)
            //         select x.Password;
            //Boolean adminU = false;
            //if (login.Username == "Admin@gmail.com")
            //{ adminU = true; }
            if (login.Username == "tester@gmail.com" && login.Password == "tester")
            {
                status = true;
                message = "Two-Factor Authentication";
                Session["Username"] = login.Username;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string UserUniqueKey = login.Username + key;
                Session["UserUniqueKey"] = UserUniqueKey;
                var setUpInfo = tfa.GenerateSetupCode("Dotnet awesome", login.Username, UserUniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setUpInfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setUpInfo.ManualEntryKey;
            }

            if (login.Username == "new@gmail.com" && login.Password == "new")
            {
                status = true;
                message = "Two-Factor Authentication";
                Session["Username"] = login.Username;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string UserUniqueKey = login.Username + key;
                Session["UserUniqueKey"] = UserUniqueKey;
                var setUpInfo = tfa.GenerateSetupCode("Dotnet awesome", login.Username, UserUniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setUpInfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setUpInfo.ManualEntryKey;
            }


            if (login.Username == "Admin@gmail.com" && login.Password == "Password1")
            {
                status = true;
                message = "Two-Factor Authentication";
                Session["Username"] = login.Username;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string UserUniqueKey = login.Username + key;
                Session["UserUniqueKey"] = UserUniqueKey;
                var setUpInfo = tfa.GenerateSetupCode("Dotnet awesome", login.Username, UserUniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setUpInfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setUpInfo.ManualEntryKey;
            }
            else
            {
                message = "User not found. Please ensure correct credentials were used.";
            }

            ViewBag.Message = message;
            ViewBag.Status = status;
            return View();
        }

        public ActionResult MyProfile()
        {
            dBContext = new MongoConnect();
            userCollection = dBContext.database.GetCollection<UserMod>("users");
            if (Session["Username"] == null || Session["IsValid2FA"] == null || !(bool)Session["IsValid2FA"])
            {
                return RedirectToAction("Login");

            }
            if ((bool)Session["IsValid2FA"] && !(bool)(Session["Username"] == "Admin@gmail.com"))
            {
                return RedirectToAction("NotAdmin", "peopleChart");
            }


            ViewBag.Message = "Welcome, " + Session["Username"].ToString();
            
            return View();
        }

        public ActionResult Verify2FA()
        {
           
            var token = Request["passcode"];
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string UserUniqueKey = Session["UserUniqueKey"].ToString();
            bool isValid = tfa.ValidateTwoFactorPIN(UserUniqueKey, token);
            if (isValid && !(Session["Username"] == "Admin@gmail.com"))
            {
                Session["IsValid2FA"] = true;
                return RedirectToAction("NotAdmin", "peopleChart");//"MyProfile", "Home"
            }
            if (isValid)
            {
                Session["IsValid2FA"] = true;
                return RedirectToAction("Index", "peopleChart");//"MyProfile", "Home"
            }
            return RedirectToAction("Index", "peopleChart");
        }
            
    }
}