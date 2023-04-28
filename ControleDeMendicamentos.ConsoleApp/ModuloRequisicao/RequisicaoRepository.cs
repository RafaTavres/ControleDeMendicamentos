using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using ControleDeMendicamentos.ConsoleApp.ModuloAquisicao;
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
        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            Requisicao aq = (Requisicao)entidade;
            if (aq == null)
            {
                return true;
            }else
            if (aq.medicamento == null)
            {
                return true;
            }else
            if (aq.funcionario == null)
            {
                return true;
            }else
            if (aq.paciente == null)
            {
                return true;
            }
            else
            if (string.IsNullOrEmpty(aq.quantidadeRetirada.ToString()) || string.IsNullOrWhiteSpace(aq.quantidadeRetirada.ToString()))
            {
                return true;
            }else
            if (string.IsNullOrEmpty(aq.funcionario.ToString()) || string.IsNullOrWhiteSpace(aq.funcionario.ToString()))
            {
                return true;
            }else
            if (aq.medicamento.quantidadeDisponivel < aq.quantidadeRetirada)
            {
                return true;
            }
            else
            {
                aq.DiminuirQuantidadeMedicamento();
                aq.medicamento.quantidadeDeRetiradas++;
            }
            return false;
        }
    }
}
