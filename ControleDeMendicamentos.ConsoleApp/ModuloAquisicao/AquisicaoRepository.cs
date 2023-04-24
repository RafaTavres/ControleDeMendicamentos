using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloAquisicao
{
    internal class AquisicaoRepository : RepositoryBase
    {
        public void InseriraMedicamento(Aquisicao aquisicao)
        {
            Inserir(aquisicao);
        }
        public void RetornarTodosOsMedicamentos()
        {
            RetornarTodos();
        }
        public void AtualizarMedicamentos(int id, Aquisicao aquisicaoAtualizado)
        {
            EntidadeBase aquisicao = (Aquisicao)Busca(id);
            aquisicao.Atualizar(aquisicaoAtualizado);
        }
        public void DeletarMedicamentod(int id)
        {
            Deletar(id);
        }
    }
}
