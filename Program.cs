﻿using System.Text.RegularExpressions;

namespace AdventOfCode.Yr2022
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            foreach (string filename in Directory.GetFiles(Environment.CurrentDirectory, "*??.txt"))
            {
                int day = int.Parse(Regex.Match(filename, "input([0-9]{2}).txt").Groups[1].Value);
                // Reflection is used to dynamically access each day's class, instead of specifying each one individually
                Console.WriteLine($"==== Day {day:00} ====");
                string[] input = File.ReadAllText(filename).TrimEnd().Split('\n');
                Console.WriteLine(Type.GetType($"AdventOfCode.Yr2022.D{day:00}")!.GetMethod("PartOne")!.Invoke(null, new object[] { input }));
                Console.WriteLine(Type.GetType($"AdventOfCode.Yr2022.D{day:00}")!.GetMethod("PartTwo")!.Invoke(null, new object[] { input }));
                Console.WriteLine();
            }
        }
    }
}
