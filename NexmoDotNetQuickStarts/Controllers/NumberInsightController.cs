using System.Web.Mvc;
using NumberInsight = Nexmo.Api.NumberInsight;

namespace NexmoDotNetQuickStarts.Controllers
{
    public class NumberInsightController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        [HttpGet]
        public ActionResult Basic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Basic(string number)
        {
            var results = NumberInsight.RequestBasic(new NumberInsight.NumberInsightBasicRequest
            {
                Number = number,
            });

            Session["requestID"] = results.RequestId;
            Session["iNumber"] = results.InternationalFormatNumber;
            Session["nNumber"] = results.NationalFormatNumber;
            Session["status"] = results.StatusMessage;
            Session["country"] = results.CountryName;
            Session["countryCode"] = results.CountryCode;

            return RedirectToAction("BasicResults");
        }

        [HttpGet]
        public ActionResult BasicResults()
        {
            ViewBag.requestID = Session["requestID"];
            ViewBag.iNumber = Session["iNumber"];
            ViewBag.nNumber = Session["nNumber"];
            ViewBag.status = Session["status"];
            ViewBag.country = Session["country"];
            ViewBag.countryCode = Session["countryCode"];
            return View();
        }


        [HttpGet]
        public ActionResult Standard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Standard(string number)
        {
            var results = NumberInsight.RequestStandard(new NumberInsight.NumberInsightBasicRequest()
            {
                Number = number,
            });
            Session["requestID"] =  results.RequestId;
            Session["iNumber"] = results.InternationalFormatNumber;
            Session["nNumber"] = results.NationalFormatNumber;
            Session["country"] = results.CountryName;
            Session["countryCode"] = results.CountryCode;
            Session["status"] = results.StatusMessage;
            Session["currentCarrierName"] = results.CurrentCarrier.Name;
            Session["currentCarrierCode"] = results.CurrentCarrier.NetworkCode;
            Session["currentCarrierType"] = results.CurrentCarrier.NetworkType;
            Session["currentCarrierCountry"] = results.CurrentCarrier.Country;
            Session["originalCarrierName"] = results.OriginalCarrier.Name;
            Session["originalCarrierCode"] = results.OriginalCarrier.NetworkCode;
            Session["originalCarrierType"] = results.OriginalCarrier.NetworkType;
            Session["originalCarrierCountry"] = results.OriginalCarrier.Country;
            Session["callerType"] = results.CallerType;
            Session["callerName"] = results.CallerName;
            Session["callerFirstName"] = results.FirstName;
            Session["callerLastName"] = results.LastName;



            return RedirectToAction("StandardResults");
        }

        [HttpGet]
        public ActionResult StandardResults()
        {
            ViewBag.requestID = Session["requestID"];
            ViewBag.iNumber = Session["iNumber"];
            ViewBag.nNumber = Session["nNumber"];
            ViewBag.status = Session["status"];
            ViewBag.country = Session["country"];
            ViewBag.countryCode = Session["countryCode"];
            ViewBag.currentCarrierName = Session["currentCarrierName"];
            ViewBag.currentCarrierCode = Session["currentCarrierCode"];
            ViewBag.currentCarrierType = Session["currentCarrierType"];
            ViewBag.currentCarrierCountry = Session["currentCarrierCountry"];
            ViewBag.originalCarrierName = Session["originalCarrierName"];
            ViewBag.originalCarrierCode = Session["originalCarrierCode"];
            ViewBag.originalCarrierType = Session["originalCarrierType"];
            ViewBag.originalCarrierCountry = Session["originalCarrierCountry"];
            ViewBag.callerType = Session["callerType"];
            ViewBag.callerName = Session["callerName"];
            ViewBag.callerFirstName = Session["callerFirstName"];
            ViewBag.callerLastName = Session["callerLastName"];
            return View();
        }

        [HttpGet]
        public ActionResult Advanced()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Advanced(string number)
        {
            var results = NumberInsight.RequestAdvanced(new NumberInsight.NumberInsightAdvancedRequest()
            {
                Number = number,
            });
            Session["numberValidity"] = results.NumberValidity;
            Session["numberReachability"] = results.NumberReachability;
            Session["roamingStatus"] = results.RoamingInformation.Roamingstatus;

            return RedirectToAction("AdvancedResults");
        }

        [HttpGet]
        public ActionResult AdvancedResults()
        {
            ViewBag.numberValidity = Session["numberValidity"];
            ViewBag.numberReachability = Session["numberReachability"];
            ViewBag.roamingStatus = Session["roamingStatus"];

            return View();
        }

    }
}