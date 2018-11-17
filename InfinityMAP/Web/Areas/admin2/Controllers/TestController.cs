using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Areas.admin2.Models;

namespace Web.Areas.admin2.Controllers
{
    public class TestController : Controller
    {
        public static List<Test> tests;
        public ActionResult Index()
        {

            return View("liste");
        }

        public ActionResult liste()
        {
            string category = "Technique"; 
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/listTests?category=" + category).Result;
            if (response.IsSuccessStatusCode)
            {
                tests = response.Content.ReadAsAsync<IEnumerable<Test>>().Result.ToList();
                ViewBag.tests = tests;

            }
            else
            {
                ViewBag.tests = "Error treating your request";
            }
            return View("liste");
        }
        public ActionResult addTest(string name)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/proposerTest?name="+name).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<Test>().Result; 
            }
            else
            {
                ViewBag.result = "Error treating your request";
            }
            return Json(ViewBag.result,
            JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadTests(string category)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/listTests?category=" + category).Result;
            if (response.IsSuccessStatusCode)
            {
                tests = response.Content.ReadAsAsync<IEnumerable<Test>>().Result.ToList();
            }
            else
            {
                ViewBag.tests = "Error treating your request";
            }
            return Json(tests,
            JsonRequestBehavior.AllowGet);
        }

        public ActionResult addQuestion(string testId, string question, string answer)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/ajouterQuestion?question="+question+"&answer="+answer+"&testId="+testId).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.question = response.Content.ReadAsAsync<Question>().Result;
            }
            else
            {
                ViewBag.question = "Error treating your request";
            }
            return Json(ViewBag.question,
            JsonRequestBehavior.AllowGet);
        } 

        public ActionResult searchTest(string search)
        {
            List<Test> returnedTests = new List<Test>();
            if (tests != null)
            {
                returnedTests = tests.Where(t => t.nom.ToUpper().Contains(search.ToUpper())).ToList();
            }

            return Json(returnedTests,
            JsonRequestBehavior.AllowGet); 
        }

        public ActionResult getTest(string idTest, string nom, string category)
        {
            ViewBag.idTest = idTest;
            ViewBag.nom = nom;
            ViewBag.category = category;
            return View("test");
        }

        public ActionResult getQuestions(string id)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/listeQuestions?testId="+id).Result;
            if (response.IsSuccessStatusCode)
            {
                Random rnd = new Random(); 
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Question>>().Result.OrderBy( item => rnd.Next() );
            }
            else
            {
                ViewBag.result = "Error treating your request";
            }
            return Json(ViewBag.result,
            JsonRequestBehavior.AllowGet);
        }

        public ActionResult answerQuestion(string applicantId, string questionId, string value)
        {
            string result; 
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/repondreQuestion?questionId=" + questionId + "&reponse=" + value + "&applicantId="+applicantId).Result;
            if (response.IsSuccessStatusCode)
            {
                 result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                 result = "error";
            }
            return Json(result,
           JsonRequestBehavior.AllowGet);
        }

        public ActionResult corrigerTest(string applicantId, string testId)
        {
            string result;
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/corrigerTest?testId=1&applicantId=3" /*+ testId+"&applicantId="+applicantId*/).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = "error";
            }
            return Json(result,
           JsonRequestBehavior.AllowGet);
        }


    }
}