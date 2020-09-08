using System;
namespace _3PaaStribe
{
    public class Multiplayer
    {
        static bool isGameFinished;
        static int moveTo;

        public Multiplayer(Player player, Player player2)
        {
            Console.Clear();
            Board board = new Board();
            board.DrawBoard();
            player.playerTurn = true;
            player2.playerTurn = false;
            do
            {
//Player 1 turn
                if (player.GetPlayerTurn())
                {
                    int moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player, board);
                    if (board.CheckForWin())
                    {
                        isGameFinished = true;

                    }
                    player.playerTurn = false;
                    player2.playerTurn = true;

                }
//Player 2 turn
                if (player2.GetPlayerTurn())
                {
                    moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player2, board);
                    if (board.CheckForWin())
                    {
                        isGameFinished = true;

                    }
                    player2.playerTurn = false;
                    player.playerTurn = true;
                }
            } while (!isGameFinished);
        }
    }
}
