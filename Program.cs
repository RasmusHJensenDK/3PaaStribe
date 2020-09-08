using System;
using System.Threading;

namespace _3PaaStribe
{
    class Program
    {
        private static char botPiece = 'X';
        private static char player2Piece = 'X';
        static void Main(string[] args)
        {
            Onboarding();
        }

        public static void Onboarding()
        {
            Console.WriteLine("Hej og velkommen til 3-På-Stribe");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Vælg Venligst, 1 eller 2 spillere");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine("Tak! - Hvilken rubrik for spiller 1? ");
            char playerPiece = Console.ReadKey().KeyChar;
            Player player = new Player("Player1", playerPiece);

            switch (input)
            {
                case '1':
                    if (player.GetPlayerPiece() == 'X') botPiece = 'O';
                    Player bot = new Player("Bot", botPiece);
                    VersusAi(player, bot);
                    break;
                case '2':
                    if (player.GetPlayerPiece() == 'X') player2Piece = 'O';
                    Player secondPlayer = new Player("Second player", player2Piece);
                    Multiplayer(player, secondPlayer);
                    break;
            }
            Console.WriteLine("Tak fordi du spillede 3-På-Stribe.");
            Console.WriteLine("Lukker ned...");
        }

        public static void VersusAi(Player player, Player bot)
        {
            Console.WriteLine("Please choose level :");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Expert");
            char lvlId = Console.ReadKey().KeyChar;
            Board board = new Board();
            switch (lvlId)
            {
                case '1':
                    board.DrawBoard();
                    do
                    {
                        Console.WriteLine("Move ? ");
                        int moveTo = Convert.ToInt32(Console.ReadLine());
                        Engine aiEasy = new Engine(player, bot, board, moveTo, withAi: true, difficulty: difficulty.Easy);

                    } while (true);
                    break;
                case '2':
                    //Engine aiMedium = new Engine(player, board, withAi: true, difficulty: difficulty.Medium);
                    break;
                case '3':
                    //Engine aiHard = new Engine(player, board, withAi: true, difficulty: difficulty.Hard);
                    break;
            }
        }

        public static void Multiplayer(Player player, Player player2)
        {
            Board board = new Board();
            int moveTo = 0;
            Engine multiplayer = new Engine(player, player2, board, moveTo, multiplayer: true);
            bool whichTurn = true;

            do
            {
                while(whichTurn)
                {
                    Console.WriteLine("Player 1 move...");
                    moveTo = Convert.ToInt32(Console.ReadLine());
                    multiplayer(player, player2, board, moveTo, multiplayer: true);
                }
                Console.WriteLine("Move ?");
                moveTo = Convert.ToInt32(Console.ReadLine());
            } while (true);
        }
    }
}
