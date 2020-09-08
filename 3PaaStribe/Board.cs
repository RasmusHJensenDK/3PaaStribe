using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{

    public class Board
    {
        private static int[] arrBoard = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private static int countPieces = 0;

        public Board()
        {
        }
        public void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arrBoard[0], arrBoard[1], arrBoard[2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arrBoard[3], arrBoard[4], arrBoard[5]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arrBoard[6], arrBoard[7], arrBoard[8]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        }

        public void MovePiece(int move, Player player, Board board)
        {
            Console.Clear();
            arrBoard[move] = player.GetPlayerPiece();

            countPieces++;
            DrawBoard();
        }

        public bool CheckValue(int i)
        {
            if(arrBoard[i] == 'X' || arrBoard[i] == '0')
            {
                return true;
            }
            return false;
        }

        public bool CheckForDraw()
        {
            if (countPieces >= 8)
            {
                return false;
            }
            return true;
        }
        
        public bool CheckForWin()
        {
            //Just for the record.. i hate this bool.. 
            //Vandret 1
            if(arrBoard[0] == arrBoard[1] && arrBoard[1] == arrBoard[2])
            {
                return true;
            }
            //Vandret 2
            if (arrBoard[3] == arrBoard[4] && arrBoard[4] == arrBoard[5])
            {
                return true;
            }
            //Vandret 3
            if (arrBoard[6] == arrBoard[7] && arrBoard[7] == arrBoard[8])
            {
                return true;
            }
            //Skrå 1
            if (arrBoard[0] == arrBoard[4] && arrBoard[4] == arrBoard[8])
            {
                return true;
            }
            //Skrå 2
            if (arrBoard[2] == arrBoard[4] && arrBoard[4] == arrBoard[6])
            {
                return true;
            }
            //Horizontal 1
            if (arrBoard[0] == arrBoard[3] && arrBoard[3] == arrBoard[6])
            {
                return true;
            }
            //Horizontal 2
            if (arrBoard[1] == arrBoard[4] && arrBoard[4] == arrBoard[7])
            {
                return true;
            }
            //Horizontal 3
            if (arrBoard[2] == arrBoard[5] && arrBoard[5] == arrBoard[8])
            {
                return true;
            }


            return false;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < arrBoard.Length; i++)
            {
                arrBoard[i] = Convert.ToChar(i);
            }
        }
    }
}
