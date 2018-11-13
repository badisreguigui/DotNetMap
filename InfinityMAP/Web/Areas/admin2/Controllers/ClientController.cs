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
    public class ClientController : Controller
    {
        // GET: admin2/Client
        public ActionResult Index()
        {
            List<ClientViewModel> liste = new List<ClientViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.
            GetAsync("/InfinityMAP-web/rest/ClientService/afficherAllClients").Result;
            if (response.IsSuccessStatusCode)
            {
                var listeclients = response.Content.ReadAsAsync<IEnumerable<ClientViewModel>>().Result;
                foreach (var i in listeclients)
                {
                    ClientViewModel userView = new ClientViewModel();
                    userView.id = i.id;
                    userView.nom = i.nom;
                    userView.logo = i.logo;
                    userView.categorie = i.categorie;
                    userView.typeClient = i.typeClient;
                    liste.Add(userView);
                }
            }
            else
            {
                liste = null;
            }
                        return View(liste);
        }

        // GET: admin2/Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin2/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin2/Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel cl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client.
                PostAsJsonAsync("/InfinityMAP-web/rest/ClientService/addClient", cl).Result;

            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.  
                Console.WriteLine(response.Headers.Location);
                Console.WriteLine("ajouté");
            }
            Console.WriteLine("ajouté avec succes");
            return RedirectToAction("index");
        }

        // GET: admin2/Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin2/Client/Edit/5
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

        // GET: admin2/Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin2/Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ClientViewModel cl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client
                .PutAsJsonAsync("InfinityMAP-web/rest/ClientService/supprimerClient/" + id, cl).Result;
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.  
                Console.WriteLine(response.Headers.Location);
                Console.WriteLine("supprime");
            }
            else
            {
                ViewBag.result = "error";
            }
            return RedirectToAction("index");
        }
    }
    
}
