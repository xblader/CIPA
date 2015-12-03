using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CIPA.Persistence;
using CIPA.Domain;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIPA.Controllers
{
    [Route("api/[controller]")]
    public class EmpregadoController : Controller
    {
        [FromServices]
        public IRepository<Empregado> RepoEmpregado { get; set; }

        [HttpGet]
        public IEnumerable<Empregado> GetAll()
        {
            return RepoEmpregado.GetAll();
        }

        [HttpGet("{id}", Name = "GetEmpregado")]
        public IActionResult GetById(string id)
        {
            var item = RepoEmpregado.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }
    }
}
