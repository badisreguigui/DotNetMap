using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {

     
        // GET: User
        public ActionResult Index()
        {
           /* List<UserViewModel> liste = new List<UserViewModel>();
            var listUser = ius.GetAll();
            foreach (var item in listUser)
            {
                UserViewModel userView = new UserViewModel();
                userView.name = item.name;
                userView.prenom = item.prenom;
                userView.age = item.age;
                userView.UtilisateurId = item.UtilisateurId;
                liste.Add(userView);
            }
            */
                return View();
        }


        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            /*   Utilisateur u = new Utilisateur();
               u.UtilisateurId = user.UtilisateurId;
               u.name = user.name;
               u.prenom = user.prenom;
               ius.Add(u);
               ius.Commit();

               try
               {

                   return RedirectToAction("Index");
               }
               catch
               {
                   return View();
               }
               */
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
