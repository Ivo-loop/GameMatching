using GameMatching.Comum.Menus;
using System;

namespace GameMatching.Partidas.Menu
{
    public class MenuPartida : MenuBase
    {
        public override void Menu() 
        {
            Console.WriteLine("MENU DE SOLICITAÇÃO DE PARTIDA");
            Console.WriteLine("1. Menu Cadastro");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Cadastro de partida";
                    //IncluirPartida()";
                    Console.ReadLine();
                    break;
                case "0":
                    Console.WriteLine("Voltando para o menu...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida, tente novamente...");
                    Console.ReadLine();
                    Menu();
                    break;
            }
        }
    }
}
