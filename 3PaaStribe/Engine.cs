using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace _3PaaStribe
{
    class Engine: Strings
    {
        //User input variables. Get rids of theese somehow..
        #region
        static char botPiece;
        static char gameMode;
        static char piece;
        static char multiplayerPiece;
        static char multiplayer2Piece;
        static bool finish = true;
        private static char[] playerPieces = { 'X', 'O' };
        private static char[] gamemodes = { 'S', 'M' };
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
            Board board = new Board();
            gameMode = Console.ReadKey().KeyChar;
            Boolean gamemode = gamemodes.Contains(gameMode);

            while(!gamemode)
            {
                Type("Mode has to S or M");
                Type("Remember the uppercase!!");
                gameMode = Console.ReadKey().KeyChar;
                gamemode = gamemodes.Contains(gameMode);
            }

            switch (gameMode)
            {
//Singleplayer
                case 'S':
                    TypeMulti(ARRwelcomesingle);
                    piece = Console.ReadKey().KeyChar;
                    Type("");

                    Boolean exist = playerPieces.Contains(piece);
                    while (!exist)
                    {
                        Type("Piece has to X or O");
                        Type("Remember the uppercase!!");
                        piece = Console.ReadKey().KeyChar;
                        exist = playerPieces.Contains(piece);
                    }

                    botPiece = CHRpieceX;
                    Player singlePlayer = new Player(STRplayerone, Convert.ToInt32(piece));

                    if (singlePlayer.GetPlayerPiece() == CHRpieceX)
                    {
                        botPiece = CHRpieceO;
                    }

                    Player bot = new Player(STRbot, botPiece);
                    SinglePlayer(singlePlayer, bot, board);

                    Type("Congratulations .name/ ");

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
                    Multiplayer(playerone, playerTwo, board);
                    Console.Clear();
                    Type("Congratulations .name/ ");

                    break;
            }
            Console.ReadKey();
        }

//Multiplayer start game
        public static void Multiplayer(Player player, Player player2, Board board)
        {
            Multiplayer multiplayer = new Multiplayer();
            do
            {
                multiplayer.Run(player, player2, board);

                if (multiplayer.IsGameFinished())
                {
                    multiplayer.SetGameFinish();
                    finish = true;
                    //Set winner instead of this..
                    Type("The winner is .. " + multiplayer.WinningPlayer());
                }
            
            } while (!finish);
        }
//Singleplayer start game
        public static void SinglePlayer(Player player, Player bot, Board board)
        {
            Ai ai = new Ai();
            do
            {
                ai.Run(player, bot, board);

                if (ai.IsGameFinished())
                {
                    ai.SetGameFinish();
                    finish = true;

                    //Set winner instead of this..
                    Type("The winner is .. " + ai.WinningPlayer());
                }
            } while (!finish);
        }
    }
}
