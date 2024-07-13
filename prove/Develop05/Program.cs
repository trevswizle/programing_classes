using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        DisplayMenu menu = new DisplayMenu();
        menu.DisplayMainMenu();
    }
}

class DisplayMenu
{
    private GoalTracker goalTracker = new GoalTracker();

    public void DisplayMainMenu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Create a Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            string user_input = Console.ReadLine();

            if (user_input == "1")
            {
                CreateGoal();
            }
            else if (user_input == "2")
            {
                goalTracker.ListGoals();
            }
            else if (user_input == "3")
            {
                Console.WriteLine("Enter filename:");
                string filename = Console.ReadLine();
                goalTracker.SaveGoals(filename);
            }
            else if (user_input == "4")
            {
                Console.WriteLine("Enter filename:");
                string filename = Console.ReadLine();
                goalTracker.LoadGoals(filename);
            }
            else if (user_input == "5")
            {
                RecordEvent();
            }
            else if (user_input == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Error, Please try again.");
            }
        }
    }

    private void CreateGoal()
    {
        bool goalRunning = true;
        while (goalRunning)
        {
            Console.WriteLine("What type of goal do you want it to be?");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Checklist Goal");
            Console.WriteLine("3. Eternal Goal");

            string user_inputGoalChoice = Console.ReadLine();

            if (user_inputGoalChoice == "1")
            {
                Console.WriteLine("What is the name of the Goal?");
                string goalName = Console.ReadLine();
                Console.WriteLine("How many points is the goal worth?");
                int points = int.Parse(Console.ReadLine());
                goalTracker.AddGoal(new SimpleGoal { Name = goalName, Points = points });
                goalRunning = false;
            }
            else if (user_inputGoalChoice == "2")
            {
                Console.WriteLine("What is the name of the Goal?");
                string goalName = Console.ReadLine();
                Console.WriteLine("How many points is the goal worth?");
                int points = int.Parse(Console.ReadLine());
                Console.WriteLine("How many steps does this goal have?");
                int totalSteps = int.Parse(Console.ReadLine());
                goalTracker.AddGoal(new ChecklistGoal { Name = goalName, Points = points, TotalSteps = totalSteps });
                goalRunning = false;
            }
            else if (user_inputGoalChoice == "3")
            {
                Console.WriteLine("What is the name of the Goal?");
                string goalName = Console.ReadLine();
                Console.WriteLine("How many points is the goal worth?");
                int points = int.Parse(Console.ReadLine());
                goalTracker.AddGoal(new EternalGoal { Name = goalName, Points = points });
                goalRunning = false;
            }
            else
            {
                Console.WriteLine("Error, Please try again.");
            }
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("Enter the name of the goal to record an event:");
        string goalName = Console.ReadLine();
        goalTracker.RecordEvent(goalName);
    }
}

class GoalTracker
{
    private List<Goal> goals = new List<Goal>();

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
        Console.WriteLine($"Goal '{goal.Name}' added.");
    }

    public void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to list.");
            return;
        }

        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - Points: {goal.Points}");
        }
    }

    public void SaveGoals(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(goals, options);
        File.WriteAllText(filename, jsonString);
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string jsonString = File.ReadAllText(filename);
            goals = JsonSerializer.Deserialize<List<Goal>>(jsonString);
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }
}

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    public abstract void RecordEvent();
}

class SimpleGoal : Goal
{
    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
    }
}

class EternalGoal : Goal
{
    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' progress recorded! You earned {Points} points.");
    }
}

class ChecklistGoal : Goal
{
    public int TotalSteps { get; set; }
    public int CompletedSteps { get; set; }

    public override void RecordEvent()
    {
        if (CompletedSteps < TotalSteps)
        {
            CompletedSteps++;
            Console.WriteLine($"Progress recorded for goal '{Name}'. {CompletedSteps}/{TotalSteps} steps completed.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' already completed!");
        }
    }
}
