using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMendicamentos.ConsoleApp.ModuleFornecedor
{
    internal class Fornecedor : EntidadeBase
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public int CNPJ { get; set; }
        public List<Medicamento> medicamentos = new List<Medicamento>();
        public override void Atualizar(EntidadeBase entidadeAtualizada)
        {
            Fornecedor fornecedor = (Fornecedor)entidadeAtualizada;
            nome = fornecedor.nome;
            telefone = fornecedor.telefone;
            CNPJ = fornecedor.CNPJ;
            medicamentos = fornecedor.medicamentos;
        }
    }
}
