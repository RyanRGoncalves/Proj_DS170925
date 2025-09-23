using System;

namespace DS_16._09
{
    class Paciente
    {
        private string nome;
        public int nivelpreferencial; // Quanto maior = Mais preferencial

        public string RetornarNome()
        {
            return nome;
        }
        public void PedirNome()
        {
            Console.WriteLine("Digite o nome do paciente:");
            nome = Console.ReadLine();
        }
    }
}
