using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoDatosMasivos.Models
{
    public class EmpleadosModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("telefono")]
        public int Telefono { get; set; }

        [BsonElement("sexo")]
        public string Sexo { get; set; }

        [BsonElement("fechaNac")]
        public DateTime FechaNac { get; set; }

        [BsonElement("puesto")]
        public string Puesto { get; set; }
    }
}