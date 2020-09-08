using System;
namespace _3PaaStribe
{
    public class Multiplayer: Strings
    {
        static bool isGameFinished { get; set; }
        static int moveTo;

        public Multiplayer()
        {
        }

        public void Run(Player player, Player player2, Board board)
        {
            Console.Clear();
            board.DrawBoard();
            player.playerTurn = true;
            player2.playerTurn = false;
            do
            {
                //Player 1 turn
                if (player.GetPlayerTurn())
                {
                    Type(STRplayerone);
                    int moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player, board);

                    if (board.CheckForWin())
                    {

                        isGameFinished = true;
                        break;
                    }

                    player.playerTurn = false;
                    player2.playerTurn = true;

                }
                //Player 2 turn
                if (player2.GetPlayerTurn())
                {
                    Type(STRplayertwo);
                    moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player2, board);

                    if (board.CheckForWin())
                    {
                        isGameFinished = true;
                        break;
                    }

                    player2.playerTurn = false;
                    player.playerTurn = true;
                }
            } while (!isGameFinished);
        }

        public bool IsGameFinished()
        {
            return isGameFinished;
        }

        public void SetGameFinish()
        {
            isGameFinished = true;
        }
    }
}
