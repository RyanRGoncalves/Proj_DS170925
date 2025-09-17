using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_16._09
{
    class Paciente
    {
        private string nome;
        private string cpf;
        public int niveldpreferencial; // Quanto maior = Mais preferencial

        public string Retornarnome()
        {
            return nome;
        }
        public void Pedirnome()
        {
            Console.WriteLine("Digite o nome do paciente:");
            nome = Console.ReadLine();
        }
        public string Retornarcpf()
        {
            return cpf;
        }
        public void Pedircpf()
        {
            Console.WriteLine("Digite o CPF do paciente:");
            cpf = Console.ReadLine();
        }
    }
}
