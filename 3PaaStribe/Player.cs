using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{
    class Player
    {
        public bool playerTurn { get; set; }
        private string playerName { get; set; }
        private int playerPiece { get; set; }

        public Player(string playerName, int playerPiece, bool playerTurn = false)
        {
            this.playerName = playerName;
            this.playerTurn = playerTurn;
            this.playerPiece = playerPiece;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public bool GetPlayerTurn()
        {
            return playerTurn;
        }

        public int GetPlayerPiece()
        {
            return playerPiece;
        }
    }
}
