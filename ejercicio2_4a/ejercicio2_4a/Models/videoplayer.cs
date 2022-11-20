using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio2_4a.Models
{
    public class videoplayer
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Path { get; set; }
        public DateTime fecha { get; set; }
    }
}
