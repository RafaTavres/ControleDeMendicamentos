using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloMedicamento
{
    internal class MedicamentoRepository : Repository
    {

        public List<Medicamento> listaDeMedicamentos = new List<Medicamento>();
        public void InseriraMedicamento(Medicamento medicamento)
        {
            Inserir(medicamento);
        }
        public void RetornarTodosOsMedicamentos()
        {
            RetornarTodos();
        }
        public void AtualizarMedicamentos(int id, Medicamento medicamentoAtualizado)
        {
            Entidade medicamento = (Medicamento)Busca(id);
            medicamento.Atualizar(medicamentoAtualizado);
        }
        public void DeletarMedicamentos(int id)
        {
            Deletar(id);
        }
        public List<Medicamento> RetornarTodosOrdenadosQuantidadeDisponivel()
        {
            List<Medicamento> objetoOrdenados = listaDeMedicamentos.OrderBy(x => x.quantidadeDisponivel).ToList();
            return objetoOrdenados;
        }
        public List<Medicamento> RetornarTodosOrdenadosPorRetirada()
        {
            List<Medicamento> objetoOrdenados = listaDeMedicamentos.OrderByDescending(x => x.quantidadeDeRetiradas).ToList();
            return objetoOrdenados;
        }

    }
}
