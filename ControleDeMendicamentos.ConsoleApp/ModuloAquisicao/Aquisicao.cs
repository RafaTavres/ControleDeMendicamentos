using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using ControleDeMendicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMendicamentos.ConsoleApp.ModuloAquisicao
{
    internal class Aquisicao : Entidade
    {
        public Fornecedor fornecedor { get; set; }
        public Medicamento medicamento { get; set; }
        public Funcionario funcionario { get; set; }
        public int quantidadeAdicionada { get; set; }
        public DateTime dataDaRetirada { get; set; }
        public override void Atualizar(Entidade entidadeAtualizada)
        {
            Aquisicao aquisicao = (Aquisicao)entidadeAtualizada;
            fornecedor = aquisicao.fornecedor;
            medicamento = aquisicao.medicamento;
            funcionario = aquisicao.funcionario;

            quantidadeAdicionada = aquisicao.quantidadeAdicionada;
            dataDaRetirada = aquisicao.dataDaRetirada;
        }
    }
}
