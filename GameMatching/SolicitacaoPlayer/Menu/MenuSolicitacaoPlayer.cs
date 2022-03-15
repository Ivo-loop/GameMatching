using GameMatching.Comum.Menus;
using System;

namespace GameMatching.SolicitacaoPlayer.Menu
{
    public class MenuSolicitacaoPlayer : MenuBase
    {
        //public readonly ServiceSolicitacaoPlayer _serviceSolicitacaoPlayer;

        public MenuSolicitacaoPlayer()
        {
            //_serviceSolicitacaoPlayer = new ServiceSolicitacaoPlayer();
        }

        public override void Menu()
        {
            Console.WriteLine("Solicitação de Player");
            while (true)
            {
                Console.WriteLine("1. Solicitar Jogador");
                Console.WriteLine("0. Voltar");
                Console.Write("Seleciona a Opção Desejada: ");
                switch (Console.Read())
                {
                    case '1':
                        //_serviceSolicitacaoPlayer.SolicitarJogador();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Comando inválido");
                        break;
                }
            }
        }
    }
}
