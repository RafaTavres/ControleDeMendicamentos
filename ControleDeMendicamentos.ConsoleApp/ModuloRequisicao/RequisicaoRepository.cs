using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloRequisicao
{
    internal class RequisicaoRepository : RepositoryBase
    {
        public RequisicaoRepository(List<EntidadeBase> listDeEntidades)
        {
            this.listaEntidades = listDeEntidades;
        }

        public override Requisicao Busca(int id)
        {
            return (Requisicao)base.Busca(id);
        }
    }
}
