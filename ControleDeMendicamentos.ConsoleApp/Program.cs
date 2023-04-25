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
            #region DeclaraçãoEConecção
            FuncionarioRepository repositorioDeFuncionario = new FuncionarioRepository(new List<EntidadeBase>());
            TelaFuncionarios telaFuncionarios = new TelaFuncionarios(repositorioDeFuncionario);

            PacienteRepository repositorioDePaciente = new PacienteRepository(new List<EntidadeBase>());
            TelaPaciente telaPaciente = new TelaPaciente(repositorioDePaciente);

            MedicamentoRepository repositorioDeMedicamento= new MedicamentoRepository(new List<EntidadeBase>());
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioDeMedicamento);

            FornecedorRepository repositorioDeFornecedor = new FornecedorRepository(new List<EntidadeBase>());
            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioDeFornecedor, repositorioDeMedicamento, telaMedicamento);

            AquisicaoRepository repositorioDeAquisicao = new AquisicaoRepository(new List<EntidadeBase>());
            TelaAquisicao telaAquisicao = new TelaAquisicao(repositorioDeAquisicao, repositorioDeFornecedor, repositorioDeMedicamento, repositorioDeFuncionario, telaFornecedor, telaMedicamento, telaFuncionarios);

            RequisicaoRepository repositorioDeRequisicao = new RequisicaoRepository(new List<EntidadeBase>());
            TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioDeRequisicao, repositorioDePaciente, repositorioDeMedicamento, repositorioDeFuncionario, telaPaciente, telaMedicamento, telaFuncionarios);

                #endregion

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