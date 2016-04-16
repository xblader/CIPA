using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CIPA.Persistence;
using CIPA.Domain;
using CIPA.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIPA.Controllers
{
    [Route("api/empregado")]
    public class EmpregadoController : Controller
    {
        [FromServices]
        public IRepository<Empregado> RepoEmpregado { get; set; }

        [HttpGet]
        public IEnumerable<Empregado> GetAll()
        {
            return RepoEmpregado.GetAll();
            fdfdf
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

        [HttpPost]
        public IActionResult Create([FromBody] Empregado item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            RepoEmpregado.Add(item);
            return CreatedAtRoute("GetEmpregado", new { controller = "Empregado", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Empregado item)
        {
            if (item == null || item.Key != id)
            {
                return HttpBadRequest();
            }

            var todo = RepoEmpregado.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }

            RepoEmpregado.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            RepoEmpregado.Remove(id);
        }
    }
}
