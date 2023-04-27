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
        public override bool VerificaObjetosVazio(EntidadeBase entidade)
        {
            Fornecedor aq = (Fornecedor)entidade;
            if (aq == null)
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.nome) || string.IsNullOrWhiteSpace(aq.nome))
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.telefone) || string.IsNullOrWhiteSpace(aq.telefone))
            {
                return true;
            }
            else
                return false;
        }
    }
}
