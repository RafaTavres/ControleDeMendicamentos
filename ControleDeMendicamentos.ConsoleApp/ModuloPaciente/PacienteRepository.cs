using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloPaciente
{
    internal class PacienteRepository : RepositoryBase
    {
        public PacienteRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }

        public override Paciente Busca(int id)
        {
            return (Paciente)base.Busca(id);
        }
    }
}
