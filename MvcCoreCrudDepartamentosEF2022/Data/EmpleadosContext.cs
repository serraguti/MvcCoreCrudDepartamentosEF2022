using Microsoft.EntityFrameworkCore;
using MvcCoreCrudDepartamentosEF2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF2022.Data
{
    public class EmpleadosContext: DbContext
    {
        public EmpleadosContext
            (DbContextOptions<EmpleadosContext> options) : base(options)
        {}

        public DbSet<Empleado> Empleados { get; set; }
    }
}
