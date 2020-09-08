using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{

    class Board
    {
        private static char[] arrBoard = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public Board()
        {
        }

        public void DrawBoard(bool multiplayer = false, bool withAi = false)
        {
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

        public void ResetBoard()
        {
            for (int i = 1; i < arrBoard.Length; i++)
            {
                arrBoard[i] = arrBoard[i - 1];
            }
        }
        public void UpdateBoard()
        {

        }

        public void MovePiece(int move, Player player)
        {
            arrBoard[move] = player.GetPlayerPiece();
        }
    }
}
