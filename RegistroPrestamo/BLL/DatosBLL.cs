using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.DAL;
using RegistroPrestamo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamo.BLL
{
    public class DatosBLL
    {
        public static bool Guardar(Persona personas)
        {
            if (!Existe(personas.Id))
            {
                return Insertar(personas);
            }
            else 
            {
                return Modificar(personas);
            }

           
        } 


        private static bool Insertar(Persona datos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Persona.Add(datos);
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool Modificar (Persona datos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(datos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var datos = db.Persona.Find(id);

                if(datos != null)
                {
                    db.Persona.Remove(datos);
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose(); 
            }

            return paso;
        }

        public static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona datos;

            try
            {
                datos = contexto.Persona.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return datos;
        }


        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Persona.Any(d => d.Id == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }




    }
}
