using GameMatching.Comum.Menus;
using System;
using System.Collections.Generic;

namespace GameMatching.Partidas.Menu
{
    public class MenuPartida : MenuBase
    {
        public override void Menu() 
        {
            Console.WriteLine("1. Menu Cadastro");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.Read())
            {
                case '1':
                    Console.Title = "Cadastro de partida";
                    //IncluirPartida()";
                    Console.ReadLine();
                    break;
                case '0':
                    Console.WriteLine("Voltando para o menu...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida, voltando para o menu...");
                    break;
            }
        }
    }
}
