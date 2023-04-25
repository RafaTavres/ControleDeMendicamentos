using ControleDeMendicamentos.ConsoleApp.ClassesPais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMendicamentos.ConsoleApp.ModuloPaciente
{
    internal class TelaPaciente : TelaBase
    {

        public PacienteRepository pacienteRepository;

        public TelaPaciente(PacienteRepository pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public void MenuPaciente(string opcao)
        {
            MenuInicial("Paciente", opcao);
        }
        public void AdicionarPaciente()
        {
            Paciente paciente = (Paciente)PegaDadosEntidade();
            Adiciona("Paciente", paciente, pacienteRepository);
        }
        public override EntidadeBase PegaDadosEntidade()
        {
            Paciente paciente = new Paciente();
            Console.WriteLine("Nome");
            paciente.nome = Console.ReadLine();
            Console.WriteLine("CPF");
            paciente.CPF = Console.ReadLine();
            Console.WriteLine("Telefone");
            paciente.numeroDeTelefone = Console.ReadLine();
            Console.WriteLine("numero do SUS");
            paciente.numeroSUS = Console.ReadLine();
            return paciente;
        }
        public void MostraTodosPaciente()
        {
            MostraTodasEntidade("Paciente", pacienteRepository);
        }
        public override void EscreveTodasAsEntidades(EntidadeBase entidade)
        {
            Paciente f = (Paciente)entidade;
            Console.WriteLine($"id: {f.id} | nome: {f.nome} | CPF: {f.CPF} | telefone: {f.numeroDeTelefone}| numero do SUS: {f.numeroSUS}");
        }
        public void AtualizarPaciente()
        {
            AtualizarEntidade(pacienteRepository);
        }
        public void DeletaPaciente()
        {
            DeletaEntidade(pacienteRepository);
        }
        public override void MenuEntidade(string opcao)
        {
            if (opcao == "1")
            {
                Console.Clear();
                AdicionarPaciente();
            }
            if (opcao == "2")
            {
                Console.Clear();
                MostraTodosPaciente();
                Console.ReadKey();
            }
            if (opcao == "3")
            {
                Console.Clear();
                MostraTodosPaciente();
                AtualizarPaciente();
            }
            if (opcao == "4")
            {
                Console.Clear();
                MostraTodosPaciente();
                DeletaPaciente();
            }
        }
    }
}
