using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{

    public class Strings
    {
        private static string STRwelcometothirdonarow = "Hello! - Welcome to 3 on a line"; //0
        private static string STRsingleormulti = "(S)ingle or (M)ultiplayer?"; //1
        private static string STRwelcometosingle = "Welcome to Singleplayer"; //2
        private static string STRwelcometomultiplayer = "Welcome to Multiplayer"; //3 
        private static string STRpiece = "Which piece do you want to use? X / O"; //4
        private static string STRbot = "bot"; //5
        private static string STRplaceyourpiece = "Place your piece "; //6
        private static string STRwin = " won the game!"; //7
        private static string STRplayagain = "Do you want to play again? Y / N"; //8
        private static string STRthanksforplaying = "Thanks for playing!"; //9
        private static string STRcongratulations = "Congratulations "; //10
        private static string STRpleacemoveapiece = " please move a piece"; //11
        private static string STRallreadythere = "You chose a spot allready there.. Chose again.."; //12
        private static string STRhastobe = "Mode has to S or M"; //13
        private static string STRremember = "Remember the uppercase!!"; //14
        private static string STRxoro = "Piece has to X or O"; //15

        private static string STRplayerone = "PlayerOne"; //16
        private static string STRplayertwo = "PlayerTwo"; //17

        private static string STRstartinggame = "Starting game.."; //18

        public static char CHRpieceO = 'O';
        public static char CHRpieceX = 'X';

        private static string[] myStrings = { STRwelcometothirdonarow, STRsingleormulti, STRwelcometosingle, STRwelcometomultiplayer, STRpiece, STRbot, STRplaceyourpiece, STRwin, STRplayagain, STRthanksforplaying, STRcongratulations, STRpleacemoveapiece, STRallreadythere, STRhastobe, STRremember, STRxoro, STRplayerone, STRplayertwo, STRstartinggame };


        public static string[] ARRbuilderwelcome = { STRwelcometothirdonarow, STRsingleormulti };
        public static string[] ARRwelcomesingle = { STRwelcometosingle, STRpiece };
        public static string[] ARRwelcomemulti = { STRwelcometomultiplayer, STRpiece };
        public static string[] ARRmodeandremember = { STRhastobe, STRremember };
        public static string[] ARRrememberxoro = { STRxoro, STRremember };

        private static char keyChar { get; set; }
        private static string setPiece { get; set; }

        public static void Type(string output)
        {
            Console.WriteLine(output);
        }

        public static void TypeMulti(string[] strings)
        {
            foreach (string str in strings)
            {
                Type(str.ToString());
            }
        }

        public string ReturnString(int i)
        {
            return myStrings[i];
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void SetKeyChar()
        {
            keyChar = Console.ReadKey().KeyChar;
        }

        public char GetKeyChar()
        {
            return keyChar;
        }

        public void SetPiece()
        {
            setPiece = Console.ReadLine();
        }

        public string GetPiece()
        {
            return setPiece;
        }
    }
}
