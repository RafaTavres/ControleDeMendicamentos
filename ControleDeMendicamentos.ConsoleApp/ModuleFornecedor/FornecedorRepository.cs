using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuleFornecedor
{
    internal class FornecedorRepository : Repository
    {
        public void InseriraMedicamento(Fornecedor fornecedor)
        {
            Inserir(fornecedor);
        }
        public void RetornarTodosOsMedicamentos()
        {
            RetornarTodos();
        }
        public void AtualizarMedicamentos(int id, Fornecedor fornecedorAtualizado)
        {
            Entidade fornecedor = (Fornecedor)Busca(id);
            fornecedor.Atualizar(fornecedorAtualizado);
        }
        public void DeletarMedicamentod(int id)
        {
            Deletar(id);
        }
    }
}
