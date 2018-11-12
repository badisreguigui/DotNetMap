
using Domain.Entites;
using MAPINFINITY2.Areas.admin2.Models;
using Newtonsoft.Json;
using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MAPINFINITY2.Areas.admin2.Controllers
{
    public class MandateController : Controller
    {
        IMandateService MandatService = new MandateService();
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


            if (response.IsSuccessStatusCode)
            {

              liste = liste.Where(m =>m.MandateId==mandateId).ToList();

                if (liste != null) {
                   
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;

                    

                }

               

            }
            else
            {
                ViewBag.Message = "error";
            }

            return View(listeR);
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
            mandate m = new mandate();
            MandatService.Add(m);
            return View();

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
            return View();
        }

        // GET: admin2/Mandate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin2/Mandate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
