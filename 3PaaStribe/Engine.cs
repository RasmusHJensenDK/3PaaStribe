using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _3PaaStribe
{
    class Engine: Strings
    {
        //User input variables.
        static char botPiece;
        static bool isGameFinished;
        static char gameMode;
        static char piece;
        static char multiplayerPiece;
        static char multiplayer2Piece;
        static char playAgain;
        static char playAgainInput;
        static char choose;
        static int moveTo;
        public Engine()
        {
            Type("Starting game..");
            Thread.Sleep(800);
            Console.Clear();
        }

        public void EngineRun()
        {
            TypeMulti(ARRbuilderwelcome);
            gameMode = Console.ReadKey().KeyChar;

            switch (gameMode)
            {
                //Singleplayer
                case 'S':
                    TypeMulti(ARRwelcomesingle);
                    piece = Console.ReadKey().KeyChar;
                    Type("");

                    botPiece = CHRpieceX;
                    Player singlePlayer = new Player(STRplayerone, Convert.ToInt32(piece));

                    //Sets bots piece from users choice -1.
                    if (singlePlayer.GetPlayerPiece() == CHRpieceX)
                    {
                        botPiece = CHRpieceO;
                    }

                    Player bot = new Player(STRbot, botPiece);
                    SinglePlayer(singlePlayer, bot);
                    break;
                //Multiplayer
                case 'M':
                    TypeMulti(ARRwelcomemulti);
                    multiplayerPiece = Console.ReadKey().KeyChar;
                    Type("");
                    Player playerone = new Player(STRplayerone, Convert.ToInt32(multiplayerPiece));
                    if (multiplayerPiece == CHRpieceX)
                    {
                        multiplayer2Piece = CHRpieceO;
                    }
                    else
                    {
                        multiplayer2Piece = CHRpieceX;
                    }
                    Player playerTwo = new Player(STRplayertwo, multiplayer2Piece);
                    Multiplayer(playerone, playerTwo);
                    break;
            }
            Console.ReadKey();
        }
        //Multiplayer start game
        public static void Multiplayer(Player player, Player player2)
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
                    Type(STRplaceyourpiece + player.GetPlayerName());
                    int moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player, board);
                    if (board.CheckForWin())
                    {
                        Type(player.GetPlayerName() + STRwin);
                        Type(STRplayagain);
                        playAgain = Console.ReadKey().KeyChar;
                        isGameFinished = true;
                        switch (playAgain)
                        {
                            case 'Y':
                                board.ResetBoard();
                                Multiplayer(player, player2);
                                break;
                            case 'N':
                                Console.WriteLine(STRthanksforplaying);
                                break;
                        }

                    }
                    player.playerTurn = false;
                    player2.playerTurn = true;

                }
//Player 2 turn
                if (player2.GetPlayerTurn())
                {
                    Type(STRplaceyourpiece + player2.GetPlayerName());
                    moveTo = Convert.ToInt32(Console.ReadLine());
                    board.MovePiece(moveTo, player2, board);
                    if (board.CheckForWin())
                    {
                        Type(player.GetPlayerName() + STRwin);
                        Type(STRplayagain);
                        playAgain = Console.ReadKey().KeyChar;
                        isGameFinished = true;
                        switch (playAgain)
                        {
                            case 'Y':
                                board.ResetBoard();
                                Multiplayer(player, player2);
                                break;
                            case 'N':
                                Type(STRthanksforplaying);
                                break;
                        }

                    }
                    player2.playerTurn = false;
                    player.playerTurn = true;
                }
                /*
                if (win)
                {
                    Type(STRcongratulations  + WinningPlayer);
                    isGameFinished = true;
                }
                */
            } while (!isGameFinished);

        }
        public static void SinglePlayer(Player player, Player bot)
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
                    Type(player.GetPlayerName() + STRpleacemoveapiece);
                    int moveTo = Convert.ToInt32(Console.ReadLine());

                    while (board.CheckValue(moveTo))
                    {
                        Type(STRallreadythere);
                        moveTo = Convert.ToInt32(Console.ReadLine());
                    }

                    board.MovePiece(moveTo, player, board);

                    if (board.CheckForWin())
                    {
                        Type(player.GetPlayerName() + STRwin);
                        Type(STRplayagain);
                        playAgain = Console.ReadKey().KeyChar;

                        switch (playAgain)
                        {
                            case 'Y':
                                board.ResetBoard();
                                SinglePlayer(player, bot);
                                break;
                            case 'N':
                                Console.WriteLine(STRthanksforplaying);
                                Thread.Sleep(500);
                                Environment.Exit(0);
                                break;
                        }

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
