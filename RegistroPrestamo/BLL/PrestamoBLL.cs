using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.DAL;
using RegistroPrestamo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamo.BLL
{
    public class PrestamoBLL
    {
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
            {
                return Insertar(prestamos);
            }
            else
            {
                return Modificar(prestamos);
            }


        }


        private static bool Insertar(Prestamos prestamos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Prestamos.Add(prestamos);
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

        private static bool Modificar(Prestamos prestamos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(prestamos).State = EntityState.Modified;
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
                var prestamos = db.Prestamos.Find(id);

                if (prestamos != null)
                {
                    db.Prestamos.Remove(prestamos);
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

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }


        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Prestamos.Any(d => d.PrestamoId == id);
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
