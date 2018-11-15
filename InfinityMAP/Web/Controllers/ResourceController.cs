using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Service;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Web.Controllers
{
    public class ResourceController : Controller
    {
        IResourceService rs = new ResourceService();
        // GET: Resource
        public ActionResult Index()
        {
            List<ResourceViewModel> listResourceViewModels = new List<ResourceViewModel>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ResourceService/filterResources").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<resource>>().Result;
                foreach (var resource in ViewBag.result)
                {

                    ResourceViewModel resourceViewModel = new ResourceViewModel();
                    resourceViewModel.lastname = resource.lastname;
                    resourceViewModel.firstname = resource.firstname;
                    resourceViewModel.profil = resource.profil;
                    resourceViewModel.contractype = resource.contractype;


                    listResourceViewModels.Add(resourceViewModel);

                }
            }
            else
            {
                ViewBag.result = "error";
            }
            return View(listResourceViewModels);
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            ResourceViewModelDetails r = new ResourceViewModelDetails();

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/ResourceService/detailsResources/" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                r = response.Content.ReadAsAsync<ResourceViewModelDetails>().Result;

            }
            else { ViewBag.result = "erreur"; }
            return View(r);

        }



        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(ResourceViewModel r, HttpPostedFileBase ImageFile)
        {

            //string filename = Path.GetFileNameWithoutExtension(r.ImageFile.FileName);
            //string extension = Path.GetExtension(r.ImageFile.FileName);
            //filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            //r.picture = "~/Web/Image/" + filename;
            //filename = Path.Combine(Server.MapPath("~/Web/Image/"), filename);
            //r.ImageFile.SaveAs(filename);
            if (ImageFile != null)
            {
                string filename = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(Server.MapPath("~/Image"), filename);
                ImageFile.SaveAs(path);
                r.picture = filename;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PostAsJsonAsync<ResourceViewModel>("/InfinityMAP-web/rest/ResourceService/addResource", r).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");

        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {

            ResourceViewModelDetails r = new ResourceViewModelDetails();

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/ResourceService/detailsResources/" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                r = response.Content.ReadAsAsync<ResourceViewModelDetails>().Result;

            }
            else { ViewBag.result = "erreur"; }
            return View(r);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ResourceViewModelDetails rd, HttpPostedFileBase ImageFile)
        {
            ResourceViewModelDetails r = new ResourceViewModelDetails();
            r.id = rd.id;
            r.lastname = rd.lastname;
            r.firstname = rd.firstname;
            r.profil = rd.profil;
            r.region = rd.region;
            r.sector = rd.sector;
            r.state = rd.state;
            r.seniority = rd.seniority;
            r.contractype = rd.contractype;

            if (ImageFile != null)
            {
                string filename = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(Server.MapPath("~/Image"), filename);
                ImageFile.SaveAs(path);
                r.picture = filename;
            }
            object data = new
            {
                lastname = r.lastname,
                firstname = r.firstname,
                profil = r.profil,
                region = r.region,
                sector = r.sector,
                state = r.state,
                seniority = r.seniority,
                contractype = r.contractype,
                picture = r.picture,

            };
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                var myContent = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client
                    .PutAsJsonAsync("InfinityMAP-web/rest/ResourceService/updateResource/" + id, r).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    Console.WriteLine("modifie");
                }
                else
                {
                    ViewBag.result = "error";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ResourceViewModel r)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client
                .PutAsJsonAsync("/InfinityMAP-web/rest/ResourceService/deleteResource/" + id, r).Result;
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.  
                Console.WriteLine(response.Headers.Location);
                Console.WriteLine("deleted");
            }
            else
            {
                ViewBag.result = "error";
            }

            return RedirectToAction("Index");

        }

        // GET: Filter
        [HttpGet]
        public ActionResult Filter(ResourceViewModelDetails rv)
        {

            string url = "/InfinityMAP-web/rest/ResourceService/filterResources";
            if (rv.firstname != "")
            {
                url = url + "&firstname=" + rv.firstname;
            }
            else
            {
                Console.WriteLine("prenom null");
            }
            if (rv.lastname != "")
            {
                url = url + "&lastname=" + rv.lastname;
            }
            else
            {
                Console.WriteLine("nom null");
            }
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.result = response.Content.ReadAsAsync<ResourceViewModel>().Result;

            }
            else { ViewBag.result = "erreur"; }
            return View();

        }

        // GET: Calendar
        [HttpGet]
        public ActionResult Calendar()
        {
            return View();
        }
        public JsonResult GetVacations()
        {
            VacationService vs = new VacationService();

            List<vacationViewModel> liste = new List<vacationViewModel>();
            var listUser = vs.GetAll();
            foreach (var item in listUser)
            {
                vacationViewModel userView = new vacationViewModel();
                userView.id = item.id;
                userView.dateStart = item.dateStart;
                userView.dateEnd = item.dateEnd;
                liste.Add(userView);
            }
            return Json(liste, JsonRequestBehavior.AllowGet);


        }

    }
}
