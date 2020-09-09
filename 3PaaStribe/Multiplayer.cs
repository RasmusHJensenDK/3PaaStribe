using System;
namespace _3PaaStribe
{
    public class Multiplayer: Strings
    {
        private static bool isGameFinished { get; set; }
        private static string winningPlayer { get; set; }

        private static int moveTo;
        public Multiplayer()
        {
        }

        public void Run(Player player, Player player2, Board board)
        {
            Console.Clear();
            board.DrawBoard();
            player.playerTurn = true;
            player2.playerTurn = true;
            do
            {
                //Player 1 turn
                if (player.GetPlayerTurn())
                {
                    Type(ReturnString(16));
                    moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player, player2, board);

                    if (board.CheckForWin())
                    {
                        winningPlayer = player.GetPlayerName();
                        isGameFinished = true;
                        break;
                    }
                }

                //Player 2 turn
                if (player2.GetPlayerTurn())
                {
                    Type(ReturnString(17));
                    moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player2, player, board);

                    if (board.CheckForWin())
                    {
                        winningPlayer = player2.GetPlayerName();
                        isGameFinished = true;
                        break;
                    }
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

        public string WinningPlayer()
        {
            return winningPlayer;
        }
    }
}
