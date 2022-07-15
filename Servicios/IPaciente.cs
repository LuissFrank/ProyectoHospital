using NewApp.Model;
using System.Collections.Generic;

namespace NewApp.Servicios
{
    public interface IPaciente
    {
        List<Paciente> MostrarTodos();
        void Agregar(Paciente paciente);
        
        void Eliminar(Paciente paciente);

        void Modificar(Paciente paciente);
        
    }
    
}