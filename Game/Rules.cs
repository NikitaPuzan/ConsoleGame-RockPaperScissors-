using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game
{
    internal class Rules
    {
        public static string Menu(string[] menuItem)
        {
            Console.WriteLine("Avaible moves:");

            var result = menuItem.Select((x, index) => $"{index + 1} - {x}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("0 - exit\n? - help");
            
            return null;
        }
        public Rules(long computerChoice, byte[] key, string[] args)
        {
            Menu(args);
            int userChoice = Move(args);
            if (userChoice == 0) Environment.Exit(0);
            userChoice -=1;
            Console.WriteLine("Your move: "+ args[userChoice] + "\nComputer move: " + args[computerChoice]);
            RulesGames(args, userChoice, computerChoice);
            Console.WriteLine("HMAC key: " + (BitConverter.ToUInt64(key)));
        }
        static void RulesGames(string[] args, int userChoice, long computerChoice)
        {
            int winMoves = args.Length / 2;
            if (computerChoice == userChoice)
                System.Console.WriteLine("Draw");
                else {
                    for (int i = 0; i < winMoves; i++)
                    {
                        if (userChoice == args.Length - 1) {
                            userChoice = 0;
                        } else userChoice++;
                        if(userChoice  == computerChoice){
                            System.Console.WriteLine("Your win!"); return;
                        }
                        
                    }System.Console.WriteLine("Your lose!");
                }
        }
        static int Move(string[] args)
        {
            int userChoice = 0;
            Console.Write("Enter your move: ");
            
            string move = Convert.ToString(Console.ReadLine());
            CheckForTable(move, args);

            if (!int.TryParse(move, out userChoice) || userChoice < 0 || userChoice > args.Length)
            {
                Console.WriteLine("Uncorrected input");
                Environment.Exit(0);
            }
            return userChoice;
        }
        static string CheckForTable(string move, string[] args)
        {
            
            if (move == "?") {
                Table table = new Table(args);
                Environment.Exit(0);
            }
            return move;
        }
    }
}