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
            var animalId = new ObjectId(id);
            var animal = animalesCollection.AsQueryable<AnimalesModel>().SingleOrDefault(x => x.Id == animalId);
            return View(animal);
        }

        // GET: Animales/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Animales/Create
        [HttpPost]
        public ActionResult Create(AnimalesModel model)//AnimalesModel model)
        {
            try
            {
                animalesCollection.InsertOne(model);
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
            var animalId = new ObjectId(id);
            var animal = animalesCollection.AsQueryable<AnimalesModel>().SingleOrDefault(x => x.Id == animalId);
            return View(animal);
        }

        // POST: Animales/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AnimalesModel model)
        {
            try
            {
                var filter = Builders<AnimalesModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<AnimalesModel>.Update
                    .Set("nombre_comun", model.Nombre_comun)
                    .Set("nombre_cientifico", model.Nombre_cientifico)
                    .Set("familia", model.Familia)
                    .Set("especie", model.Especie)
                    .Set("peligro_ext", model.Peligro_extincion)
                    .Set("sexo", model.Sexo)
                    .Set("anio_Nac", model.Año_Nacimiento)
                    .Set("paisOrigen", model.PaisOrigen)
                    .Set("continente", model.Continente);
                var result = animalesCollection.UpdateOne(filter, update);
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
            var animalId = new ObjectId(id);
            var animal = animalesCollection.AsQueryable<AnimalesModel>().SingleOrDefault(x => x.Id == animalId);
            return View(animal);
        }

        // POST: Animales/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, AnimalesModel model)
        {
            try
            {
                animalesCollection.DeleteOne(Builders<AnimalesModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
