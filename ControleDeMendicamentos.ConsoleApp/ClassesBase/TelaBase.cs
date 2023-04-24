﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ClassesPais
{
    internal class TelaBase
    {
        public void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }
        public bool VerificaObjetosVazio(Object objeto)
        {
            if (objeto == null)
            {
                return true;
            }
            else
                return false;
        }
        public bool VerificaListasValidas(string tipo, RepositoryBase repository)
        {
            if (repository.RetornarTodos().Count == 0)
            {
                ApresentaMensagem($"Nenhum {tipo} Registradado", ConsoleColor.DarkYellow);
                return false;
            }
            else
            {
                return true;
            }
        }
        public virtual void MenuInicial(string nome, string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"----Menu {nome}----\n");
                Console.WriteLine($"1- Adicionar {nome} | 2- Ver {nome} | 3- Atualizar {nome} | 4- Deletar {nome} | S- Sair");
                opcao = Console.ReadLine();
                MenuEntidade(opcao);

            } 
            while (opcao.ToUpper() != "S");            
        }

        public virtual void MenuEntidade(string opcao)
        {  
        }

        public void Adiciona(string nomeDaEntidade,EntidadeBase novaEntidade,RepositoryBase repositorio)
        {
            if (VerificaObjetosVazio(novaEntidade) == true)
            {
                ApresentaMensagem($"{nomeDaEntidade} Invalido(a)", ConsoleColor.Red);
                return;
            }
            else
            {
                repositorio.Inserir(novaEntidade);
                ApresentaMensagem($"{nomeDaEntidade} Adicionado(a)", ConsoleColor.Green);
            }
        }
        public virtual EntidadeBase PegaDadosEntidade()
        {
            Console.Clear();
            EntidadeBase entidade = new EntidadeBase();
            return entidade;
        }
        public void MostraTodasEntidade(string tipoDeEntidade,RepositoryBase repositorio)
        {
            Console.WriteLine($"{tipoDeEntidade}: ");
            Console.WriteLine("____________________________________________________________________________");
            if (VerificaListasValidas(tipoDeEntidade, repositorio) == true)
            {
                foreach (EntidadeBase a in repositorio.RetornarTodos())
                {
                    EscreveTodasAsEntidades(a);
                }
            }
        }

        public virtual void EscreveTodasAsEntidades(EntidadeBase a)
        {
            Console.WriteLine();
        }
        public void AtualizarEntidade(RepositoryBase repositorio)
        {
            Console.WriteLine();
            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());
            EntidadeBase entidade = PegaDadosEntidade();
            repositorio.Atualizar(idParaEditar, entidade);
        }

        public void DeletaEntidade(RepositoryBase repositorio)
        {
            Console.WriteLine();
            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            repositorio.Deletar(idParaDeletar);
        }
    }
}