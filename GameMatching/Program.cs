using System;

namespace GameMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        public static void StartMenu(){
            Console.Title = "GameMatching";
            Console.WriteLine("Escolha um dos menus a seguir: ");
            while(true){
                Console.WriteLine("1. Menu Cadastro Player");
                Console.WriteLine("2. Menu Cadastro Jogo");
                Console.WriteLine("3. Menu Cadastro Solicitação Player");
                Console.WriteLine("4. Menu Cadastro Solicitação Partida");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: ");
                switch (Console.Read())
                {
                    case '1':
                        Console.Title = "Cadastro de Player";
                        Console.ReadLine();
                        //MenuPlayer.Menu()";
                        break;
                    case '2':
                        Console.Title = "Cadastro de Jogo";
                        Console.ReadLine();
                        Console.WriteLine("//MenuJogo.Menu()");
                        break;
                    case '3':
                        Console.Title = "Cadastro de Solicitação de Player";
                        Console.ReadLine();
                        //MenuSolicitacaoPlayer.Menu();
                        break;
                    case '4':
                        Console.Title = "Cadastro de Solicitação de Partida";
                        Console.ReadLine();
                        //MenuSolicitacaoPartida.Menu();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ReadLine();
                        Console.WriteLine("Opção Inválida, tente novamente...");
                        break;
                }
            }
        }
    }
}
