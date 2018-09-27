using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        ulong tick;

        byte year = 60;
        byte month = 0;
        byte day = 0;
        byte hour = 0;
        byte minute = 0;
        byte second = 0;
        ushort dayy = 0;

        long pEpoch;
        long epoch;

        byte savecounts;

        public void Run()
        {
            Console.WriteLine("=== Y2K Demonstration using terrible C# code ===");

            while(true)
            {
                // Spaghetti bullshit that prints stuffs to the console. i want to kms btw
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"This is tick number {tick}.");
                if(tick < 10000)
                {
                    Console.WriteLine("                                DD MM YY  HH MM SS");
                }
                else
                {
                    Console.WriteLine("Srsly what the fuck r u doing   DD MM YY  HH MM SS");
                }
                Console.WriteLine($"The current (simulated) time is {ForceDd(day+1)}/{ForceDd(month+1)}/{ForceDd(year)}  {ForceDd(hour)}:{ForceDd(minute)}:{ForceDd(second)}                    ");
                Console.WriteLine($"The change in time last tick was {epoch - pEpoch}                    \b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");

                // If we have an abnormal epoch change, write it to the part of the console that isnt being rewritten, and offset our line for doing this by 1 for the next time.
                if((epoch - pEpoch > 1) && tick != 1)
                {
                    Console.SetCursorPosition(0, savecounts + 6);
                    ++savecounts;
                    Console.WriteLine($"Time per tick was abnormal at tick {tick} with {epoch - pEpoch} seconds passed. ({ForceDd(day + 1)}/{ForceDd(month + 1)}/{ForceDd(year)}  {ForceDd(hour)}:{ForceDd(minute)}:{ForceDd(second)})");
                }

                // Our program speed. Comment out this line to time travel with the speed of 10 billion sonics.
                System.Threading.Thread.Sleep(1000);
                Count();
                ++tick;
            }
        }

        public void Count()
        {
            ++second;

            if (second >= 60)
            {
                second = 0;
                ++minute;
            }

            if (minute >= 60)
            {
                minute = 0;
                ++hour;
            }

            if (hour >= 24)
            {
                hour = 0;
                ++day;
                ++dayy;
            }

            if (dayy > 364)
            {
                dayy = 0;
            }

            switch (month)
            {
                // February
                case 1:
                    if (day > 27)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // April
                case 3:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // June
                case 5:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // September
                case 8:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // November
                case 10:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;
                
                // January, March, May July, August, October, December
                default:
                    if (day > 30)
                    {
                        day = 0;
                        ++month;
                    }
                    break;
            }

            if (month >= 12)
            {
                month = 0;
                ++year;
            }

            if (year > 99)
            {
                year = 0;
            }

            pEpoch = (long) epoch;

            epoch = ((long) year * 31536000);
            epoch += 
                ((long) dayy * 86400) +
                (hour * 3600) +
                (minute * 60) +
                second;
        }

        public static string ForceDd(int num)
        {
            if(num >= 10)
            {
                return (Convert.ToString(num));
            }
            else
            {
                return ($"0{Convert.ToString(num)}");
            }
        }
    }
}
