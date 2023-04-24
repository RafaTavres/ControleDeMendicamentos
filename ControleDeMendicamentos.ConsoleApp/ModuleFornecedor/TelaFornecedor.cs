﻿using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuleFornecedor
{
    internal class TelaFornecedor : Tela
    {
        public FornecedorRepository fornecedorRepository = null;
        public MedicamentoRepository medicamentoRepository = null;
        public TelaMedicamento telaMedicamento = null;

        public void MenuFornecedor(string opcao)
        {
            MenuInicial("Fornecedor", opcao);
        }
        public void AdicionaFornecedor()
        {
            Fornecedor fornecedor = (Fornecedor)PegaDadosEntidade();
            Adiciona("Fornecedor", fornecedor, fornecedorRepository);
        }
        public override Entidade PegaDadosEntidade()
        {
            Fornecedor fornecedor = new Fornecedor();
            Console.WriteLine("Nome");
            fornecedor.nome = "1"; Console.ReadLine();
            Console.WriteLine("Telefone ");
            fornecedor.telefone = "123457890"; Console.ReadLine();
            Console.WriteLine("CNPJ");
            fornecedor.CNPJ = 1234699; Convert.ToInt32(Console.ReadLine());
            return fornecedor;
        }
        public void MostraTodosFornecedor()
        {
            MostraTodasEntidade("Fornecedor", fornecedorRepository);
        }
        public override void EscreveTodasAsEntidades(Entidade entidade)
        {
            Fornecedor f = (Fornecedor)entidade;
            Console.WriteLine($"id: {f.id} | nome: {f.nome} | CNPJ: {f.CNPJ} | telefone: {f.telefone}");
            if (f.medicamentos != null)
            {
                foreach (Medicamento a in f.medicamentos)
                {
                    Console.WriteLine($"| Medicamentos: {a.nome}");
                }
            }
        }
        public void AtualizarFornecedor()
        {
            AtualizarEntidade(fornecedorRepository);
        }
        public void DeletaFornecedor()
        {
            DeletaEntidade(fornecedorRepository);
        }
        public Entidade AdicionaMedicamentosAoFornecedor()
        {
            int idBusca = 0;
            Console.Clear();
            if (VerificaListasValidas("Fornecedor", fornecedorRepository) == false)
                return null;
            else
                MostraTodosFornecedor();
            Console.WriteLine("ID do Fornecedor: ");
            idBusca = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedor = (Fornecedor)fornecedorRepository.Busca(idBusca);

            Console.Clear();
            if (VerificaListasValidas("Medicamento", medicamentoRepository) == false)
                return null;
            else
                telaMedicamento.MostraTodosMedicamento();
            Console.WriteLine("Id do Medicamento");
            idBusca = Convert.ToInt32(Console.ReadLine());
            fornecedor.medicamentos.Add((Medicamento)medicamentoRepository.Busca(idBusca));
            return fornecedor;
        }

        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionaFornecedor();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodosFornecedor();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodosFornecedor();
                AtualizarFornecedor();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodosFornecedor();
                DeletaFornecedor();
            }
            if (opcao == "5")
            {
                Console.Clear();
                AdicionaMedicamentosAoFornecedor();
            }
        }
        public override void MenuInicial(string nome, string opcao)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"----Menu {nome}----\n");
                Console.WriteLine($"1- Adicionar {nome} | 2- Ver {nome} | 3- Atualizar {nome} | 4- Deletar {nome} | 5- Adicionar medicamentos para este {nome} | S- Sair");
                opcao = Console.ReadLine();
                MenuEntidade(opcao);

            }
            while (opcao.ToUpper() != "S");
        }
    }
}