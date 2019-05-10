using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using ProC.Model;

namespace ProC.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnectionWithCreateDatabase();

        bool GuardarPersona(Persona persona);

        List<Persona> GetPersonas();

        bool ActualizarPersona(Persona persona);

        void EliminarPersona(int Id);
    }
}
