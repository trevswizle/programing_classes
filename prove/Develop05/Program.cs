using System;

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

                }
                else if (user_input == "2")
                {

                }
                else if (user_input == "3")
                {

                }
                else if (user_input == "4")
                {

                }
                else if (user_input == "5")
                {

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
}
class GoalTracker
{

}
class Goal
{

}
class SimpleGoal
{

}
class EternalGoal
{

}
class ChecklistGoal
{

}