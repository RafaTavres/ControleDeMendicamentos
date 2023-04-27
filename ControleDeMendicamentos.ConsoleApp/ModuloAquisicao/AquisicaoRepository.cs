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
        public override bool VerificaObjetosVazio(EntidadeBase entidade)
        {
            Aquisicao aq = (Aquisicao)entidade;
            if (aq == null)
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.quantidadeAdicionada.ToString()) || string.IsNullOrWhiteSpace(aq.quantidadeAdicionada.ToString()))
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.funcionario.ToString()) || string.IsNullOrWhiteSpace(aq.funcionario.ToString()))
            {
                return true;
            }
            else
                return false;
        }
    }
}
