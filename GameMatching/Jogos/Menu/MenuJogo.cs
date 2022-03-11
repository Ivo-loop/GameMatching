using System;
using GameMatching.Comum.Menus;
using GameMatching.Jogos.Services;

namespace GameMatching.Jogos.Menu
{
    public class MenuJogo : MenuBase
    {
        public override void Menu() 
        {
            var service = new ServiceJogo();

            Console.WriteLine("MENU DE CADASTRO DE JOGO");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar Jogo");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.Read())
            {
                case '1':
                    Console.ReadLine();
                    Console.WriteLine("Insira o nome do jogo: ");
                    var nomeJogo = Console.ReadLine();
                    Console.WriteLine("Insira a quantidade máxima de jogadores: ");
                    var qtdJogadores = Convert.ToInt32(Console.ReadLine());
                    service.Cadastrar(nomeJogo, qtdJogadores);
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}