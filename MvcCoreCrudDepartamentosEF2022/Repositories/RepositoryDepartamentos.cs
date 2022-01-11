using MvcCoreCrudDepartamentosEF2022.Data;
using MvcCoreCrudDepartamentosEF2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF2022.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int id)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertarDepartamento
            (int id, string nombre, string localidad)
        {
            //CREAMOS UNA NUEVA CLASE DEL MODELO
            Departamento departamento = new Departamento();
            //ASIGNAMOS SUS PROPIEDADES
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            //AÑADIMOS A LA COLECCION DbSet LA 
            //NUEVA CLASE CREADA
            this.context.Departamentos.Add(departamento);
            //GUARDAMOS LOS CAMBIOS EN LA BBDD
            this.context.SaveChanges();
        }

        public void EliminarDepartamento(int id)
        {
            //BUSCAMOS EL DEPARTAMENTO/S A ELIMINAR
            Departamento departamento = this.FindDepartamento(id);
            //ELIMINAMOS EL DEPARTAMENTO DE LA COLECCION
            //DbSet DEL CONTEXT
            this.context.Departamentos.Remove(departamento);
            //GUARDAMOS CAMBIOS
            this.context.SaveChanges();
        }

        public void ModificarDepartamento(int id, string nombre
            , string localidad)
        {
            //BUSCAMOS EL DEPARTAMENTO/S POR SU ID
            Departamento departamento = this.FindDepartamento(id);
            //CAMBIAMOS SUS PROPIEDADES (NO PK)
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            //GUARDAMOS CAMBIOS
            this.context.SaveChanges();
        }
    }
}
