using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3PaaStribe
{
    public class Player
    {
        public bool playerTurn { get; set; }
        private string playerName { get; set; }
        private char playerPiece { get; set; }
        private char botPiece { get; set; }

        private static char[] playerPieces = { 'X', 'O' };

        public Player(string playerName, char playerPiece, bool playerTurn = true)
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

        public void SetPlayerPiece(char t)
        {
            this.playerPiece = playerPieces[t];
        }

        public char SetPiece()
        {
            if (GetPlayerPiece() == 'X')
            {
                botPiece = 'O';
            }
            else
            {
                botPiece = 'X';
            }
            return botPiece;
        }

        public bool PlayerPieces(char t)
        {
            if(playerPieces.Contains(t))
            {
                return true;
            }
            return false;
        }

    }
}
