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
    public class ZooloficosController : Controller
    {
        private MongoDBContext dbContext;
        private IMongoCollection<ZoologicosModel> zooCollection;
        public ZooloficosController()
        {
            dbContext = new MongoDBContext();
            zooCollection = dbContext.database.GetCollection<ZoologicosModel>("zoologicos");
        }
        // GET: Zooloficos
        public ActionResult Index()
        {
            List<ZoologicosModel> zoo = zooCollection.AsQueryable<ZoologicosModel>().ToList();
            return View(zoo);
        }

        // GET: Zooloficos/Details/5
        public ActionResult Details(string id)
        {
            var zooId = new ObjectId(id);
            var zoo = zooCollection.AsQueryable<ZoologicosModel>().SingleOrDefault(x => x.Id == zooId);
            return View(zoo);
        }

        // GET: Zooloficos/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Zooloficos/Create
        [HttpPost]
        public ActionResult Create(ZoologicosModel model)
        {
            try
            {
                // TODO: Add insert logic here
                zooCollection.InsertOne(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zooloficos/Edit/5
        public ActionResult Edit(string id)
        {
            var zooId = new ObjectId(id);
            var zoo = zooCollection.AsQueryable<ZoologicosModel>().SingleOrDefault(x => x.Id == zooId);
            return View(zoo);
        }

        // POST: Zooloficos/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ZoologicosModel model)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<ZoologicosModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<ZoologicosModel>.Update
                    .Set("nombre", model.Nombre)
                    .Set("ciudad", model.Ciudad)
                    .Set("pais", model.Pais)
                    .Set("continente", model.Continente)
                    .Set("tamanoM2", model.TamanoM2)
                    .Set("encargado", model.Encargado)
                    .Set("cantidad_animales", model.Cantidad_animales);
                var result = zooCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zooloficos/Delete/5
        public ActionResult Delete(string id)
        {
            var zooId = new ObjectId(id);
            var zoo = zooCollection.AsQueryable<ZoologicosModel>().SingleOrDefault(x => x.Id == zooId);
            return View(zoo);
        }

        // POST: Zooloficos/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ZoologicosModel model)
        {
            try
            {
                // TODO: Add delete logic here
                zooCollection.DeleteOne(Builders<ZoologicosModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
