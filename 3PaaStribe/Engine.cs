using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _3PaaStribe
{
    class Engine: Strings
    {
        //User input variables.
        #region
        static char botPiece;
        static char gameMode;
        static char piece;
        static char multiplayerPiece;
        static char multiplayer2Piece;
        static bool finish = true;
        #endregion

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
            Multiplayer multiplayer = new Multiplayer();
            Board board = new Board();
            do
            {
                multiplayer.Run(player, player2, board);

                if (multiplayer.IsGameFinished())
                {
                    multiplayer.SetGameFinish();
                    finish = false;
                }
            } while (!finish);
        }

        public static void SinglePlayer(Player player, Player bot)
        {
            Ai ai = new Ai();
            Board board = new Board();
            do
            {
                ai.Run(player, bot, board);

                if (ai.IsGameFinished())
                {
                    ai.SetGameFinish();
                    finish = false;
                }
            } while (!finish);
        }
    }
}
