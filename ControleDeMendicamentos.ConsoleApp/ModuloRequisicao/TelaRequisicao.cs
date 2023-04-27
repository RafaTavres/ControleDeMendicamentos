using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using ControleDeMendicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMendicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMendicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloRequisicao
{
    internal class TelaRequisicao : TelaBase
    {
        public RequisicaoRepository requisicaoRepository;
        public PacienteRepository pacienteRepository;
        public MedicamentoRepository medicamentoRepository;
        public FuncionarioRepository funcionarioRepository;
        public TelaPaciente telaPaciente;
        public TelaMedicamento telaMedicamento;
        public TelaFuncionarios telaFuncionario;

        public TelaRequisicao(RequisicaoRepository requisicaoRepository, PacienteRepository pacienteRepository, MedicamentoRepository medicamentoRepository, FuncionarioRepository funcionarioRepository, TelaPaciente telaPaciente, TelaMedicamento telaMedicamento, TelaFuncionarios telaFuncionario)
        {
            this.requisicaoRepository = requisicaoRepository;
            this.pacienteRepository = pacienteRepository;
            this.medicamentoRepository = medicamentoRepository;
            this.funcionarioRepository = funcionarioRepository;
            this.telaPaciente = telaPaciente;
            this.telaMedicamento = telaMedicamento;
            this.telaFuncionario = telaFuncionario;
        }

        public void MenuRequisicao(string opcao)
        {
            MenuInicial("Requisicao ", opcao);
        }
        public void AdicionarRequisicao()
        {
            Requisicao requisicao = (Requisicao)PegaDadosEntidade();
            Adiciona("Requisição", requisicao, requisicaoRepository);
        }
        public override EntidadeBase PegaDadosEntidade()
        {
            int idBusca = 0;
            Requisicao requisicao = new Requisicao();

            if (VerificaListasValidas("Paciente", pacienteRepository) == false)
                return null;
            else
                telaPaciente.MostraTodosPaciente();
            Console.WriteLine("Id do Paciente");
            idBusca = Convert.ToInt32(Console.ReadLine());
            requisicao.paciente = pacienteRepository.Busca(idBusca);

            Console.Clear();
            if (VerificaListasValidas("Medicamento", medicamentoRepository) == false)
                return null;
            else
                telaMedicamento.MostraTodosMedicamento();
            Console.WriteLine("Id do Medicamento");
            idBusca = Convert.ToInt32(Console.ReadLine());
            requisicao.medicamento = medicamentoRepository.Busca(idBusca);

            Console.Clear();
            if (VerificaListasValidas("Funcionario", funcionarioRepository) == false)
                return null;
            else
                telaFuncionario.MostraTodosFuncionarios();
            Console.WriteLine("Id do Funcionario");
            idBusca = Convert.ToInt32(Console.ReadLine());
            requisicao.funcionario = funcionarioRepository.Busca(idBusca);

            Console.Clear();
            Console.WriteLine("Quantidade Retirada");
            requisicao.quantidadeRetirada = Convert.ToInt32(Console.ReadLine());                         

            Console.WriteLine("Data da Retirada");
            requisicao.dataDaRetirada = Convert.ToDateTime(Console.ReadLine());
            requisicao.medicamento.quantidadeDeRetiradas++;

            return requisicao;
        }
        public void MostraTodosRequisicao()
        {
            MostraTodasEntidade("Requisicao", requisicaoRepository);
        }
        public override void EscreveTodasAsEntidades(EntidadeBase entidade)
        {
            Requisicao f = (Requisicao)entidade;
            Console.WriteLine($"id: {f.id} | Paciente: {f.paciente.nome} | Medicamento: {f.medicamento.nome} | Funcionário: {f.funcionario.nome} | Data da Retirada: {f.dataDaRetirada.ToString("dd/MMM/yyyy")}  | Quantidade Retirada: {f.quantidadeRetirada}");
        }
        public void AtualizarRequisicao()
        {
            
            AtualizarEntidade(requisicaoRepository);
        }
        public void DeletaRequisicao()
        {
            DeletaEntidade(requisicaoRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionarRequisicao();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodosRequisicao();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodosRequisicao();
                AtualizarRequisicao();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodosRequisicao();
                DeletaRequisicao();
            }
        }

        public override void AtualizarEntidade(RepositoryBase repositorio)
        {
            Console.WriteLine();        
            
            Console.WriteLine("Id para Editar: ");
            int idParaEditar = Convert.ToInt32(Console.ReadLine());

            Requisicao requisicao = requisicaoRepository.Busca(idParaEditar);

            Requisicao requisicaoAtualizada = (Requisicao)PegaDadosEntidade();

            requisicao.DesfazerRegistroSaida();

            repositorio.Atualizar(idParaEditar, requisicaoAtualizada);
        }
        public override void DeletaEntidade(RepositoryBase repositorio)
        {
            Console.WriteLine();

            Console.WriteLine("Id para Deletar: ");
            int idParaDeletar = Convert.ToInt32(Console.ReadLine());

            Requisicao requisicao = requisicaoRepository.Busca(idParaDeletar);

            requisicao.DesfazerRegistroSaida();

            repositorio.Deletar(idParaDeletar);
        }

        public override bool VerificaObjetosVazio(EntidadeBase entidade)
        {
            Requisicao aq = (Requisicao)entidade;
            if (aq == null)
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.quantidadeRetirada.ToString()) || string.IsNullOrWhiteSpace(aq.quantidadeRetirada.ToString()))
            {
                return true;
            }
            if (string.IsNullOrEmpty(aq.funcionario.ToString()) || string.IsNullOrWhiteSpace(aq.funcionario.ToString()))
            {
                return true;
            }
            if (aq.medicamento.quantidadeDisponivel < aq.quantidadeRetirada)
            {
                return true;
            }
            else
                aq.medicamento.quantidadeDisponivel -= aq.quantidadeRetirada;
                return false;
        }
    }

}
