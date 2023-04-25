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
        public FornecedorRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Fornecedor Busca(int id)
        {
            return (Fornecedor)base.Busca(id);
        }
    }
}
