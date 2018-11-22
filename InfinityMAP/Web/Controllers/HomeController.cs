using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Create");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();        
        }

      
        [HttpGet]
      
     
        public ActionResult LogIn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserViewModel user)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = Client.GetAsync("http://localhost:18080/InfinityMAP-web/rest/authentification/login?username=" + user.login + "&password=" + user.password).Result;
            var u = response.Content.ReadAsAsync<UserViewModel>().Result;
           if(!(u.client==null))
            {

                Session["idconnected"] = u.client.id;
                Session["Login"] = user.login;
                Session["clientName"] = u.client.nom;
                Session["role"]=u.role;
                Session["Token"] = u.token;
                return RedirectToAction("Index", "Projet", new { area = "admin2" });
            }

           else if (!(u.resource == null))
            {
                Session["idconnected"] = u.resource.id;
                Session["Login"] = user.login;
                Session["role"] = u.role;
                Session["Token"] = u.token;
                return RedirectToAction("Details", "Resource", new { id = u.resource.id });
            }
            else
            {
                Session["Erreur"] = "Verifier vos données";
            }
           
            return View();
          
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}