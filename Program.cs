using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "file.txt";
            Stack<string> sentencesStack = new Stack<string>();
            string[] lines = File.ReadAllLines(filePath);
            string text = string.Join(" ", lines);
            string[] sentences = Regex.Split(text, @"(?<=[.!?])");
            int count = 0;
            foreach (var sentence in sentences)
            {
                if (count < 3)
                {
                    sentencesStack.Push(sentence.Trim());
                    count++;
                }
                else
                {
                    break;
                }
            }
            
            Console.WriteLine("Три предложения в обратном порядке:");

            while (sentencesStack.Count > 0)
            {
                Console.WriteLine(sentencesStack.Pop());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}