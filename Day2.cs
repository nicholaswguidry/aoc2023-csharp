namespace DayFunctions
{
    using System.Text.RegularExpressions;
    public class Day2
    {
        public static string Part1(List<string> lines)
        {
            int total = 0;
            foreach (string s in lines)
            {
                int colonIndex = s.IndexOf(':');
                string gameString = Regex.Match(s.Substring(0, s.IndexOf(':')), @"\d+").Value;

                int gameInt = int.Parse(gameString);

                // between colonIndex and the first ; is set 1
                // create sets between ; and the end of the line

                List<int> lineRed = new List<int>();
                List<int> lineBlue = new List<int>();
                List<int> lineGreen = new List<int>();
                while (colonIndex < s.Length)
                {
                    int setStart = colonIndex;
                    int setEnd = s.IndexOf(';', setStart + 1);
                    if (setEnd == -1)
                    {
                        setEnd = s.Length;
                    }
                    string setString = s.Substring(setStart + 1, setEnd - setStart - 1);



                    int redScore = ParseScore(setString, "red");
                    lineRed.Add(redScore);

                    int blueScore = ParseScore(setString, "blue");
                    lineBlue.Add(blueScore);

                    int greenScore = ParseScore(setString, "green");
                    lineGreen.Add(greenScore);

                    colonIndex = setEnd;
                }

                int[] redArray = lineRed.ToArray();
                int[] blueArray = lineBlue.ToArray();
                int[] greenArray = lineGreen.ToArray();

                bool countGame = (
                    blueArray.Max() <= 14 &&
                    redArray.Max() <= 12 &&
                    greenArray.Max() <= 13
                );

                if (countGame)
                {
                    total += gameInt;
                }

            }

            return total.ToString();
        }

        public static string Part2(List<string> lines)
        {
            int total = 0;
            foreach (string s in lines)
            {
                //parse the integer in the digit-only substring until we hit the first `:`
                //gameString is the string of the game number
                int colonIndex = s.IndexOf(':');
                string gameString = Regex.Match(s.Substring(0, s.IndexOf(':')), @"\d+").Value;

                int gameInt = int.Parse(gameString);

                // between colonIndex and the first ; is set 1
                // create sets between ; and the end of the line

                List<int> lineRed = new List<int>();
                List<int> lineBlue = new List<int>();
                List<int> lineGreen = new List<int>();
                while (colonIndex < s.Length)
                {
                    int setStart = colonIndex;
                    int setEnd = s.IndexOf(';', setStart + 1);
                    if (setEnd == -1)
                    {
                        setEnd = s.Length;
                    }
                    string setString = s.Substring(setStart + 1, setEnd - setStart - 1);



                    int redScore = ParseScore(setString, "red");
                    if (redScore > 0)
                    {
                        lineRed.Add(redScore);
                    }

                    int blueScore = ParseScore(setString, "blue");
                    if (blueScore > 0)
                    {
                        lineBlue.Add(blueScore);
                    }

                    int greenScore = ParseScore(setString, "green");
                    if (greenScore > 0)
                    {
                        lineGreen.Add(greenScore);
                    }

                    colonIndex = setEnd;
                }

                int[] redArray = lineRed.ToArray();
                int[] blueArray = lineBlue.ToArray();
                int[] greenArray = lineGreen.ToArray();

                int gamePower = redArray.Max() * blueArray.Max() * greenArray.Max();

                // Console.WriteLine($"Game {gameInt} - {gamePower} points.");
                total += gamePower;

            }
            return total.ToString();
        }

        private static int ParseScore(string scoreString, string color)
        {
            // remove the ' color' and get the int after finding match
            string num = Regex.Match(scoreString, @"\d+ " + color).Value;
            if (num == "")
            {
                num = "0";
            }
            else
            {
                num = num.Replace(" " + color, "");
            }
            int score = int.Parse(num);

            return score;
        }
    }
}