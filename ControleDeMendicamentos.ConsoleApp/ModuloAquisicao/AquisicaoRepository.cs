using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using ControleDeMendicamentos.ConsoleApp.ModuloRequisicao;
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
        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            Aquisicao aq = (Aquisicao)entidade;
            if (aq == null)
            {
                return true;
            }else
            if (aq.medicamento == null)
            {
                return true;
            }
            else
            if (aq.fornecedor == null)
            {
                return true;
            }
            else
            if (aq.funcionario == null)
            {
                return true;
            }
            else
            if (string.IsNullOrEmpty(aq.quantidadeAdicionada.ToString()) || string.IsNullOrWhiteSpace(aq.quantidadeAdicionada.ToString()))
            {
                return true;
            }else
            if (string.IsNullOrEmpty(aq.quantidadeAdicionada.ToString()) || string.IsNullOrWhiteSpace(aq.quantidadeAdicionada.ToString()))
            {
                return true;
            }
            else
            {
                aq.AumentarQuantidadeMedicamento();
            }
                return false;
        }
    }
}
