using AdventOfCode2021.Days;
using AdventOfCode.Common.Interfaces;

if (args.Length == 0 || !int.TryParse(args[0], out int dayNumber))
{
    Console.WriteLine("Please specify a day number.");
    return;
}

IDay day = dayNumber switch
{
    1 => new Day1(),
    2 => new Day2(),
    // 3 => new Day3(),
    _ => throw new ArgumentException($"Day {dayNumber} has not been implemented.")
};

string filePath = Path.Combine(
    AppContext.BaseDirectory,
    "Inputs",
    $"Day{dayNumber}.txt");

if (!File.Exists(filePath))
{
    Console.WriteLine($"Input file not found: {filePath}");
    return;
}

Console.WriteLine($"Advent of Code 2021 - Day {dayNumber}");
Console.WriteLine("--------------------------------");

Console.WriteLine($"Part 1: {day.Part1(filePath)}");
Console.WriteLine($"Part 2: {day.Part2(filePath)}");
