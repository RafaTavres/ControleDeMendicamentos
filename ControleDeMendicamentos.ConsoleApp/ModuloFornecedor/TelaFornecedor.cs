using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuleFornecedor
{
    internal class TelaFornecedor : TelaBase
    {
        FornecedorRepository fornecedorRepository;
        MedicamentoRepository medicamentoRepository;
        TelaMedicamento telaMedicamento;
        public TelaFornecedor
            (
            FornecedorRepository fornecedorRepository, 
            MedicamentoRepository medicamentoRepository, 
            TelaMedicamento telaMedicamento
            )
        {
            this.medicamentoRepository = medicamentoRepository;
            this.fornecedorRepository = fornecedorRepository;
            this.telaMedicamento = telaMedicamento;
        }

        
        public void MenuFornecedor(string opcao)
        {
            MenuInicial("Fornecedor", opcao);
        }
        public void AdicionaFornecedor()
        {
            Fornecedor fornecedor = (Fornecedor)PegaDadosEntidade();
            Adiciona("Fornecedor", fornecedor, fornecedorRepository);
        }
        public override EntidadeBase PegaDadosEntidade()
        {
            Fornecedor fornecedor = new Fornecedor();
            Console.WriteLine("Nome");
            fornecedor.nome = Console.ReadLine();
            Console.WriteLine("Telefone ");
            fornecedor.telefone = Console.ReadLine();
            Console.WriteLine("CNPJ");
            fornecedor.CNPJ = Convert.ToInt32(Console.ReadLine());
            return fornecedor;
        }
        public void MostraTodosFornecedor()
        {
            MostraTodasEntidade("Fornecedor", fornecedorRepository);
        }
        public override void EscreveTodasAsEntidades(EntidadeBase entidade)
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
        public EntidadeBase AdicionaMedicamentosAoFornecedor()
        {
            int idBusca = 0;
            Console.Clear();
            if (VerificaListasValidas("Fornecedor", fornecedorRepository) == false)
                return null;
            else
                MostraTodosFornecedor();
            Console.WriteLine("ID do Fornecedor: ");
            idBusca = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedor = fornecedorRepository.Busca(idBusca);

            Console.Clear();
            if (VerificaListasValidas("Medicamento", medicamentoRepository) == false)
                return null;
            else
                telaMedicamento.MostraTodosMedicamento();
            Console.WriteLine("Id do Medicamento");
            idBusca = Convert.ToInt32(Console.ReadLine());
            fornecedor.medicamentos.Add(medicamentoRepository.Busca(idBusca));
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
