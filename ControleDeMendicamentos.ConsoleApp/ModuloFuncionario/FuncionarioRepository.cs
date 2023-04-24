using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloFuncionario
{
    internal class FuncionarioRepository : RepositoryBase
    {
        public void InseriraFuncionarios(Funcionario funcionario)
        {
            Inserir(funcionario);
        }
        public void RetornarTodosOsFuncionarios()
        {
            RetornarTodos();
        }
        public void AtualizarFuncionarios(int id, Funcionario funcionarioAtualizado)
        {
            EntidadeBase funcionario = (Funcionario)Busca(id);
            funcionario.Atualizar(funcionarioAtualizado);
        }
        public void DeletarFuncionarios(int id)
        {
            Deletar(id);
        }
    }
}
