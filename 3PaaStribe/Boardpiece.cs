using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{
    public enum boardpieces { Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8 }
    class Boardpiece
    {
        private string boardpieces { get; set; }
        private int pieceNumber;
        public Boardpiece(Player player = null)
        {
            if (player == null)
            {
                this.boardpieces = (pieceNumber).ToString();
            } else
            {
                this.boardpieces = player.GetPlayerPiece();
            }
        }

        public string GetBoardPiece()
        {
            return boardpieces;
        }

        public void SetPieceNumber(int i)
        {
            pieceNumber = i;
        }
        public int GetIndexOfNumerical(string index)
        {
            int myIndex = Convert.ToInt32(boardpieces.IndexOf(index));
            return myIndex;
        }
    }
}
