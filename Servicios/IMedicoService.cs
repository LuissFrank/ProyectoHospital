using NewApp.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NewApp.Servicios
{
    public class MedicoService : IMedico
    {
        private List<Medico> Medicos;


        public MedicoService(){
            
        }

        public List<Medico> MostrarTodo(){
            return Medicos;
        }
    }
}