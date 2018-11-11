using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult Index()
        {
            List<ResourceViewModel> listResourceViewModels = new List<ResourceViewModel>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/InfinityMAP-web/rest/ResourceService/getResources").Result;
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
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(ResourceViewModel r)
        {
            resource r1 = new resource();
            r1.lastname = r.lastname;
            r1.firstname = r.firstname;
            r1.contractype = r.contractype;
            r1.picture = r.picture;
            r1.profil = r.profil;
            r1.sector = r.sector;
            r1.seniority = r.seniority;
            r1.state = r.state;
            r1.region = r.region;
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.PostAsJsonAsync<resource>("/InfinityMAP-web/rest/ResourceService/addResource", r1).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
      
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resource/Edit/5
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

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resource/Delete/5
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
