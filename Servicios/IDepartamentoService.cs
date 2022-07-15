using NewApp.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace NewApp.Servicios
{
    public interface IDepartamentoService
    {
        List<Departamento> MostrarTodos();
        void AgregarDep(Departamento dep);

        void ModificarDep(Departamento dep);
    }
}