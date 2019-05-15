namespace ProC.Model
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Persona
    {
        //El modelo es el objeto Persona
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        [Unique]
        public string Correo { get; set; }
    }
}
