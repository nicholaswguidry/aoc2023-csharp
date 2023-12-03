using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string path = "./input.txt";

        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";

            while ((s = sr.ReadLine()) != null)
            {
                // do something here for each line of the input, `s`


            }

            int[] myArray = { 2, 3, 1, 6, 4 };
            Console.WriteLine($"Max is {myArray.Max()}");
        }
    }
}