using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamo.BLL;
using RegistroPrestamo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;

namespace RegistroPrestamo.BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;

            Personas personas = new Personas();
            personas.Id = 0;
            personas.Nombre = "Erick";
            personas.Telefono = "809-588-6520";
            personas.Cedula = "402-1312483-3";
            personas.Direccion = "C/Billini";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonaBLL.Guardar(personas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

           paso = PersonaBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas;
            personas = PersonaBLL.Buscar(1);

            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = new List<Personas>();
            Lista = PersonaBLL.GetList(p => true);
            Assert.AreEqual(Lista, Lista);
        }

     
    }
}