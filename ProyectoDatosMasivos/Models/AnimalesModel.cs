using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ProyectoDatosMasivos.Models
{
    public class AnimalesModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nombre_comun")]
        public string Nombre_comun { get; set; }

        [BsonElement("nombre_cientifico")]
        public string Nombre_cientifico { get; set; }

        [BsonElement("familia")]
        public string Familia { get; set; }

        [BsonElement("especie")]
        public string Especie { get; set; }

        [BsonElement("peligro_ext")]
        public string Peligro_extincion { get; set; }

        [BsonElement("sexo")]
        public string Sexo { get; set; }

        [BsonElement("anio_Nac")]
        public int Año_Nacimiento { get; set; }

        [BsonElement("paisOrigen")]
        public string PaisOrigen { get; set; }

        [BsonElement("continente")]
        public string Continente { get; set; }
    }
}