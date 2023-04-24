using ControleDeMendicamentos.ConsoleApp.ClassesPais;
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
        public void InseriraPacientes(Paciente paciente)
        {
            Inserir(paciente);
        }
        public void RetornarTodosOsPacientes()
        {
            RetornarTodos();
        }
        public void AtualizarPacientes(int id, Paciente pacienteAtualizado)
        {
            EntidadeBase paciente = (Medicamento)Busca(id);
            paciente.Atualizar(pacienteAtualizado);
        }
        public void DeletarPacientes(int id)
        {
            Deletar(id);
        }
    }
}
