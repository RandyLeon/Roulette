using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette3
{
    class Game
    {
        public void game()
        {
            Random ran = new Random();
            var m = new Game();
            var r = new Random();
            string[] color = { "Red", "Black" };
            int[] number = { 0, 00, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 39, 31, 32, 33, 34, 35, 36 };
            string pick;
            int attempts = 0;
            int bet;
            int money = 500;
            try
            {

          
            while (money != 0)
            {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Randy's Roulette Game");
                    Console.WriteLine($"Money: {money} -- Attempts: {attempts}");
                    Console.WriteLine("Choose a type of bet to place.");
                    Console.WriteLine("a. Even    b. Odd    c. 0 to 18    d. 19 to 36    e. Red    \nf. Black    g. 1st 12    h. 2nd 12    i. 3rd 12    j. Number \nk. Columns    l. Street    m. 6Numbers    n. Split    o. Corner");
                    Console.ResetColor();
                pick = (Console.ReadLine());
                pick.ToLower();
                bool check = pick == "a" || pick == "b" || pick == "c" || pick == "d" || pick == "e" || pick == "f" || pick == "g" || pick == "h" || pick == "i" || pick == "j" || pick == "k" || pick == "l" || pick == "m" || pick == "n" || pick == "o";
                if (check == false)
                {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You either have fat fingers or you can't read...");
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                    continue;
                }
                else
                {
                    bet:
                    Console.WriteLine("How much money do you want to lose, I mean bet?");
                    bet = Convert.ToInt32(Console.ReadLine());
                    if (bet > money)
                    {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("WOAH!! calm down boss, you don't have those kind of funds.");
                            Console.WriteLine("<Press Enter to try again.>");
                            Console.ReadKey();
                            Console.ResetColor();
                        goto bet;
                    }
                    else
                    {
                        string ranColor = color[r.Next(color.Length)];
                        int ranNumber = number[r.Next(number.Length)];
                        bool even = ranNumber % 2 == 0;
                        int x;
                        if (pick == "a" && even == true || pick == "b" && even == false || pick == "e" && ranColor == "Red" || pick == "f" && ranColor == "Black")
                        {
                            EvenRedBlack(ref attempts, bet, ref money, ranColor, ranNumber);
                        }
                        else if (pick == "c" && ranNumber > 0 && ranNumber < 19)
                        {
                            Low(ref attempts, bet, ref money, ranColor, ranNumber);
                        }
                        else if (pick == "d" && ranNumber > 18 && ranNumber < 37)
                        {
                            High(ref attempts, bet, ref money, ranColor, ranNumber);
                        }
                        else if (pick == "g" && ranNumber > 0 && ranNumber < 13 || pick == "h" && ranNumber > 12 && ranNumber < 25 || pick == "i" && ranNumber > 24 && ranNumber < 37)
                        {
                            Dozens(ref attempts, bet, ref money, ranColor, ranNumber);
                        }
                        else if (pick == "j")
                        {
                            x = Number(ref attempts, bet, ref money, ranColor, ranNumber);
                        }
                        else if (pick == "k")
                        {
                            Console.WriteLine("Which column do you want to bet on? 1, 2 or 3");
                            int choice = int.Parse(Console.ReadLine());
                            check = choice == 1 || choice == 2 || choice == 3;
                            if (check == false)
                            {
                                Console.WriteLine("You're options are 1, 2 or 3");
                                Console.WriteLine("<Press Enter to continue>");
                                continue;
                            }
                            else if (choice == 1 && (new[] { 0, 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 }).Contains(ranNumber))
                            {
                                Column(ref attempts, bet, ref money, ranNumber);
                            }
                            else if (choice == 2 && (new[] { 0, 00, 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 }).Contains(ranNumber))
                            {
                                Column(ref attempts, bet, ref money, ranNumber);
                            }
                            else if (choice == 3 && (new[] { 00, 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 }).Contains(ranNumber))
                            {
                                Column(ref attempts, bet, ref money, ranNumber);
                            }
                            else
                            {
                                Lose(ref attempts, bet, ref money, ranColor, ranNumber);
                            }
                        }
                        else if (pick == "l")
                        {
                             Streetbet(ref attempts, bet, ref money, ranNumber);
                        }
                        else if (pick == "m")
                            {
                                SixNumbers(ref attempts, bet, ref money, ranNumber);
                            }
                            else if (pick == "n")
                            {
                                Split(ref attempts, bet, ref money, ranNumber);
                            }
                            else if (pick == "o")
                            {
                                Corner(ref attempts, bet, ref money, ranNumber);
                            }


                            else
                            {
                            Lose(ref attempts, bet, ref money, ranColor, ranNumber);
                        }
                    }
                }
                Console.Clear();
            }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("You did something you were not supposed to do didn't you...");
                Console.WriteLine("<Press Enter to continue>");
                Console.ResetColor();
                m.game();
            }
        }

        private static void SixNumbers(ref int attempts, int bet, ref int money, int ranNumber)
        {
            int n;
            Console.WriteLine("Enter a number that is in the first column.\n<All the numbers in that row and the row below it will be placed in the bet.>");
            n = int.Parse(Console.ReadLine());

            if (n == 1 || n == 4 || n == 7 || n == 10 || n == 13 || n == 16
             || n == 19 || n == 22 || n == 25 || n == 28 || n == 31 || n == 34)
            {
                if (n == ranNumber || n == ranNumber + 1 || n == ranNumber + 2 || n == ranNumber + 3 || n == ranNumber + 4 || n == ranNumber + 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"WOW! you actually won. {bet * 4}!");
                    Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber + 1}, {ranNumber + 2}, {ranNumber + 3}, {ranNumber + 4}, {ranNumber + 5}");
                    Console.ResetColor();
                    money += bet * 4;
                    attempts += 1;
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"HA! loser, you lost... {bet}");
                    Console.WriteLine("<Press Enter to continue>");
                    Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber + 1}, {ranNumber + 2}, {ranNumber + 3}, {ranNumber + 4}, {ranNumber + 5}");
                    Console.ResetColor();
                    money -= bet;
                    attempts += 1;
                    Console.ReadKey();
                    if (money <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You're out of money, you should probably go home.");
                        Console.WriteLine("<Press Enter to continue>");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"HA! loser, you lost... {bet}");
                Console.WriteLine("<Press Enter to continue>");
                Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber + 1}, {ranNumber + 2}, {ranNumber + 3}, {ranNumber + 4}, {ranNumber + 5}");
                Console.ResetColor();
                money -= bet;
                attempts += 1;
                Console.ReadKey();
                if (money <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You're out of money, you should probably go home.");
                    Console.WriteLine("<Press Enter to continue>");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        private static void Split(ref int attempts, int bet, ref int money, int ranNumber)
        {
            int n;
            Console.WriteLine("Choose a number for a split bet");
            n = int.Parse(Console.ReadLine());
            if (n == ranNumber || n == ranNumber - 3 || n == ranNumber - 1 || n == ranNumber + 1 || n == ranNumber + 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"WOW! you actually won. {bet * 4}!");
                Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber - 3}, {ranNumber - 1}, {ranNumber + 1}, {ranNumber + 3}");
                Console.ResetColor();
                money += bet * 4;
                attempts += 1;
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"HA! loser, you lost... {bet}");
                Console.WriteLine("<Press Enter to continue>");
                Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber - 3}, {ranNumber - 1}, {ranNumber + 1}, {ranNumber + 3}");
                Console.ResetColor();
                money -= bet;
                attempts += 1;
                Console.ReadKey();
                if (money <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You're out of money, you should probably go home.");
                    Console.WriteLine("<Press Enter to continue>");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        private static void Corner(ref int attempts, int bet, ref int money, int ranNumber)
        {
            int n;
            Console.WriteLine("Choose the top left number for yours Corner bet");
            n = int.Parse(Console.ReadLine());
            if (n == ranNumber || n == ranNumber + 1 || n == ranNumber + 3 || n == ranNumber + 4)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"WOW! you actually won. {bet * 4}!");
                Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber + 1}, {ranNumber + 3}, {ranNumber + 4}");
                Console.ResetColor();
                money += bet * 4;
                attempts += 1;
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"HA! loser, you lost... {bet}");
                Console.WriteLine("<Press Enter to continue>");
                Console.WriteLine($"The roulette rolled: {ranNumber}, {ranNumber + 1}, {ranNumber + 3}, {ranNumber + 4}");
                Console.ResetColor();
                money -= bet;
                attempts += 1;
                Console.ReadKey();
                if (money <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You're out of money, you should probably go home.");
                    Console.WriteLine("<Press Enter to continue>");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        private static void Streetbet(ref int attempts, int bet, ref int money, int ranNumber)
        {
            int n;
            Console.WriteLine("Enter a number to bet on (the number above and below the number you choose\nwill be involved in the bet: For EX betting on 20 will also bet on 19 and 21.");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"The roulette rolled: {ranNumber - 1}, {ranNumber}, {ranNumber + 1}");
            if (n == ranNumber - 1 || n == ranNumber || n == ranNumber + 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"WOW! you actually won. {bet * 10}!");
                Console.ResetColor();
                Console.ResetColor();
                money += bet * 10;
                attempts += 1;
                Console.ReadKey();
            }
            else
            {
                StreetLose(ref attempts, bet, ref money);
            }
        }

        private static void StreetLose(ref int attempts, int bet, ref int money)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"HA! loser, you lost... {bet}");
            Console.WriteLine("<Press Enter to continue>");
            Console.ResetColor();
            money -= bet;
            attempts += 1;
            Console.ReadKey();
            if (money <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You're out of money, you should probably go home.");
                Console.WriteLine("<Press Enter to continue>");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        private static void Column(ref int attempts, int bet, ref int money, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The roulette rolled: {ranNumber}");
            Console.WriteLine($"WOW! you actually won. {bet * 2}!");
            Console.ResetColor();
            money += bet * 2;
            attempts += 1;
            Console.ReadKey();
        }

        private static int Number(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            int x;
            Console.WriteLine("What number are you betting on");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine($"The roulette rolled: {ranNumber}");
            if (x == ranNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"WOW! you actually won. {bet * 35}!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Lose(ref attempts, bet, ref money, ranColor, ranNumber);
            }

            return x;
        }

        private static void Dozens(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The roulette rolled: {ranColor + " " + ranNumber}");
            Console.WriteLine($"WOW! you actually won. {bet * 2}!");
            Console.ResetColor();
            money += bet * 3;
            attempts += 1;
            Console.ReadKey();
        }

        private static void High(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The roulette rolled: {ranColor + " " + ranNumber}");
            Console.WriteLine($"WOW! you actually won. {bet * 2}!");
            Console.ResetColor();
            money += bet * 2;
            attempts += 1;
            Console.ReadKey();
        }

        private static void Low(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The roulette rolled: {ranColor + " " + ranNumber}");
            Console.WriteLine($"WOW! you actually won. {bet * 2}!");
            Console.ResetColor();
            money += bet * 2;
            attempts += 1;
            Console.ReadKey();
        }

        private static void EvenRedBlack(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Your ball landed on: {ranColor + " " + ranNumber}");
            Console.WriteLine($"WOW! you actually won. {bet * 2}!");
            Console.ResetColor();
            money += bet * 2;
            attempts += 1;
            Console.ReadKey();
        }

        private static void Lose(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"The roulette rolled: {ranColor + " " + ranNumber}");
            Console.WriteLine($"HA! loser, you lost... {bet}");
            Console.WriteLine("<Press Enter to continue>");
            Console.ResetColor();
            money -= bet;
            attempts += 1;
            Console.ReadKey();
            if (money <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You're out of money, you should probably go home.");
                Console.WriteLine("<Press Enter to continue>");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
