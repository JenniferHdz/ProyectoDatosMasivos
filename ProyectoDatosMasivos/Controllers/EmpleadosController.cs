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
    public class EmpleadosController : Controller
    {
        private MongoDBContext dbContext;
        private IMongoCollection<EmpleadosModel> empleadoCollection;
        public EmpleadosController()
        {
            dbContext = new MongoDBContext();
            empleadoCollection = dbContext.database.GetCollection<EmpleadosModel>("empleado");
        }
        // GET: Empleados
        public ActionResult Index()
        {
            List<EmpleadosModel> empleado = empleadoCollection.AsQueryable<EmpleadosModel>().ToList();
            return View(empleado);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(string id)
        {
            var empleadoId = new ObjectId(id);
            var empleado = empleadoCollection.AsQueryable<EmpleadosModel>().SingleOrDefault(x => x.Id == empleadoId);
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(EmpleadosModel model)
        {
            try
            {
                // TODO: Add insert logic here
                empleadoCollection.InsertOne(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string id)
        {
            var empleadoId = new ObjectId(id);
            var empleado = empleadoCollection.AsQueryable<EmpleadosModel>().SingleOrDefault(x => x.Id == empleadoId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, EmpleadosModel model)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<EmpleadosModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<EmpleadosModel>.Update
                    .Set("nombre", model.Nombre)
                    .Set("telefono", model.Telefono)
                    .Set("sexo", model.Sexo)
                    .Set("fechaNac", model.FechaNac)
                    .Set("puesto", model.Puesto);
                var result = empleadoCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string id)
        {
            var empleadoId = new ObjectId(id);
            var empleado = empleadoCollection.AsQueryable<EmpleadosModel>().SingleOrDefault(x => x.Id == empleadoId);
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, EmpleadosModel model)
        {
            try
            {
                // TODO: Add delete logic here
                empleadoCollection.DeleteOne(Builders<EmpleadosModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
