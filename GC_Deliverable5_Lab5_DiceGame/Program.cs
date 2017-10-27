using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GC_Deliverable5_Lab5_DiceGame
{
    class Program
    {
        const byte NUM_DICE = 2;

        static void Main(string[] args)
        { 
            Console.WriteLine("/**********************************************/");
            Console.WriteLine("/* Welcome to FACETS, Dice Game of Champions! */");
            Console.WriteLine("/**********************************************/");

            Random generator = new Random();
            short[] diceHolder = new short[NUM_DICE];

            while (true)
            {
                // Prompt the user.
                GenerateDice(diceHolder);
                Console.WriteLine();

                //prevent any invalid values from reaching the random number generator
                for (int i = 0; i < diceHolder.Length; i++)
                {
                    if (diceHolder[i] == 0)
                    {
                        Console.WriteLine("I'm sorry, but it looks like you entered an invalid number. The program will terminate now.");
                        Console.WriteLine("Auf Wiedersehen!");
                        return;
                    }
                }

                // Roll 'em!
                Console.Write("Roll the dice now? (y/n): ");
                if (Console.ReadLine().ToLower()[0] == 'y')
                {
                    RollDice(diceHolder, generator);

                    Console.Write("Would you like to continue (y/n)?: ");
                    if (Console.ReadLine().ToLower()[0] != 'y')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Thanks for playing. Come back soon!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("What?! All that for nothin'?");
                    Console.WriteLine("Ciao!");
                    return;
                }
            }
        }

        public static void GenerateDice(short[] arr)
        {
            for (int i = 1; i <= NUM_DICE; i++)
            {
                arr.SetValue(GenerateDie(i), i - 1);

                if (arr[i - 1] == 0)
                {
                    return;
                }
            }
        }

        public static short GenerateDie (int diceNum)
        {
            short facets;

            Console.Write($"How many sides does die number {diceNum} have? (Max. {short.MaxValue}) Sides: ");
            bool valid = short.TryParse(Console.ReadLine(), out facets);

            if (!valid || facets < 1)
            {
                return 0;
            }

            Console.WriteLine($"Die number {diceNum} locked in with {facets} sides!");
            return facets;
        }

        public static void RollDice (short[] arr, Random gen)
        {
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                Roll();
                short rollValue = (short)gen.Next(1, (short)arr.GetValue(i));
                Console.Write(rollValue + "\r\n");
            }
        }

        public static void Roll ()
        {
            Console.Write("Roll");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
        }
    }
}
