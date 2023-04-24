using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : Entidade
    {
        public string nome { get; set; }
        public string CPF { get; set; }
        public string telefone { get; set; }
        #region maluquice
        //public string login { get; set; }
        //public string senha { get; set; }
        #endregion
        public override void Atualizar(Entidade entidadeAtualizada)
        {
            Funcionario funcionario = (Funcionario)entidadeAtualizada;
            nome = funcionario.nome;
            CPF = funcionario.CPF;
            telefone = funcionario.telefone;
        }
    }
}
