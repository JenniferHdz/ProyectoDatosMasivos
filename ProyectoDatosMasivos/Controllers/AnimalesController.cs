using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Configuration;
using ProyectoDatosMasivos.App_Start;
using ProyectoDatosMasivos.Models;

namespace ProyectoDatosMasivos.Controllers
{
    public class AnimalesController : Controller
    {
        private MongoDBContext dbContext;
        private IMongoCollection<AnimalesModel> animalesCollection;
        public AnimalesController()
        {
            dbContext = new MongoDBContext();
            animalesCollection = dbContext.database.GetCollection<AnimalesModel>("animales");
        }

        // GET: Animales
        public ActionResult Index()
        {
            List<AnimalesModel> animales = animalesCollection.AsQueryable<AnimalesModel>().ToList();
            return View(animales);
        }

        // GET: Animales/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Animales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animales/Create
        [HttpPost]
        public ActionResult Create(FormCollection model)//AnimalesModel model)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw;
            }
        }

        // GET: Animales/Edit/5
        public ActionResult Edit(string id)
        {
            
            return View();
        }

        // POST: Animales/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection model)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animales/Delete/5
        public ActionResult Delete(string id)
        {
            
            return View();
        }

        // POST: Animales/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection model)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
