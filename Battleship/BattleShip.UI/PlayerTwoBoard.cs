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
    public static class PlayerTwoBoard
    {

        public static Board SetupPTwoBoard()
        {
            Board playerTwoBoard = new Board();

            PlaceCarrierP2(playerTwoBoard);
            PlaceBattleshipP2(playerTwoBoard);
            PlaceSubmarineP2(playerTwoBoard);
            PlaceCruiserP2(playerTwoBoard);
            PlaceDestroyerP2(playerTwoBoard);
            return playerTwoBoard;
        }

        public static void PlaceCarrierP2(Board playerTwoBoard)
        {

            ASCIIBattleShip.Carrier();
            while (true)
            {
                int CoorX;
                int CoorY;
                ShipDirection DirectionOne;


                Console.WriteLine("We will set up the Carrier (5 spaces long) ship now.");
                GameFlowHelper.GetCoorFromUser("What row LETTER (A-J) AND column NUMBER (1-10) would you like to place your ship on?");
                CoorX = GameFlowHelper.GetXcoor();
                CoorY = GameFlowHelper.GetYCoor();

                DirectionOne = GameFlowHelper.GetDirectionFromUser("Great! Now what direction would you like to place your ship? (Up, Down, Left, Right");


                var request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(CoorX, CoorY),
                    Direction = DirectionOne,
                    ShipType = ShipType.Carrier
                };
                ShipPlacement help = new ShipPlacement();
                help = playerTwoBoard.PlaceShip(request);
                switch (help)
                {
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Not enough space, try again");
                        continue;
                    case ShipPlacement.Overlap:
                        Console.WriteLine("Ship overlap, try again");
                        continue;
                    case ShipPlacement.Ok:
                        break;
                }
                Console.Clear();
                break;


            }
        }

        public static void PlaceBattleshipP2(Board playerTwoBoard)
        {

            ASCIIBattleShip.Bship();
            while (true)
            {
                int CoorX;
                int CoorY;
                ShipDirection DirectionOne;


                Console.WriteLine("We will set up the Battleship (4 spaces long) ship now.");
                GameFlowHelper.GetCoorFromUser("What row LETTER (A-J) AND column NUMBER (1-10) would you like to place your ship on?");
                CoorX = GameFlowHelper.GetXcoor();
                CoorY = GameFlowHelper.GetYCoor();

                DirectionOne = GameFlowHelper.GetDirectionFromUser("Great! Now what direction would you like to place your ship? (Up, Down, Left, Right");


                var request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(CoorX, CoorY),
                    Direction = DirectionOne,
                    ShipType = ShipType.Battleship
                };
                ShipPlacement help = new ShipPlacement();
                help = playerTwoBoard.PlaceShip(request);
                switch (help)
                {
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Not enough space, try again");
                        continue;
                    case ShipPlacement.Overlap:
                        Console.WriteLine("Ship overlap, try again");
                        continue;
                    case ShipPlacement.Ok:
                        break;
                }
                Console.Clear();
                break;


            }
        }

        public static void PlaceSubmarineP2(Board playerTwoBoard)
        {

            ASCIIBattleShip.Submarine();
            while (true)
            {
                int CoorX;
                int CoorY;
                ShipDirection DirectionOne;


                Console.WriteLine("We will set up the Submarine (3 spaces long) ship now.");
                GameFlowHelper.GetCoorFromUser("What row LETTER (A-J) AND column NUMBER (1-10) would you like to place your ship on?");
                CoorX = GameFlowHelper.GetXcoor();
                CoorY = GameFlowHelper.GetYCoor();

                DirectionOne = GameFlowHelper.GetDirectionFromUser("Great! Now what direction would you like to place your ship? (Up, Down, Left, Right");


                var request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(CoorX, CoorY),
                    Direction = DirectionOne,
                    ShipType = ShipType.Submarine
                };
                ShipPlacement help = new ShipPlacement();
                help = playerTwoBoard.PlaceShip(request);
                switch (help)
                {
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Not enough space, try again");
                        continue;
                    case ShipPlacement.Overlap:
                        Console.WriteLine("Ship overlap, try again");
                        continue;
                    case ShipPlacement.Ok:
                        break;
                }
                Console.Clear();
                break;


            }


        }

        public static void PlaceCruiserP2(Board playerTwoBoard)
        {
            ASCIIBattleShip.CruiserShip();
                while (true)
                {
                    int CoorX;
                    int CoorY;
                    ShipDirection DirectionOne;


                    Console.WriteLine($"We will set up the Cruiser (3 spaces long) ship now.");
                    GameFlowHelper.GetCoorFromUser("What row LETTER (A-J) AND column NUMBER (1-10) would you like to place your ship on?");
                    CoorX = GameFlowHelper.GetXcoor();
                    CoorY = GameFlowHelper.GetYCoor();

                    DirectionOne = GameFlowHelper.GetDirectionFromUser("Great! Now what direction would you like to place your ship? (Up, Down, Left, Right");


                    var request = new PlaceShipRequest()
                    {
                        Coordinate = new Coordinate(CoorX, CoorY),
                        Direction = DirectionOne,
                        ShipType = ShipType.Cruiser
                    };
                    ShipPlacement help = new ShipPlacement();
                    help = playerTwoBoard.PlaceShip(request);
                    switch (help)
                    {
                        case ShipPlacement.NotEnoughSpace:
                            Console.WriteLine("Not enough space, try again");
                            continue;
                        case ShipPlacement.Overlap:
                            Console.WriteLine("Ship overlap, try again");
                            continue;
                        case ShipPlacement.Ok:
                            break;
                    }
                    Console.Clear();
                    break;


                }
            
        }

        public static void PlaceDestroyerP2(Board playerTwoBoard)
        {
            ASCIIBattleShip.DestroyerShip();
            while (true)
            {
                int CoorX;
                int CoorY;
                ShipDirection DirectionOne;


                Console.WriteLine("We will set up the Destroyer (2 spaces long) ship now.");
                GameFlowHelper.GetCoorFromUser("What row LETTER (A-J) AND column NUMBER (1-10) would you like to place your ship on?");
                CoorX = GameFlowHelper.GetXcoor();
                CoorY = GameFlowHelper.GetYCoor();

                DirectionOne = GameFlowHelper.GetDirectionFromUser("Great! Now what direction would you like to place your ship? (Up, Down, Left, Right");


                var request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(CoorX, CoorY),
                    Direction = DirectionOne,
                    ShipType = ShipType.Destroyer
                };
                ShipPlacement help = new ShipPlacement();
                help = playerTwoBoard.PlaceShip(request);
                switch (help)
                {
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Not enough space, try again");
                        continue;
                    case ShipPlacement.Overlap:
                        Console.WriteLine("Ship overlap, try again");
                        continue;
                    case ShipPlacement.Ok:
                        break;
                }
                Console.Clear();
                break;


            }

        }
    }
}
