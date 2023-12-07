
using DayNamespace;

class Program
{
    static void Main(string[] args)
    {
        if (args[0] == "Setup")
        {
            Setup(args[1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Setup complete for {args[1]}.");
            Console.ResetColor();
            return;
        }

        string path = "./" + args[0] + "/input.txt";
        List<string> lines = GetLines(path);

        string result = "";
        int start = Environment.TickCount;
        switch (args[0].Replace("Test", "") + args[1])
        {
            case "Day1Part1":
                result = DayFunctions.Day1Part1(lines);
                break;
            case "Day1Part2":
                result = DayFunctions.Day1Part2(lines);
                break;

            case "Day2Part1":
                result = DayFunctions.Day2Part1(lines);
                break;
            case "Day2Part2":
                result = DayFunctions.Day2Part2(lines);
                break;

            case "Day6Part1":
                result = DayFunctions.Day6Part1(lines);
                break;

            case "Day6Part2":
                result = DayFunctions.Day6Part2(lines);
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Function {args[0]}{args[1]} not implemented yet");
                Console.ResetColor();
                break;
        }
        int end = Environment.TickCount;
        Console.WriteLine($"Day: {args[0]} {args[1]}");
        Console.WriteLine();
        Console.Write($"Result: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{result}");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Time: {end - start}ms");
        Console.ResetColor();
    }

    static List<string> GetLines(string path)
    {
        List<string> lines = new List<string>();
        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                lines.Add(s);
            }
        }
        return lines;
    }

    static void Setup(string day)
    {
        string path = "./" + day;
        Directory.CreateDirectory(path);
        string inputPath = path + "/input.txt";
        File.Create(inputPath);

        path = path + "Test";
        Directory.CreateDirectory(path);
        inputPath = path + "/input.txt";
        File.Create(inputPath);

    }
}

