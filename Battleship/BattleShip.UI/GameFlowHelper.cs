using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public static class GameFlowHelper
    {
        public static int xCoor;
        public static int yCoor;

        public static string GetStringFromUser(string Prompt)
        {
            while (true)
            {
                Console.WriteLine(Prompt);
                string response = Console.ReadLine();

                if (string.IsNullOrEmpty(response))
                {

                    Console.WriteLine("You did not enter anything!");
                }
                else
                {
                    return response;

                }
            }
        }

        public static int WhoGoesFirst()
        {
            int whoGoesFirst;

            Random r = new Random();
            whoGoesFirst = r.Next(1, 3);

            return whoGoesFirst;
        }

        public static void GetCoorFromUser(string Prompt)
        {
            do
            {
                Console.WriteLine(Prompt);
                string CoorXY = Console.ReadLine();
                if (string.IsNullOrEmpty(CoorXY))
                {
                    Console.WriteLine("You didn't enter anything!");
                }
                else if (CoorXY.Length == 1 || CoorXY.Length > 3)
                {
                    Console.WriteLine("You did not enter the correct format. (Ex: A10)");
                }
                else
                {
                    string CoorX = CoorXY.Remove(1);

                    switch (CoorX.ToLower())
                    {
                        case "a":
                            xCoor = 1;
                            break;
                        case "b":
                            xCoor = 2;
                            break;
                        case "c":
                            xCoor = 3;
                            break;
                        case "d":
                            xCoor = 4;
                            break;
                        case "e":
                            xCoor = 5;
                            break;
                        case "f":
                            xCoor = 6;
                            break;
                        case "g":
                            xCoor = 7;
                            break;
                        case "h":
                            xCoor = 8;
                            break;
                        case "i":
                            xCoor = 9;
                            break;
                        case "j":
                            xCoor = 10;
                            break;
                        default:
                            Console.WriteLine("Your input was not letter (A-J). Please try again.");
                            break;
                    }

                    string CoorY = CoorXY.Substring(1);
                    int.TryParse(CoorY, out yCoor);
                    if (yCoor < 1 || yCoor >= 11)
                    {
                        Console.WriteLine("Your input was not numbers (1-10). Please try again.");
                    }
                    else
                    {
                        break;
                    }
                }

            } while (true);


        }

        public static int GetXcoor()
        {
            return xCoor;
        }

        public static int GetYCoor()
        {
            return yCoor;
        }

        public static ShipDirection GetDirectionFromUser(string Prompt)
        {
            while (true)
            {
                Console.WriteLine(Prompt);
                string direction = Console.ReadLine();

                if (string.IsNullOrEmpty(direction))
                {
                    Console.WriteLine("You did not enter anything!");
                }

                else if (direction.ToLower() == "up")
                {
                    return ShipDirection.Up;
                }
                else if (direction.ToLower() == "down")
                {
                    return ShipDirection.Down;
                }
                else if (direction.ToLower() == "left")
                {
                    return ShipDirection.Left;
                }
                else if (direction.ToLower() == "right")
                {
                    return ShipDirection.Right;
                }
                else
                {
                    Console.WriteLine("Please follow the format (Up, Down, Left, Right)");
                }

            }
        }

        public static void PlayerDisplay (Board board)
        {
            {
                string xStr = "ABCDEFGHIJ";
                char row = 'Z';
                ShotHistory displayShot = new ShotHistory();
                Console.Write("   [1  2  3  4  5  6  7  8  9 10]");
                for (int x = 0; x < 10; x++)
                {
                    row = xStr[x];
                    Console.Write($"\n[{row}]");
                    for (int y = 0; y < 10; y++)
                    {
                        Coordinate coord = new Coordinate(x + 1, y + 1);
                        displayShot = board.CheckCoordinate(coord);
                        if (displayShot == ShotHistory.Unknown)
                        {
                            Console.Write($"[ ]");
                        }
                        if (displayShot == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[H]");
                        }
                        if (displayShot == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[M]");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }

        public static void Turns(Player pCurrent, Player pOther)
        {
            bool victory = false;
            Player pSwitch = new Player();
            FireShotResponse response = new FireShotResponse();

            while(victory == false)
            { 
                do
                {
                    PlayerDisplay(pOther.PlayerBoard);
                    GetCoorFromUser($"{pCurrent.PlayerName} Call your shot");
                    var coordinate = new Coordinate(GetXcoor(), GetYCoor());
                    response = pOther.PlayerBoard.FireShot(coordinate);

                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Invalid:
                            Console.WriteLine("That was an invaild entry. Try again.");
                            break;
                        case ShotStatus.Duplicate:
                            Console.WriteLine("You've already called that shot.");
                            break;
                        case ShotStatus.Miss:
                            ASCIIBattleShip.Missed();
                            Console.WriteLine("You missed! Better luck next turn!");
                            Console.ReadKey();
                            break;
                        case ShotStatus.Hit:
                            ASCIIBattleShip.Hit();
                            Console.WriteLine($"HIT! Congrats {pCurrent.PlayerName}!");
                            Console.ReadKey();
                            break;
                        case ShotStatus.HitAndSunk:
                            ASCIIBattleShip.HitAndSunk();
                            Console.WriteLine($"You sunk {pOther.PlayerName}'s ship!!");
                            Console.ReadKey();
                            break;
                        case ShotStatus.Victory:
                            
                            break;
                    }

                } while (response.ShotStatus == ShotStatus.Duplicate || response.ShotStatus == ShotStatus.Invalid);

                switch (response.ShotStatus)
                {
                    case ShotStatus.Hit:
                    case ShotStatus.HitAndSunk:
                    case ShotStatus.Miss:
                        pSwitch = pCurrent;
                        pCurrent = pOther;
                        pOther = pSwitch;
                        Console.Clear();
                        break;

                    case ShotStatus.Victory:
                    victory = true;
                        ASCIIBattleShip.Winner();
                        Console.WriteLine("YOU WON");
                        break;

                }
            }
        }

        public static bool PlayAgain(string Prompt)
        {
            do
            {
                Console.WriteLine(Prompt);
                var response = Console.ReadLine();
                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("You didn't enter anything.");
                }
                else if (response.ToLower() == "n")
                {
                    Environment.Exit(0);
                }
                else if (response.ToLower() == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("That's not an acceptable input.");
                }

            } while (true);
        }
            
    }
}
