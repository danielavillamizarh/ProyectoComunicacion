using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProC.Model;
using ProC;
using SQLite;
using Xamarin.Forms;
using ProC.Services;
using ProC.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace ProC.Droid
{
    class SQLite_Android : ISQLite
    {
        SQLiteConnection con;
        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string fileName = "MilagroDB.db";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<Persona>();
            return con;
        }
        public bool GuardarPersona(Persona persona)
        {
            bool res = false;
            try
            {
                con.Insert(persona);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;

        }
        public List<Persona> GetPersonas()
        {
            string sql = "SELECT * FROM Persona";
            List<Persona> persona = con.Query<Persona>(sql);
            return persona;
        }

        public bool ActualizarPersona(Persona persona)
        {
            bool res = false;
            try
            {
                string sql = $"UPDATE Persona SET Nombre='{persona.Nombre}',Apellido='{persona.Apellido}',Departamento='{persona.Departamento}'," +
                                $"Correo='{persona.Correo}' WHERE Id={persona.Id}";
                con.Execute(sql);
                res = true;
            }
            
            catch (Exception ex)
            {
                
            }
            return res;
        }
        public void EliminarPersona(int Id)
        {
            string sql = $"DELETE FROM Persona WHERE Id={Id}";
            con.Execute(sql);
        }
    }
}