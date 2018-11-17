using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.admin2.Controllers
{
    public class ProjetController : Controller
    {
        List<ProjetViewModel> liste = new List<ProjetViewModel>();

        /*var clients = from a in service.GetAll() select a;
        if (!String.IsNullOrEmpty(SearchString))
        {*/

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:18080");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ProjetService/afficherAllProjets").Result;
        var listeclients = response.Content.ReadAsAsync<IEnumerable<ProjetViewModel>>().Result;
        PagedList<ProjetViewModel> projetpaged = new PagedList<ProjetViewModel>(listeclients, page, pageSize);

            if (response.IsSuccessStatusCode)
            {
                foreach (var i in projetpaged)
                {
                    ProjetViewModel userView = new ProjetViewModel();
        userView.id = i.id;
                    userView.nom = i.nom;
                    userView.date_fin = i.date_fin;
                    userView.date_debut = i.date_debut;
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
            
            return View(projetpaged);


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
