using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoDatosMasivos.Models
{
    public class ZoologicosModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("ciudad")]
        public string Ciudad { get; set; }

        [BsonElement("pais")]
        public string Pais { get; set; }

        [BsonElement("continente")]
        public string Continente { get; set; }

        [BsonElement("tamanoM2")]
        public string TamanoM2 { get; set; }

        [BsonElement("encargado")]
        public string Encargado { get; set; }

        [BsonElement("cantidad_animales")]
        public int Cantidad_animales { get; set; }
    }
}