using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS_16._09
{
    class Program
    {
        static Paciente[] pacientes = new Paciente[15]; 
        static void trocarpagina(int pagina) // Funçâo para que direcionar as paginas existentes (1: Adicionar, 2: Listar, 3: Atender).
        {
            Console.Clear();
            switch (pagina)
            {
                case 0:
                    Main();
                    break;
                case 1:
                    paginaadicionar();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:
                    Console.WriteLine("Erro 404 pagina não encontrada");
                    Main();
                    break;
            }
        }
        static void Main() //Pagina inicial - redireciona para outras partes do programa
        {
            Console.WriteLine("Bem vindo ao hospital, você deseja:");
            Console.WriteLine("1. Adicionar um paciente;\n2. Ver todos os pacientes atuais;\n3. Atender um paciente;\n");
            int escolha = int.Parse(Console.ReadLine());
            trocarpagina(escolha);
        }
        static void paginaadicionar()
        {
            Paciente pacientenovo = new Paciente();
            pacientenovo.Pedirnome();
            do
            {
                Console.WriteLine("Qual é o preferencial do paciente? (Note: Maior = Mais preferencial)");
                pacientenovo.nivelpreferencial = int.Parse(Console.ReadLine());

                if (pacientenovo.nivelpreferencial < 0)
                {
                    Console.WriteLine("Você não colocou um número permitido.");
                }
            } while (pacientenovo.nivelpreferencial < 0);

            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null || pacientes[i].nivelpreferencial <= pacientenovo.nivelpreferencial)
                {

                }
            }
        }
    }
}
