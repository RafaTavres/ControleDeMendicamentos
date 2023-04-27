using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloMedicamento
{
    internal class MedicamentoRepository : RepositoryBase
    {

        public List<Medicamento> listaDeMedicamentos = new List<Medicamento>();

        public MedicamentoRepository(List<EntidadeBase> listaDeEntidades)
        {
            this.listaEntidades = listaDeEntidades;
        }

        public override Medicamento Busca(int id)
        {
            return (Medicamento)base.Busca(id);
        }
        public List<Medicamento> RetornarTodosOrdenadosQuantidadeDisponivel()
        {
            List<Medicamento> objetoOrdenados = listaDeMedicamentos.OrderBy(x => x.quantidadeDisponivel).ToList();
            return objetoOrdenados;
        }
        public List<Medicamento> RetornarTodosOrdenadosPorRetirada()
        {
            List<Medicamento> objetoOrdenados = listaDeMedicamentos.OrderByDescending(x => x.quantidadeDeRetiradas).ToList();
            return objetoOrdenados;
        }
        public override bool VerificaObjetosComErro(EntidadeBase entidade)
        {
            Medicamento aq = (Medicamento)entidade;

            if (aq == null)
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.nome) || string.IsNullOrWhiteSpace(aq.nome))
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.descricao) || string.IsNullOrWhiteSpace(aq.descricao))
            {
                return true;
            }
            else
                return false;
        }

    }
}
