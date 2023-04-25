using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloAquisicao
{
    internal class AquisicaoRepository : RepositoryBase
    {
        public AquisicaoRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }
        public override Aquisicao Busca(int id)
        {
            return (Aquisicao)base.Busca(id);
        }
    }
}
