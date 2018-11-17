using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Areas.admin2.Models;

namespace Web.Areas.admin2.Controllers
{
    public class ResourceRequestController : Controller
    {
        // GET: ResourceRequest
     
        public ActionResult Index()
        {
            List<ResourceRequestViewModel> liste = new List<ResourceRequestViewModel>();


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("InfinityMAP-web/rest/ResourceRequestService/getResourceRequest").Result;
            if (response.IsSuccessStatusCode)
            {
                var listeResourceRequest = response.Content.ReadAsAsync<IEnumerable<resourcerequest>>().Result;
                foreach (var i in listeResourceRequest)
                {
                    ResourceRequestViewModel userView = new ResourceRequestViewModel();
                    userView.Title = i.Title;
                    userView.requestId = i.requestId;
                    userView.requirements = i.requirements;
                    userView.searchedProfile = i.searchedProfile;
                    userView.yearsOfExperience = i.yearsOfExperience;
                    userView.client= i.client;
                    liste.Add(userView);
                }

            }
            else
            {
                liste = null;
            }
            return View(liste);
        }

        // GET: ResourceRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: ResourceRequest/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ResourceRequest/Create
        [HttpPost]
        public ActionResult Create(ResourceRequestViewModel resourceRequest )
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

        // GET: ResourceRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResourceRequest/Edit/5
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

        // GET: ResourceRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResourceRequest/Delete/5
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
