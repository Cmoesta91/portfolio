using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {
        public Board PlayerBoard { get; set; }
        public string PlayerName { get; set; }

        public Player()
        {
            PlayerBoard = new Board();
        }

    }

    
}
