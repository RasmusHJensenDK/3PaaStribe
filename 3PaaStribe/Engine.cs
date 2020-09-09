using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Drawing;

namespace _3PaaStribe
{
    class Engine: Multiplayer
    {
        //User input variables. Get rids of theese somehow..
        #region
        static string piece = "X";
        static bool finish = true;
        private static char[] gamemodes = { 'S', 'M' };
        #endregion

        public Engine()
        {
            Type(ReturnString(18));
            ShowSimplePercentage();
            ClearConsole();
        }

        public void EngineRun()
        {
            Type(ReturnString(0));
            Type(ReturnString(1));
            Player player = new Player("Player", "X", ConsoleColor.Green);
            SetKeyChar();
            Boolean gamemode = gamemodes.Contains(GetKeyChar());
            Board board = new Board();

            while (!gamemode)
            {
                TypeMulti(ARRmodeandremember);
                SetKeyChar();
                gamemode = gamemodes.Contains(GetKeyChar());
            }

            switch (GetKeyChar())
            {
//Singleplayer
                case 'S':
                    TypeMulti(ARRwelcomesingle);
                    SetPiece();
                    Type("");

                    while (!player.PlayerPieces(GetPiece()))
                    {
                        TypeMulti(ARRrememberxoro);
                        GetPiece();
                    }

                    Player singlePlayer = new Player(ReturnString(16), piece, ConsoleColor.Red);
                    Player bot = new Player(ReturnString(5), singlePlayer.SetBotPiece(), ConsoleColor.Yellow);

                    SinglePlayer(singlePlayer, bot, board);

                    Type("Congratulations ");

                    break;
//Multiplayer
                case 'M':
                    TypeMulti(ARRwelcomemulti);
                    SetPiece();
                    Type("");
                    Player playerone = new Player(ReturnString(16), GetPiece(), ConsoleColor.Red);
                    Player playerTwo = new Player(ReturnString(17), playerone.SetBotPiece(), ConsoleColor.Yellow);
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
        static void ShowSimplePercentage()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(25);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\rDone!          ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
