using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuloAquisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionarios : TelaBase
    {
        public FuncionarioRepository funcionarioRepository;

        public TelaFuncionarios(FuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public void MenuFuncionario(string opcao)
        {
            MenuInicial("Funcionario", opcao);
        }
        public void AdicionarFuncionario()
        {
            Funcionario funcionario = (Funcionario)PegaDadosEntidade();
            Adiciona("Funcionário", funcionario, funcionarioRepository);
        }
        public override EntidadeBase PegaDadosEntidade()
        {
            Funcionario funcionario = new Funcionario();
            Console.WriteLine("Nome");
            funcionario.nome = Console.ReadLine();
            Console.WriteLine("CPF");
            funcionario.CPF = Console.ReadLine();
            Console.WriteLine("Telefone");
            funcionario.telefone = Console.ReadLine();
            return funcionario;
        }
        public void MostraTodosFuncionarios()
        {
            MostraTodasEntidade("Funcionario", funcionarioRepository);
        }
        public override void EscreveTodasAsEntidades(EntidadeBase entidade)
        {
            Funcionario f = (Funcionario)entidade;
            Console.WriteLine($"id: {f.id} | nome: {f.nome} | CPF: {f.CPF} | telefone: {f.telefone}");
        }
        public void AtualizarFuncionario()
        {
            AtualizarEntidade(funcionarioRepository);
        }
        public void DeletaFuncionario()
        {
            DeletaEntidade(funcionarioRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionarFuncionario();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodosFuncionarios();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodosFuncionarios();
                AtualizarFuncionario();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodosFuncionarios();
                DeletaFuncionario();
            }
        }

        public override bool VerificaObjetosVazio(EntidadeBase entidade)
        {
            Funcionario aq = (Funcionario)entidade;
            if (aq == null)
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.CPF) || string.IsNullOrWhiteSpace(aq.CPF))
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.nome) || string.IsNullOrWhiteSpace(aq.nome))
            {
                return true;
            }
            else
                return false;
        }
    }
}
