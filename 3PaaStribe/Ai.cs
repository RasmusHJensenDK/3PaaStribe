using System;
using System.Threading;

namespace _3PaaStribe
{
    public class Ai: Strings
    {
        static int moveTo;

        private static bool isGameFinished { get; set; }
        private static string winningPlayer { get; set; }

        public Ai()
        {
            
        }
        public void Run(Player player, Player bot, Board board)
        {
            Console.Clear();
            Random random = new Random();
            player.playerTurn = true;

            do
            {
                board.DrawBoard();

                while (player.GetPlayerTurn())
                {
                    Type(STRplayerone);
                    moveTo = Convert.ToInt32(Console.ReadLine());

                    while (board.CheckValue(moveTo))
                    {
                        moveTo = Convert.ToInt32(Console.ReadLine());
                    }

                    board.MovePiece(moveTo, player, board);

                    if (board.CheckForWin())
                    {
                        Type(player.GetPlayerName() + STRwin);
                        isGameFinished = true;
                        winningPlayer = player.GetPlayerName();
                        break;
                    }
                    player.playerTurn = false;
                }

                while (!player.GetPlayerTurn())
                {
                    Type("Bot is thinking...");
                    Thread.Sleep(400);
                    moveTo = random.Next(1, 8);
                    while (board.CheckValue(moveTo))
                    {
                        Type("Bot chose a spot allready there.. thinking again..");
                        moveTo = random.Next(1, 8);
                    }
                    Type(moveTo.ToString());

                    board.MovePiece(moveTo, bot, board);

                    if (board.CheckForWin())
                    {
                        Type(bot.GetPlayerName() + STRwin);
                        isGameFinished = true;
                        winningPlayer = bot.GetPlayerName();
                        break;

                    }
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

        public string WinningPlayer()
        {
            return winningPlayer;
        }
    }
}



  