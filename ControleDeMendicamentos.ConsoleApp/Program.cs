using ControleDeMendicamentos.ConsoleApp.ModuleFornecedor;
using ControleDeMendicamentos.ConsoleApp.ModuloAquisicao;
using ControleDeMendicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMendicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMendicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMendicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleDeMendicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";
            FuncionarioRepository repositorioDeFuncionario = new FuncionarioRepository();
            TelaFuncionarios telaFuncionarios = new TelaFuncionarios();
            telaFuncionarios.funcionarioRepository = repositorioDeFuncionario;

            PacienteRepository repositorioDePaciente = new PacienteRepository();
            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.pacienteRepository = repositorioDePaciente;

            MedicamentoRepository repositorioDeMedicamento= new MedicamentoRepository();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.medicamentoRepository = repositorioDeMedicamento;

            FornecedorRepository repositorioDeFornecedor = new FornecedorRepository();
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.fornecedorRepository = repositorioDeFornecedor;
            telaFornecedor.medicamentoRepository = repositorioDeMedicamento;
            telaFornecedor.telaMedicamento = telaMedicamento;

            AquisicaoRepository repositorioDeAquisicao = new AquisicaoRepository();
            TelaAquisicao telaAquisicao = new TelaAquisicao();
            telaAquisicao.aquisicaoRepository = repositorioDeAquisicao;
            telaAquisicao.fornecedorRepository = repositorioDeFornecedor;
            telaAquisicao.funcionarioRepository = repositorioDeFuncionario;
            telaAquisicao.medicamentoRepository = repositorioDeMedicamento;
            telaAquisicao.telaFornecedor = telaFornecedor;
            telaAquisicao.telaFuncionario = telaFuncionarios;
            telaAquisicao.telaMedicamento = telaMedicamento;

            RequisicaoRepository repositorioDeRequisicao = new RequisicaoRepository();
            TelaRequisicao telaRequisicao = new TelaRequisicao();
            telaRequisicao.requisicaoRepository = repositorioDeRequisicao;
            telaRequisicao.pacienteRepository = repositorioDePaciente;
            telaRequisicao.funcionarioRepository = repositorioDeFuncionario;
            telaRequisicao.medicamentoRepository = repositorioDeMedicamento;
            telaRequisicao.telaPaciente = telaPaciente;
            telaRequisicao.telaFuncionario = telaFuncionarios;
            telaRequisicao.telaMedicamento = telaMedicamento;


            while (opcao.ToUpper() != "S")
            {
                Console.Clear();
                Console.WriteLine("1- Menu Funcionario | 2- Menu Paciente | 3- Menu Medicamento | 4- Menu Fornecedor | 5- Menu Aquisição | 6- Menu Requisição");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    telaFuncionarios.MenuFuncionario(opcao);
                }
                if (opcao == "2")
                {
                    telaPaciente.MenuPaciente(opcao);
                }
                if (opcao == "3")
                {
                    telaMedicamento.MenuMedicamento(opcao);
                }
                if (opcao == "4")
                {
                    telaFornecedor.MenuFornecedor(opcao);
                }
                if (opcao == "5")
                {
                    telaAquisicao.MenuAquisicao(opcao);
                }
                if (opcao == "6")
                {
                    telaRequisicao.MenuRequisicao(opcao);
                }

            }
        }
    }
}