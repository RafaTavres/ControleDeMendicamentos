﻿using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionarios : Tela
    {
        public FuncionarioRepository funcionarioRepository = null;

        public void MenuFuncionario(string opcao)
        {
            MenuInicial("Funcionario", opcao);
        }
        public void AdicionarFuncionario()
        {
            Funcionario funcionario = (Funcionario)PegaDadosEntidade();
            Adiciona("Funcionário", funcionario, funcionarioRepository);
        }
        public override Entidade PegaDadosEntidade()
        {
            Funcionario funcionario = new Funcionario();
            Console.WriteLine("Nome");
            funcionario.nome = "1";// Console.ReadLine();
            Console.WriteLine("CPF");
            funcionario.CPF = "1"; //Console.ReadLine();
            Console.WriteLine("Telefone");
            funcionario.telefone = "1";//Console.ReadLine();
            return funcionario;
        }
        public void MostraTodosFuncionarios()
        {
            MostraTodasEntidade("Funcionario", funcionarioRepository);
        }
        public override void EscreveTodasAsEntidades(Entidade entidade)
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
    }
}