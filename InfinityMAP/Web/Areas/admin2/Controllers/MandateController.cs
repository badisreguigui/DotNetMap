
using Domain.Entites;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;

using Service;
using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Areas.admin2.Models;

namespace Web.Areas.admin2.Controllers
{
    public class MandateController : Controller
    {
        IMandateService MandatService = new MandateService();
        IHistoriqueService HistorriqueService = new HistoriqueService();
        public ActionResult viewMap()
        {

          
            return View();

        }
        // GET: admin2/Mandate
        public ActionResult Index()
        {
           
            List<MandateViewModel> liste = new List<MandateViewModel>();
         
            
            HttpClient Client= new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/mandate/ListeMandats").Result;
      
            if (response.IsSuccessStatusCode)
            {
               var listeMandat= response.Content.ReadAsAsync<IEnumerable<mandate>>().Result;
            
                foreach (var i in listeMandat)
                {
                    MandateViewModel userView = new MandateViewModel();
                    userView.Facture = i.Facture;
                    userView.MandateId = i.MandateId;
                    userView.NomMandat= i.NomMandat;
                    userView.date_end_mandate= i.date_end_mandate;
                    userView.date_start_mandate = i.date_start_mandate;
                    userView.etat = i.etat;
             
                    liste.Add(userView);
                }

            }
            else
            {
                liste = null;
            }
            return View(liste);

        }
    
        public ActionResult calculFactureMandat(int mandateId)
        {

            List<MandateViewModel> liste = new List<MandateViewModel>();
            List<ResourceViewModel> listeR = new List<ResourceViewModel>();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://127.0.0.1:18080/InfinityMAP-web/rest/mandate/calculFacture?mandateId="+mandateId).Result;


            return RedirectToAction("Edit/"+mandateId);

         
        }

        //public ActionResult ExportPDF()
        //{
        //    ActionAsPdf result = new ActionAsPdf("calculFactureTotale")
        //    {
        //        FileName = Server.MapPath("~/Content/Facture.pdf")

        //    };
        //    return result;
        //}


           public ActionResult calculFactureTotale()
        {

            List<mandate> liste = new List<mandate>();
            List<MandateViewModel> liste1 = new List<MandateViewModel>();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://127.0.0.1:18080/InfinityMAP-web/rest/mandate/calculFactureTotal?resourceId="+15).Result;


            if (response.IsSuccessStatusCode)
            {
                liste = MandatService.GetAll().Where(m => m.resource.id == 15).ToList();
                foreach (var i in liste)
                {
                    MandateViewModel userView = new MandateViewModel();
                    userView.Facture = i.Facture;
                    userView.MandateId = i.MandateId;
                    userView.NomMandat = i.NomMandat;
                    userView.date_end_mandate = i.date_end_mandate;
                    userView.date_start_mandate = i.date_start_mandate;
                    userView.etat = i.etat;

                    liste1.Add(userView);
                }

                if (liste != null) {
                   
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                }
           }
            else
            {
                ViewBag.Message = "error";
            }

            return View(liste1);
        }


        [HttpPost]
        public ActionResult Index(DateTime dateDebutMandat,DateTime dateFinMandat,string nomMandat)
        {
            List<MandateViewModel> liste = new List<MandateViewModel>();


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/mandate/ListeMandats").Result;
            if (response.IsSuccessStatusCode)
            {
                var listeMandat = response.Content.ReadAsAsync<IEnumerable<mandate>>().Result;
                foreach (var i in listeMandat)
                {
                    MandateViewModel userView = new MandateViewModel();
                    userView.Facture = i.Facture;
                    userView.MandateId = i.MandateId;
                    userView.NomMandat = i.NomMandat;
                    userView.date_end_mandate = i.date_end_mandate;
                    userView.date_start_mandate = i.date_start_mandate;
                    liste.Add(userView);
                }

            }
            if (!String.IsNullOrEmpty(dateDebutMandat.ToString()) && !String.IsNullOrEmpty(dateFinMandat.ToString()) &&!String.IsNullOrEmpty(nomMandat))
            {
                liste = liste.Where(m => m.date_start_mandate.Equals(dateDebutMandat))
                    .Where(m1=>m1.date_end_mandate.Equals(dateFinMandat)).Where(m2=>m2.NomMandat.Equals(nomMandat)).ToList();


            }
        
            return View(liste);
        }

        // GET: admin2/Mandate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin2/Mandate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin2/Mandate/Edit/5

        public ActionResult Edit(int id)
        {
            List<MandateViewModel> liste = new List<MandateViewModel>();

            ResourceViewModel r = new ResourceViewModel();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/mandate/ListeMandats").Result;
         
            if (response.IsSuccessStatusCode)
            {
                var listeMandat = response.Content.ReadAsAsync<IEnumerable<mandate>>().Result;
       
                foreach (var i in listeMandat)
                {
                    HttpResponseMessage response2 = Client.GetAsync("InfinityMAP-web/rest/mandate/serachResource?mandatId=" + i.MandateId).Result;

                    string responseString = response2.Content.ReadAsStringAsync().Result;
                    JObject r2 = JObject.Parse(responseString);
          
                   var s= JsonConvert.DeserializeObject<ResourceViewModel>(r2.ToString());


                    MandateViewModel userView = new MandateViewModel();
                    userView.resource = r;
                    userView.Facture = i.Facture;
                    userView.MandateId = i.MandateId;
                    userView.NomMandat = i.NomMandat;
                    userView.date_end_mandate = i.date_end_mandate;
                    userView.date_start_mandate = i.date_start_mandate;
                    r = s;
                    userView.resource= r;
                    liste.Add(userView);
                    List<mandate> m = new List<mandate>();

                    m = r.mandates.ToList();


                    ViewBag.resourceId = r.id;


                    ViewBag.data = m;
                    ViewBag.count = m.Count;


                }

            }
         
            MandateViewModel m3 = new MandateViewModel();
           m3 = liste.Find(x => x.MandateId==id);

            return View(m3);

        }

        // POST: admin2/Mandate/Edit/5
        [HttpPost]
        public ActionResult Edit(MandateViewModel mandate,int id)
        {
            mandate m = new mandate();
            m.date_end_mandate = mandate.date_end_mandate;
            m.date_start_mandate = mandate.date_start_mandate;
            m.MandateId = mandate.MandateId;
            object data = new
            {
                date_start_mandate =m.date_start_mandate,
               date_end_mandate =m.date_end_mandate
        };
        HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = Client.PutAsync("InfinityMAP-web/rest/mandate/UpdateMandat/"+id, byteContent).Result;
            return RedirectToAction("historique",new { mandatId = id });
        }
        
        public ActionResult historique(int mandatId)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/mandate/deleteMandate?mandateId=" + mandatId).Result;
            List<HistoriqueAssignationMandatViewModel> historique = new List<HistoriqueAssignationMandatViewModel>();
            foreach (var i in HistorriqueService.GetAll())
            {
                HistoriqueAssignationMandatViewModel historique2 = new HistoriqueAssignationMandatViewModel();


                historique2.etatMandat = i.etatMandat;
                historique2.HeureSauvegarde = i.HeureSauvegarde;
                historique2.action = i.action;
                historique.Add(historique2);
            }

                return View(historique);
        }
        //public ActionResult ExportExcel()
        //{
        //    ExcelPackage pck = new ExcelPackage();
        //    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Historique");

        //    return result;
        //}




    }
}
