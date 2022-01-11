using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentosEF2022.Models;
using MvcCoreCrudDepartamentosEF2022.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF2022.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }
    }
}
