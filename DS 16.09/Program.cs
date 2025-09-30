using System;

namespace DS_16._09
{
    class Program
    {
       
        static Paciente[] pacientes = new Paciente[15];
        static void Main()
        {
            /*pacientes[0] = new Paciente(); -- Proposito para testes
            pacientes[0].AlterarNome("Ryan");
            pacientes[0].nivelpreferencial = 3;
            pacientes[1] = new Paciente();
            pacientes[1].AlterarNome("BlankH");
            pacientes[1].nivelpreferencial = 3;
            pacientes[2] = new Paciente();
            pacientes[2].AlterarNome("SuperNova");
            pacientes[2].nivelpreferencial = 2;
            pacientes[3] = new Paciente();
            pacientes[3].AlterarNome("SunRise");
            pacientes[3].nivelpreferencial = 1;*/
            PaginaMenu();
        }
        static void TrocarPagina(int pagina, string mensagem = null) // Funçâo para que direcionar as paginas existentes (0: Menu, 1: Adicionar, 2: Listar, 3: Atender, 4: Saida).
        {
            Console.Clear();
            if (mensagem != null)
            {
                Console.WriteLine(mensagem + "\n");
            }
            switch (pagina)
            {
                case 0:
                    PaginaMenu();
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
                    TrocarPagina(0, "Erro 404 pagina não encontrada");
                    break;
            }
        }
        static void PaginaMenu() // Pagina Menu - Usada para que o usuario saiba onde ir.
        {
            Console.WriteLine("Pagina menu, você deseja:");
            Console.WriteLine("1. adicionar um paciente;\n2. visualizar e/ou alterar todos os pacientes atuais;\n3. atender um paciente;\nq. sair do aplicativo.\n");
            string escolha = Console.ReadLine().ToUpper();
            if (escolha != "Q")
            {
                if (int.Parse(escolha) > 0 && int.Parse(escolha) < 4)
                {
                    TrocarPagina(int.Parse(escolha));
                }
                else
                {
                    TrocarPagina(0, "Você não colocou uma opção possivel.");
                }
            }
            else if (escolha == "Q")
            {
                TrocarPagina(4);
            }
            else
            {
                TrocarPagina(0, "Você não colocou uma opção possivel.");
            }
        }
        static void PaginaAdicionar() // Pagina Adicionar - Usada para que o Usuário possa adicionar um novo paciente
        {
            if (pacientes[14] == null) {
                Paciente pacientenovo = new Paciente();
                Console.WriteLine("Qual será o nome do cliente?");
                pacientenovo.AlterarNome(Console.ReadLine());
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

            Console.WriteLine("\nPressione o número do cliente para alterar seu cadastro, aperte 0 para voltar ao inicio.");
            int escolha = int.Parse(Console.ReadLine());
            if (escolha != 0 && escolha >= 1 && escolha <= 15)
            {
                Console.Clear();
                PaginaAlterar(pacientes[escolha-1], escolha-1);
            }
            else if (escolha == 0)
            {
                TrocarPagina(0, "Nenhum cliente foi alterado.");
            }
            else
            {
                TrocarPagina(0, "Não foi dada uma opção valida.");
            }
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
                    for (int i = 0; i < pacientes.Length; i++)
                    {
                        if (i != pacientes.Length - 1)
                        {
                            pacientes[i] = pacientes[i + 1];
                        }
                        else
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
        static void PaginaAlterar(Paciente paciente, int locallista)
        {
            Console.WriteLine("Lugar na fila: {0}\nCliente: {1}\nPreferencial: {2}", locallista, paciente.RetornarNome(), paciente.nivelpreferencial);
            Console.WriteLine("\nAperte N para alterar o nome. Aperte P para alterar o preferencial. Aperte outra tecla para cancelar e voltar ao Menu.");
            string escolha = Console.ReadLine().ToUpper();
            if (escolha == "N")
            {
                Console.WriteLine("Qual será o novo nome do cliente?");
                paciente.AlterarNome(Console.ReadLine());
                TrocarPagina(0, "Nome alterado com sucesso.");
            }
            else if (escolha == "P")
            {
                do
                {
                    Console.WriteLine("Qual será o novo preferencial do paciente? (Lembrete: Maior = Mais preferencial)");
                    paciente.nivelpreferencial = int.Parse(Console.ReadLine());

                    if (paciente.nivelpreferencial < 0)
                    {
                        Console.WriteLine("Você não colocou um número permitido.");
                    }
                } while (paciente.nivelpreferencial < 0);

                pacientes[locallista] = null;
                for (int i = locallista; i < pacientes.Length; i++)
                {
                    if (i != pacientes.Length - 1)
                    {
                        pacientes[i] = pacientes[i + 1];
                    }
                    else
                    {
                        pacientes[i] = null;
                    }
                }

                for (int i = 0; i < pacientes.Length; i++)
                {
                    if (pacientes[i] == null || pacientes[i].nivelpreferencial <= paciente.nivelpreferencial)
                    {
                        for (int j = pacientes.Length - 1; j > i; j--)
                        {
                            pacientes[j] = pacientes[j - 1];
                        }
                        pacientes[i] = paciente;
                        break;
                    }
                }
                TrocarPagina(0, "Preferencial alterado com sucesso.");
            }
            else
            {
                TrocarPagina(0, "Os dados do cliente " + paciente.RetornarNome() + " não foram alterados.");
            }
        }
        static void Adeus()
        {
            Console.WriteLine("Obrigado por usar o nosso aplicativo.\nAperte qualquer tecla para fechar o aplicativo por completo.");
            Console.ReadKey(true);
        }
    }
} 