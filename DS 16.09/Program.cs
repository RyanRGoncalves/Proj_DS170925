using System;

namespace DS_16._09
{
    class Program
    {
        static Paciente[] pacientes = new Paciente[15];
        static void TrocarPagina(int pagina, string mensagem = null) // Funçâo para que direcionar as paginas existentes (0: Menu, 1: Adicionar, 2: Listar, 3: Atender).
        {
            Console.Clear();
            if (mensagem != null)
            {
                Console.WriteLine(mensagem + "\n");
            }
            switch (pagina)
            {
                case 0:
                    Main();
                    break;
                case 1:
                    PaginaAdicionar();
                    break;
                case 2:
                    PaginaVisualizar();
                    break;
                case 3:
                    PaginaAtender();
                    break;
                case 4:
                    Adeus();
                    break;
                default:
                    Console.WriteLine("Erro 404 pagina não encontrada");
                    Main();
                    break;
            }
        }
        static void Main() // Pagina Menu - Usada para que o usuario saiba onde ir.
        {
            Console.WriteLine("Pagina menu, você deseja:");
            Console.WriteLine("1. adicionar um paciente;\n2. ver todos os pacientes atuais;\n3. atender um paciente;\nq. sair do aplicativo.\n");
            string escolha = Console.ReadLine().ToUpper();
            TrocarPagina(escolha == "Q" ? 4 : int.Parse(escolha));
        }
        static void PaginaAdicionar() // Pagina Adicionar - Usada para que o Usuário possa adicionar um novo paciente
        {
            if (pacientes[14] == null) {
                Paciente pacientenovo = new Paciente();
                pacientenovo.PedirNome();
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
                        for (int j = pacientes.Length - 1; j > i; j--)
                        {
                            pacientes[j] = pacientes[j - 1];
                        }
                        pacientes[i] = pacientenovo;
                        break;
                    }
                }
                TrocarPagina(0, "Paciente adicionado!");
            } 
            else
            {
                Console.WriteLine("A fila está cheia, por favor atenda um cliente antes de adicionar.\nAperte qualquer tecla para voltar ao inicio.");
                Console.ReadKey();
                TrocarPagina(0);
            }
        }
        static void PaginaVisualizar()
        {
            Console.WriteLine("Aqui está uma lista de todos os pacientes, ordenado pela preferencia:\nNº da fila - Nome do Cliente - Nivel de preferencial");
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] != null)
                {
                    Console.WriteLine("{0} - {1} - {2}", i + 1, pacientes[i].RetornarNome(), pacientes[i].nivelpreferencial);
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao inicio.");
            Console.ReadKey();
            TrocarPagina(0);
        }
        static void PaginaAtender()
        {
            if (pacientes[0] != null)
            {
                Console.WriteLine("O paciente que será tratado atualmente é o {0}, com uma preferencia de {1}.\n", pacientes[0].RetornarNome(), pacientes[0].nivelpreferencial);
                Console.WriteLine("Pressione 1 para tratar o paciente, pressione outra letra para voltar ao Menu.");
                ConsoleKeyInfo escolha = Console.ReadKey();
                if (escolha.KeyChar == '1')
                {
                    for (int i = 0; i < pacientes.Length - 1; i++)
                    {
                        pacientes[i] = pacientes[i + 1];
                        if (i == pacientes.Length - 1)
                        {
                            pacientes[i] = null;
                        }
                    }
                }
                TrocarPagina(0);
            } else
            {
                Console.WriteLine("Não há nenhum paciente para atender.\nAperte qualquer tecla para voltar ao inicio.");
                Console.ReadKey();
                TrocarPagina(0);
            }
        }
        static void Adeus()
        {
            Console.WriteLine("Obrigado por usar o nosso aplicativo.\nAperte qualquer tecla para fechar o aplicativo por completo.");
            Console.ReadKey(true);
        }
    }
}