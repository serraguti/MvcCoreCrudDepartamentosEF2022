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

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repo.InsertarDepartamento
                (departamento.IdDepartamento, departamento.Nombre
                , departamento.Localidad);
            //DESPUES DE INSERTAR, LLEVAMOS A LA VISTA DE 
            //MOSTRAR TODOS LOS DEPARTAMENTOS
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.EliminarDepartamento(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Edit(Departamento departamento)
        {
            this.repo.ModificarDepartamento
                (departamento.IdDepartamento, departamento.Nombre
                , departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
