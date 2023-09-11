using System;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        int totalScore = 0;
        int questionIndex = 0;
        string[] questions =
        {
            "Which planet is known as the 'Red Planet'?",
            "Who wrote the novel 'Pride and Prejudice'?",
            "What is the chemical symbol for iron?",
            "What is the largest species of shark?",
            "In which year did the Titanic sink?",
            "What is the highest-grossing film of all time?",
            "Which gas do humans exhale when they breathe?",
            "Who is known as the 'Father of Modern Computer Science'?",
            "What is the largest organ in the human body?",
            "Which country is famous for the Great Wall?"
        };

        string[][] answers =
        {
            new string[] { "Mars", "Venus", "Saturn" },
            new string[] { "Jane Austen", "Emily Brontë", "Charles Dickens" },
            new string[] { "Fe", "Ir", "Au" },
            new string[] { "Whale shark", "Great white shark", "Hammerhead shark" },
            new string[] { "1912", "1937", "1958" },
            new string[] { "Avatar", "Avengers: Endgame", "Titanic" },
            new string[] { "Carbon dioxide (CO2)", "Oxygen (O2)", "Nitrogen (N2)" },
            new string[] { "Alan Turing", "Steve Jobs", "Bill Gates" },
            new string[] { "Skin", "Heart", "Liver" },
            new string[] { "China", "India", "Russia" }
        };

        Random rand = new Random();

        while (questionIndex < questions.Length)
        {
            Console.Clear();
            int[] randomOrder = RandomOrder(answers[questionIndex].Length);

            Console.WriteLine(questions[questionIndex]);

            for (int i = 0; i < answers[questionIndex].Length; i++)
            {
                Console.WriteLine($"{(char)('a' + i)}) {answers[questionIndex][randomOrder[i]]}");
            }

            char userAnswer = Console.ReadKey().KeyChar;
            int correctAnswerIndex = Array.IndexOf(randomOrder, 0);

            if (userAnswer == (char)('a' + correctAnswerIndex))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRight!\n");
                totalScore += 10;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong!\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Any Key To Continue...");
            Console.ReadKey();

            questionIndex++;
        }

        Console.Clear();
        Console.WriteLine($"Congrats!, {totalScore}");
    }

    static int[] RandomOrder(int length)
    {
        Random rand = new Random();
        int[] order = new int[length];
        for (int i = 0; i < length; i++)
        {
            order[i] = i;
        }
        for (int i = 0; i < length; i++)
        {
            int temp = order[i];
            int randomIndex = rand.Next(i, length);
            order[i] = order[randomIndex];
            order[randomIndex] = temp;
        }
        return order;
    }
}