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
    public class ApplicantRequestController : Controller
    {
        // GET: ApplicantRequest
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/listRequest").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsStringAsync().Result;
                string[] parts = ViewBag.result.Split('|');
                if (parts[0].Equals("success"))
                {
                    List<ApplicantRequest> requests = new List<ApplicantRequest>(); 
                    for (int i = 2; i < parts.Length; i++)
                    {
                        string[] elements = parts[i].Split('/'); 
                        ApplicantRequest applicantRequest = new ApplicantRequest();
                        try
                        {
                            applicantRequest.requestId = Int32.Parse(elements[0]);
                            applicantRequest.date = DateTime.Parse(elements[1]);
                            applicantRequest.speciality = elements[2];
                            applicantRequest.state = elements[3];
                            
                            requests.Add(applicantRequest); 
                        }
                        catch (FormatException e)
                        {
                            //Response.Write("requestId " + elements[0]);
                            Console.WriteLine(e.Message);
                        }
                    }
                    ViewBag.requests = requests;
                    ViewBag.result = parts[1]; 
                }
                else
                {
                    ViewBag.result = parts[1];
                }
            }
            else
            {
                ViewBag.result = "error";
            }
            return View("liste");
        }
        public ActionResult create()
        {
          //  Response.Write("aa");
            return View("Create");
        }
        [HttpPost]
        public ActionResult AddRequest(string speciality, string ApplicantId)
        {
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/sendRequest?applicantId="+ApplicantId+"&speciality="+speciality).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsStringAsync().Result;// + speciality;
                string[] parts = ViewBag.result.Split('|');
                if (parts[0].Equals("success"))
                {
                    ViewBag.result = "Votre requête a été enregistrée. Son identifiant est " + parts[1] + " ";
                    ViewBag.id = parts[1]; 
                    ViewBag.testResult = true; 
                }
                else
                {
                    ViewBag.result = parts[1];
                    //ViewBag.testResult = false;
                }
            }
            else
            {
                ViewBag.result = "error";
            }
            return View("Create");
        }
    
        public ActionResult GetRequest(string id)
        {
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/suiviRequest?requestId="+id).Result;
            
            if (response.IsSuccessStatusCode)
            {
                ViewBag.request = response.Content.ReadAsAsync<ApplicantRequest>().Result;
            }
            else
            {
                ViewBag.request = "error";
            }
            return View("Create");
        }

        public ActionResult DeleteRequest(string applicantId, string requestId)
        {
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/cancelRequest?requestId="+requestId+"&applicantId=" + applicantId).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.requestState = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.requestState = "erreur de suppression";
            }
            return View("Create");
        }

        public ActionResult TraiterDemande(string date, string requestId, string reponse)
        {
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/traiterDemande?requestId=" + requestId+"&reponse="+reponse+"&dateRdv="+date).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            // return View("liste");
            return Json(ViewBag.result,
            JsonRequestBehavior.AllowGet);

        }
        public ActionResult Mailbox()
        {
            return View("Mailbox"); 
        }
        public ActionResult EnvoyerMail(string contenu)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/ApplicantRequestService/envoyerMail?contenu=" + contenu).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                ViewBag.result = "Error sending mail";
            }
            return Json(ViewBag.result,
           JsonRequestBehavior.AllowGet);
        }

        public ActionResult censurerMail(string contenu)
        {
            string[] grosMots = { "Merde", "Connard" };
            string[] listeMots = contenu.Split(' ');
            string contenuCensure = "";
            bool ajouter; 
            foreach (string mot in listeMots)
            {
                ajouter = true;
                foreach (string grosMot in grosMots)
                {
                    if (mot.ToUpper().Contains(grosMot.ToUpper()))
                        ajouter = false;
                }
                if (ajouter)
                {
                    contenuCensure += mot + " ";
                }
                else
                {
                    contenuCensure += "***** ";
                }
            }
            return Json(contenuCensure,
           JsonRequestBehavior.AllowGet);
        }

    }
}