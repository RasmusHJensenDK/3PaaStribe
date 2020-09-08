using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{

    class Engine
    {
        private bool isGameFinished = true;
        private static bool isBoardHere = false;
        private static int fieldToMove { get; set; }

        public Engine(Player player, Player player2, Board board, int moveTo, difficulty difficulty = difficulty.Easy, bool multiplayer = false, bool withAi = false)
        {
            do
            {
                if(multiplayer)
                {
                    if(!isBoardHere)
                    {
                        Console.Clear();
                        board.DrawBoard(multiplayer: multiplayer);
                    }
                    player.MovePiece(moveTo, player, board);
                }

                if(withAi)
                {
                    if(!isBoardHere)
                    {
                        Console.Clear();
                        board.DrawBoard(withAi: withAi);
                    }

                    player.MovePiece(moveTo, player, board);
                }

            } while (!isGameFinished);

        }

        public bool finishgame(bool isGameFinished)
        {
            if(!isGameFinished)
            {
                return false;
            }
            return isGameFinished = true;
        }
    }
}
