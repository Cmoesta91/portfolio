using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Workflow
    {

        public void Run()
        {

            do
            {
                //splash screen
                ASCIIBattleShip.Welcome();
                ASCIIBattleShip.Bship();
                Console.WriteLine("Hit any key to continue");
                Console.ReadKey();
                Console.Clear();

                //getting players names
                Console.WriteLine("Battleship is a 2 player HUMAN game.");
                Player PlayerOne = new Player();
                PlayerOne.PlayerName = GameFlowHelper.GetStringFromUser("HUMAN ONE: What is your name?");
                Console.Clear();
                Console.WriteLine($"Thank you HUMAN {PlayerOne.PlayerName}");
                Player PlayerTwo = new Player();
                PlayerTwo.PlayerName = GameFlowHelper.GetStringFromUser("HUMAN TWO: What is your name?");
                Console.Clear();
                Console.WriteLine($"Thank you HUMAN {PlayerTwo.PlayerName}, hand the COMPUTER to HUMAN {PlayerOne.PlayerName} so they may set up their board.");
                Console.ReadKey();
                Console.Clear();


                //Setting up the board P1
                Console.WriteLine($"HUMAN {PlayerOne.PlayerName} it's time to set up your board!");
                PlayerOne.PlayerBoard = PlayerOneBoard.SetupPOneBoard();
                Console.WriteLine($"Great! Now press any key and hand the COMPUTER to HUMAN {PlayerTwo.PlayerName}");
                Console.ReadKey();
                Console.Clear();

                //Setting up the board P2
                Console.WriteLine($"HUMAN {PlayerTwo.PlayerName} it's time to set up your board!");
                PlayerTwo.PlayerBoard = PlayerTwoBoard.SetupPTwoBoard();

                //Decides who plays first
                int whoGoesFirst = GameFlowHelper.WhoGoesFirst();
                if (whoGoesFirst == 1)
                {
                    GameFlowHelper.Turns(PlayerOne, PlayerTwo);

                }
                else
                {
                    GameFlowHelper.Turns(PlayerTwo, PlayerOne);

                }

            }while (GameFlowHelper.PlayAgain("Do you want to play agian [Y/N]?"));


        }


    }
}
