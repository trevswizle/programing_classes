using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new Breath();
                    break;
                case "2":
                    activity = new Reflecting();
                    break;
                case "3":
                    activity = new Listing();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.StartActivity();
        }
    }
}

class Activity
// Create methods for displaying starting and ending messages, pausing with animation, and an abstract method for performing the activity.
{
    protected string standardMessage = "Prepare to begin...";
    protected string description;
    protected string endingMessage = "Good job! You've completed the activity.";
    protected int duration;

    public void StartActivity()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine(description);
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine(standardMessage);
        PauseWithAnimation(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine(endingMessage);
        Console.WriteLine($"You completed the activity for {duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected virtual void PerformActivity()
    {
        // To be overridden by derived classes
    }
}

class Breath : Activity
{
    public Breath()
    {
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(3);
            secondsElapsed += 6;
        }
    }
}

class Reflecting : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflecting()
    {
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        PauseWithAnimation(5);

        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            Console.WriteLine(Questions[rand.Next(Questions.Count)]);
            PauseWithAnimation(5);
            secondsElapsed += 5;
        }
    }
}

class Listing : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing()
    {
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        PauseWithAnimation(5);

        int count = 0;
        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
            secondsElapsed += 5;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}
