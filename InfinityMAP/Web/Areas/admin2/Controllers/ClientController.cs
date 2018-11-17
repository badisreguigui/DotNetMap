using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Areas.admin2.Models;
using PagedList;


namespace Web.Areas.admin2.Controllers
{
    public class ClientController : Controller
    {
        List<ClientViewModel> liste = new List<ClientViewModel>();
        // GET: admin2/Client
        public ActionResult Index(int page = 1, int pageSize = 4)
        {
            /*var clients = from a in service.GetAll() select a;
            if (!String.IsNullOrEmpty(searchBy))
            {*/

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ClientService/afficherAllClients").Result;
            var listeclients = response.Content.ReadAsAsync<IEnumerable<ClientViewModel>>().Result;
            PagedList<ClientViewModel> clientpaged = new PagedList<ClientViewModel>(listeclients, page, pageSize);

            if (response.IsSuccessStatusCode)
            {
                foreach (var i in clientpaged)
                {
                    ClientViewModel userView = new ClientViewModel();
                    userView.id = i.id;
                    userView.nom = i.nom;
                    userView.logo = i.logo;
                    userView.categorie = i.categorie;
                    userView.typeClient = i.typeClient;
                    liste.Add(userView);
                }
                //clients = clients.Where(s => s.nom.Contains(searchBy));
            }
            else
            {
                liste = null;
            }

            return View(clientpaged);


        }


        // GET: admin2/Client/Details/5
        public ActionResult Details(int id)
        {
            ClientViewModel clientV = new ClientViewModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ClientService/findclById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                clientV = response.Content.ReadAsAsync<ClientViewModel>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(clientV);
        }

        // GET: admin2/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin2/Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel cl, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string filename = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(Server.MapPath("~/Image"), filename);
                ImageFile.SaveAs(path);
                cl.logo = filename;
            }
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
            ClientViewModel clientV = new ClientViewModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ClientService/findclById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                clientV = response.Content.ReadAsAsync<ClientViewModel>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(clientV);
        }


        // POST: admin2/Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientViewModel cl)
        {

            ClientViewModel c = new ClientViewModel();

            c.id = cl.id;
            c.nom = cl.nom;
            c.logo = cl.logo;
            c.categorie = cl.categorie;
            c.typeClient = cl.typeClient;
            object data = new
            {
                nom = c.nom,
                logo = c.logo,
                categorie = c.categorie,
                typeClient = c.typeClient
            };
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = Client.PutAsync("InfinityMAP-web/rest/ClientService/modifierClient/" + id, byteContent).Result;
            return RedirectToAction("index");
        }

        // GET: admin2/Client/Delete/5
        public ActionResult Delete(int id)
        {
            ClientViewModel clientV = new ClientViewModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ClientService/findclById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                clientV = response.Content.ReadAsAsync<ClientViewModel>().Result;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(clientV);
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

