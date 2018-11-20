using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.admin2.Models;
using PagedList;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Web.Areas.admin2.Controllers
{
    public class ProjetController : Controller
    {
        // GET: admin2/Projet
        public ActionResult Index()
        {
            List<ProjetViewModel> liste = new List<ProjetViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ProjetService/findListPByIdClient/"+Session["idconnected"]).Result;
            var listeclients = response.Content.ReadAsAsync<IEnumerable<ProjetViewModel>>().Result;
           
          
                if (response.IsSuccessStatusCode)
                {
                    foreach (var i in listeclients)
                    {
                        ProjetViewModel userView = new ProjetViewModel();
                        userView.id = i.id;
                        userView.nom = i.nom;
                        userView.projetEndDate = i.projetEndDate;
                        userView.projetStartDate = i.projetStartDate;
                        userView.statut = i.statut;
                        userView.client_id = i.client_id;
                        liste.Add(userView);
                    }

                    //clients = clients.Where(s => s.nom.Contains(searchBy));
                }
                else
                {
                    liste = null;
                }
                
            


            // projetpaged =  projetpaged.Where(s => s.nom.Contains(SearchString));

            return View(liste);


        }

        // GET: admin2/Projet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin2/Projet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin2/Projet/Create
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

        // GET: admin2/Projet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin2/Projet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin2/Projet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin2/Projet/Delete/5
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