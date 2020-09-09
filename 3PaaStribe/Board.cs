using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{

    public class Board
    {
        private Boardpiece[] boardpieces;

        public Board()
        {
        }
        public void DrawBoard()
        {
            this.boardpieces = new Boardpiece[9];
            int taeller = 0;

            foreach (boardpieces bp in Enum.GetValues(typeof(boardpieces)))
            {
                Boardpiece boardpiece = new Boardpiece();
                boardpieces[taeller] = boardpiece; 
                boardpiece.SetPieceNumber(taeller + 1);
                taeller++;
            }

            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", boardpieces[0].GetBoardPiece().ToString(), boardpieces[1].GetBoardPiece().ToString(), boardpieces[2].GetBoardPiece().ToString());
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", boardpieces[3].GetBoardPiece().ToString(), boardpieces[4].GetBoardPiece().ToString(), boardpieces[5].GetBoardPiece().ToString());
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", boardpieces[6].GetBoardPiece().ToString(), boardpieces[7].GetBoardPiece().ToString(), boardpieces[8].GetBoardPiece().ToString());
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        }

        public void MovePiece(int move, Player player, Player second, Board board)
        {
            Console.Clear();
            Boardpiece boardpiece = new Boardpiece(player);
            boardpieces[move] = boardpiece;
            player.playerTurn = !second.playerTurn;
            second.playerTurn = !player.playerTurn;
            DrawBoard();
        }

        public bool CheckValue()
        {
            return false;
        }

        public bool CheckForWin()
        {
            //Just for the record.. i hate this bool.. 
            //Vandret 1
            if (boardpieces[0] == boardpieces[1] && boardpieces[1] == boardpieces[2])
            {
                return true;
            }
            //Vandret 2
            if (boardpieces[3] == boardpieces[4] && boardpieces[4] == boardpieces[5])
            {
                return true;
            }
            //Vandret 3
            if (boardpieces[6] == boardpieces[7] && boardpieces[7] == boardpieces[8])
            {
                return true;
            }
            //Skrå 1
            if (boardpieces[0] == boardpieces[4] && boardpieces[4] == boardpieces[8])
            {
                return true;
            }
            //Skrå 2
            if (boardpieces[2] == boardpieces[4] && boardpieces[4] == boardpieces[6])
            {
                return true;
            }
            //Horizontal 1
            if (boardpieces[0] == boardpieces[3] && boardpieces[3] == boardpieces[6])
            {
                return true;
            }
            //Horizontal 2
            if (boardpieces[1] == boardpieces[4] && boardpieces[4] == boardpieces[7])
            {
                return true;
            }
            //Horizontal 3
            if (boardpieces[2] == boardpieces[5] && boardpieces[5] == boardpieces[8])
            {
                return true;
            }
            return false;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < boardpieces.Length; i++)
            {
                Boardpiece boardpiece = new Boardpiece();
                boardpieces[i] = boardpiece;
            }
        }
    }
}
