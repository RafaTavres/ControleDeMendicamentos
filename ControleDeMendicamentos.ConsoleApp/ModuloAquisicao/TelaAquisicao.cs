using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using ControleDeMendicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMendicamentos.ConsoleApp.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloAquisicao
{
    internal class TelaAquisicao : TelaBase
    {
        public AquisicaoRepository aquisicaoRepository;
        public FornecedorRepository fornecedorRepository ;
        public MedicamentoRepository medicamentoRepository ;
        public FuncionarioRepository funcionarioRepository ;
        public TelaFornecedor telaFornecedor ;
        public TelaMedicamento telaMedicamento ;
        public TelaFuncionarios telaFuncionario ;

        public TelaAquisicao(AquisicaoRepository aquisicaoRepository, FornecedorRepository fornecedorRepository, MedicamentoRepository medicamentoRepository, FuncionarioRepository funcionarioRepository, TelaFornecedor telaFornecedor, TelaMedicamento telaMedicamento, TelaFuncionarios telaFuncionario)
        {
            this.aquisicaoRepository = aquisicaoRepository;
            this.fornecedorRepository = fornecedorRepository;
            this.medicamentoRepository = medicamentoRepository;
            this.funcionarioRepository = funcionarioRepository;
            this.telaFornecedor = telaFornecedor;
            this.telaMedicamento = telaMedicamento;
            this.telaFuncionario = telaFuncionario;
        }

        public void MenuAquisicao(string opcao)
        {
            MenuInicial("Aquisição", opcao);
        }
        public void AdicionaAquisicao()
        {
            Aquisicao aquisicao = (Aquisicao)PegaDadosEntidade();
            Adiciona("Aquisição", aquisicao, aquisicaoRepository);

        }
        public override EntidadeBase PegaDadosEntidade()
        {
            int idBusca = 0;
            Aquisicao aquisicao = new Aquisicao();

            if (VerificaListasValidas("fornecedor", fornecedorRepository) == false)
                return null;
            else
                telaFornecedor.MostraTodosFornecedor();
            Console.WriteLine("Id do Fornecedor");
            idBusca = Convert.ToInt32(Console.ReadLine());
            aquisicao.fornecedor = fornecedorRepository.Busca(idBusca);

            Console.Clear();
            if (VerificaListasValidas("medicamento", medicamentoRepository) == false)
                return null;
            else
                telaMedicamento.MostraTodosMedicamento();
            Console.WriteLine("Id do Medicamento");
            idBusca = Convert.ToInt32(Console.ReadLine());
            aquisicao.medicamento = medicamentoRepository.Busca(idBusca);
            Console.WriteLine();
            Console.WriteLine("Quantidade do Pedido");
            aquisicao.quantidadeAdicionada = Convert.ToInt32(Console.ReadLine());            

            Console.Clear();
            if (VerificaListasValidas("funcionario", funcionarioRepository) == false)
                return null;
            else
                telaFuncionario.MostraTodosFuncionarios();
            Console.WriteLine("Id do Funcionario");
            idBusca = Convert.ToInt32(Console.ReadLine());
            aquisicao.funcionario = funcionarioRepository.Busca(idBusca);

            Console.Clear();

            Console.WriteLine("Data da Retirada");
            aquisicao.dataDaRetirada = Convert.ToDateTime(Console.ReadLine());

            return aquisicao;
        }
        public void MostraTodosAquisicao()
        {
            MostraTodasEntidade("Aquisicao", aquisicaoRepository);
        }
        public override void EscreveTodasAsEntidades(EntidadeBase entidade)
        {
            Aquisicao f = (Aquisicao)entidade;
            Console.WriteLine($"id: {f.id} | Fornecedor: {f.fornecedor.nome} | Medicamento: {f.medicamento.nome} | Funcionário: {f.funcionario.nome} | Data da Retirada: {f.dataDaRetirada.ToString("dd/MMM/yyyy")}  | Quantidade Retirada: {f.quantidadeAdicionada}  ");

        }
        public void AtualizarAquisicao()
        {
            AtualizarEntidade(aquisicaoRepository);
        }
        public void DeletaAquisicao()
        {
            DeletaEntidade(aquisicaoRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionaAquisicao();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodosAquisicao();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodosAquisicao();
                AtualizarAquisicao();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodosAquisicao();
                DeletaAquisicao();
            }
        }
        public override void AtualizarEntidade(RepositoryBase repositorio)
        {
            Console.WriteLine();

            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());

            Aquisicao aquisicao = aquisicaoRepository.Busca(idParaEditar);

            Aquisicao aquisicaoAtualizada = (Aquisicao)PegaDadosEntidade();

            aquisicao.DesfazerRegistroEntrada();

            repositorio.Atualizar(idParaEditar, aquisicaoAtualizada);
        }
        public override void DeletaEntidade(RepositoryBase repositorio)
        {
            Console.WriteLine();

            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());

            Aquisicao aquisicao = aquisicaoRepository.Busca(idParaDeletar);

            aquisicao.DesfazerRegistroEntrada();

            repositorio.Deletar(idParaDeletar);
        }
    }
}
