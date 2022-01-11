using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcCoreCrudDepartamentosEF2022.Repositories;
using MvcCoreCrudDepartamentosEF2022.Models;

namespace MvcCoreCrudDepartamentosEF2022.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult EmpleadosSalarios()
        {
            List<String> oficios = this.repo.GetOficios();
            List<Empleado> empleados = this.repo.GetEmpleados();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        [HttpPost]
        public IActionResult EmpleadosSalarios(string oficio, int incremento)
        {
            this.repo.IncrementarSalarioEmpleados(oficio, incremento);
            List<string> oficios = this.repo.GetOficios();
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(oficio);
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
