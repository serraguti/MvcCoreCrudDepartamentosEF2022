using MvcCoreCrudDepartamentosEF2022.Data;
using MvcCoreCrudDepartamentosEF2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF2022.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        //CONSULTA PARA TODOS LOS EMPLEADOS
        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        //CONSULTA PARA MOSTRAR LOS OFICIOS
        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                           select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        //CONSULTA PARA DEVOLVER LOS EMPLEADOS POR OFICIO
        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        //CONSULTA PARA MODIFICAR EL SALARIO DE
        //LOS EMPLEADOS POR OFICIO
        public void IncrementarSalarioEmpleados
            (string oficio, int incremento)
        {
            //BUSCAR LOS EMPLEADOS A MODIFICAR
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            //DEBEMOS RECORRER TODOS LOS EMPLEADOS Y MODIFICAR
            //SU SALARIO DE FORMA INDIVIDUAL
            foreach (Empleado emp in empleados)
            {
                emp.Salario += incremento;
            }
            this.context.SaveChanges();
        }
    }
}
