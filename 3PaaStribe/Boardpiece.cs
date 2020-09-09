﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{
    public enum boardpieces { Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8 }
    class Boardpiece
    {
        private string boardpieces { get; set; }
        public Boardpiece(Player player = null)
        {
            if (player == null)
            {
                this.boardpieces = "E";
            } else
            {
                this.boardpieces = player.GetPlayerPiece().ToString();
            }
        }

        public string GetBoardPiece()
        {
            return boardpieces;
        }
        public int GetIndexOfNumerical(string index)
        {
            int myIndex = Convert.ToInt32(boardpieces.IndexOf(index));
            return myIndex;
        }
    }
}