using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace _3PaaStribe
{
    class Engine: Multiplayer
    {
        //User input variables. Get rids of theese somehow..
        #region
        static char gameMode;
        static string piece = "X";
        static bool finish = true;
        static string multiplayerPiece;
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
            Player player = new Player("Player", "X");
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
                    piece = Console.ReadLine();
                    Type("");

                    while (!player.PlayerPieces(piece))
                    {
                        Type("Piece has to X or O");
                        Type("Remember the uppercase!!");
                        piece = Console.ReadLine();
                    }

                    Player singlePlayer = new Player(STRplayerone, piece);
                    Player bot = new Player(STRbot, singlePlayer.SetPiece());

                    SinglePlayer(singlePlayer, bot, board);

                    Type("Congratulations .name/ ");

                    break;
//Multiplayer
                case 'M':
                    TypeMulti(ARRwelcomemulti);
                    multiplayerPiece = Console.ReadLine();
                    Type("");
                    Player playerone = new Player(STRplayerone, multiplayerPiece);
                    Player playerTwo = new Player(STRplayertwo, playerone.SetPiece());
                    Multiplayer(playerone, playerTwo, board);
                    Console.Clear();

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
                    finish = false;
                    Type("Congratulations " + multiplayer.WinningPlayer());
                }
            
            } while (!finish);
        }
        
        public static void SinglePlayer(Player player, Player bot, Board board)
        {
            Ai ai = new Ai();
            do
            {
                ai.Run(player, bot, board);

                if (ai.IsGameFinished())
                {
                    ai.SetGameFinish();
                    finish = false;
                    Type("Congratulations " + ai.WinningPlayer());
                }
            } while (!finish);
        }
    }
}
