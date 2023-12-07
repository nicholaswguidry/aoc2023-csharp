namespace DayNamespace
{
    using System.Text.RegularExpressions;
    public class DayFunctions
    {
        public static string Day1Part1(List<string> lines)
        {
            int total = 0;
            foreach (string s in lines)
            {
                List<char> digits = new List<char>();
                digits = Regex.Matches(s, @"\d").Cast<Match>().Select(m => m.Value[0]).ToList();

                if (digits.Count == 0)
                {
                    // if there are no digits in the line, skip it
                    continue;
                }
                else if (digits.Count == 1)
                {
                    digits.Add(digits[0]);
                }


                // Console.WriteLine("{0}{1}", digits[0], digits[digits.Count - 1]);
                int twoDigitVal = int.Parse(digits[0].ToString() + digits[digits.Count - 1]);
                total += twoDigitVal;
            }

            return total.ToString();
        }

        public static string Day1Part2(List<string> lines)
        {
            Dictionary<string, char> stringToInt = new Dictionary<string, char>
            {
                // define one to nine
                { "one", '1' },
                { "two", '2' },
                { "three", '3' },
                { "four", '4' },
                { "five", '5' },
                { "six", '6' },
                { "seven", '7' },
                { "eight", '8' },
                { "nine", '9' }
            };
            int total = 0;
            foreach (string s in lines)
            {
                List<char> digits = new List<char>();

                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    string subString = s.Substring(i);
                    if (c >= '0' && c <= '9')
                    {
                        digits.Add(c);
                    }
                    else
                    {

                        Match match = Regex.Match(subString, @"^one|^two|^three|^four|^five|^six|^seven|^eight|^nine");
                        if (match.Success)
                        {
                            digits.Add(stringToInt[match.Value]);
                        }
                    }
                }
                if (digits.Count == 0)
                {
                    continue;
                }
                else if (digits.Count == 1)
                {
                    digits.Add(digits[0]);
                }


                int twoDigitVal = int.Parse(digits[0].ToString() + digits[digits.Count - 1]);
                total += twoDigitVal;
            }

            return total.ToString();
        }

        public static string Day2Part1(List<string> lines)
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

        public static string Day2Part2(List<string> lines)
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

        public static string Day6Part1(List<string> lines)
        {
            //get the digits of line 0
            Match[] times = Regex.Matches(lines[0], @"\d+").Cast<Match>().ToArray();
            //get the digits of line 1
            Match[] distances = Regex.Matches(lines[1], @"\d+").Cast<Match>().ToArray();
            int winProduct = 1;

            for (int i = 0; i < times.Length; i++)
            {
                int winning = 0;
                for (int j = 1; j < int.Parse(times[i].Value); j++)
                {

                    int movementTime = int.Parse(times[i].Value) - j;
                    if (j * movementTime > int.Parse(distances[i].Value))
                    {
                        winning++;
                    }
                }

                winProduct *= winning;

            }

            return winProduct.ToString();

        }

        public static string Day6Part2(List<string> lines)
        {

            //get the digits of line 0
            Match[] times = Regex.Matches(lines[0], @"\d+").Cast<Match>().ToArray();

            UInt64 time = UInt64.Parse(String.Join("", times.ToList()));


            //get the digits of line 1
            Match[] distances = Regex.Matches(lines[1], @"\d+").Cast<Match>().ToArray();
            UInt64 distance = UInt64.Parse(String.Join("", distances.ToList()));

            int winning = 0;
            for (UInt64 j = 1; j < time; j++)
            {

                UInt64 movementTime = time - j;
                if (j * movementTime > distance)
                {
                    winning++;
                }
            }

            return winning.ToString();

        }
    }
}