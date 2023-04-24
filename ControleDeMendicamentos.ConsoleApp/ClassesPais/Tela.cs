using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ClassesPais
{
    internal class Tela
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
        public bool VerificaListasValidas(string tipo, Repository repository)
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

        public void Adiciona(string nomeDaEntidade,Entidade novaEntidade,Repository repositorio)
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
        public virtual Entidade PegaDadosEntidade()
        {
            Console.Clear();
            Entidade entidade = new Entidade();
            return entidade;
        }
        public void MostraTodasEntidade(string tipoDeEntidade,Repository repositorio)
        {
            Console.WriteLine($"{tipoDeEntidade}: ");
            Console.WriteLine("____________________________________________________________________________");
            if (VerificaListasValidas(tipoDeEntidade, repositorio) == true)
            {
                foreach (Entidade a in repositorio.RetornarTodos())
                {
                    EscreveTodasAsEntidades(a);
                }
            }
        }

        public virtual void EscreveTodasAsEntidades(Entidade a)
        {
            Console.WriteLine();
        }
        public void AtualizarEntidade(Repository repositorio)
        {
            Console.WriteLine();
            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());
            Entidade entidade = PegaDadosEntidade();
            repositorio.Atualizar(idParaEditar, entidade);
        }

        public void DeletaEntidade(Repository repositorio)
        {
            Console.WriteLine();
            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());
            repositorio.Deletar(idParaDeletar);
        }
    }
}
