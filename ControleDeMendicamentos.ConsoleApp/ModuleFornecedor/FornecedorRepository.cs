using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuleFornecedor
{
    internal class FornecedorRepository : RepositoryBase
    {
        public void InseriraFornecedor(Fornecedor fornecedor)
        {
            Inserir(fornecedor);
        }
        public void RetornarTodosOsFornecedor()
        {
            RetornarTodos();
        }
        public void AtualizarFornecedor(int id, Fornecedor fornecedorAtualizado)
        {
            EntidadeBase fornecedor = (Fornecedor)Busca(id);
            fornecedor.Atualizar(fornecedorAtualizado);
        }
        public void DeletarFornecedor(int id)
        {
            Deletar(id);
        }
    }
}
