using System;

class Program
{
    static void Main(string[] args)
    {
        string responce = "yes";

        while (responce == "yes")
        {
            Console.Write("Do you want to continue? ");
            responce = Console.ReadLine();
        }

        string response;

        do
        {
            Console.Write("Do you want to continue? ");
            response = Console.ReadLine();
        } while (response == "yes");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
    }
}