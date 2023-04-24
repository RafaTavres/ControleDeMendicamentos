using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloRequisicao
{
    internal class RequisicaoRepository : RepositoryBase
    {
        public void InseriraMedicamento(Requisicao requisicao)
        {
            Inserir(requisicao);
        }
        public void RetornarTodosOsMedicamentos()
        {
            RetornarTodos();
        }
        public void AtualizarMedicamentos(int id, Requisicao requisicaoAtualizada)
        {
            EntidadeBase requisicao = (Requisicao)Busca(id);
            requisicao.Atualizar(requisicaoAtualizada);
        }
        public void DeletarMedicamentod(int id)
        {
            Deletar(id);
        }
    }
}
