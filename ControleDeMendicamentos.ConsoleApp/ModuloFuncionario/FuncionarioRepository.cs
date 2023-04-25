using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloFuncionario
{
    internal class FuncionarioRepository : RepositoryBase
    {
        public FuncionarioRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Funcionario Busca(int id)
        {
            return (Funcionario)base.Busca(id);
        }
    }
}
