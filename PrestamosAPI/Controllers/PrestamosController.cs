using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistroPrestamo.BLL;
using RegistroPrestamo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrestamosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        // GET: api/Prestamos
        [HttpGet]
        public ActionResult<List<Prestamos>> Get()
        {
            return PrestamoBLL.GetPrestamos();
        }

        // GET api/Prestamos/1
        [HttpGet("{id}")]
        public ActionResult<Prestamos> Get(int id)
        {
            return PrestamoBLL.Buscar(id);
        }

        

     
    }
}
