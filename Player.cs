using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{
    class Player
    {
        private bool playerTurn { get; set; }
        private string playerName { get; set; }
        private char playerPiece { get; set; }

        public Player(string playerName, char playerPiece, bool playerTurn = false)
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

        public char GetPlayerPiece()
        {
            return playerPiece;
        }

        public void MovePiece(int move, Player player, Board board)
        {
            board.MovePiece(move, player);
        }
    }
}
