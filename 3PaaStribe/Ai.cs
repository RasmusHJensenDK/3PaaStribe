using System;
using System.Threading;

namespace _3PaaStribe
{
    public class Ai: Strings
    {
        int moveTo;

        public Ai(Player player, Player bot)
        {
            Console.Clear();
            Board board = new Board();
            Random random = new Random();
            player.playerTurn = true;

            do
            {
                board.DrawBoard();

                if (player.GetPlayerTurn())
                {
                    moveTo = Convert.ToInt32(Console.ReadLine());

                    while (board.CheckValue(moveTo))
                    {
                        moveTo = Convert.ToInt32(Console.ReadLine());
                    }

                    board.MovePiece(moveTo, player, board);

                    if (board.CheckForWin())
                    {

                    }
                    player.playerTurn = false;
                }

                if (!player.GetPlayerTurn())
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
                        Type(player.GetPlayerName() + STRwin);
                        Type("Do you want to play again? Y / N");
                        playAgain = Console.ReadKey().KeyChar;

                        switch (playAgain)
                        {
                            case 'Y':
                                board.ResetBoard();
                                Type(moveTo.ToString());
                                SinglePlayer(player, bot);
                                break;
                            case 'N':
                                Type(STRthanksforplaying);
                                Thread.Sleep(500);
                                Environment.Exit(0);
                                break;
                        }

                    }
                    player.playerTurn = true;
                }


            } while (!isGameFinished);
            Type(STRplayagain);
            playAgainInput = Console.ReadKey().KeyChar;
            if (playAgainInput == 'Y')
            {
                Type(STRsingleormulti);
                choose = Console.ReadKey().KeyChar;

                switch (choose)
                {
                    case 'S':
                        SinglePlayer(player, bot);
                        break;
                    case 'M':
                        //Multiplayer(player, player2);
                        break;
                    default: break;
                }
            }
        }


    }
}
