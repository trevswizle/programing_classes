using System;
using System.Collections.Generic;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Content { get; set; }

    public JournalEntry(string content)
    {
        Date = DateTime.Now;
        Content = content;
    }

    public override string ToString()
    {
        return $"{Date.ToString("yyyy-MM-dd HH:mm:ss")}: {Content}";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string content)
    {
        entries.Add(new JournalEntry(content));
    }

    public void ViewEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. View Entries");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your journal entry: ");
                    string content = Console.ReadLine();
                    journal.AddEntry(content);
                    break;
                case "2":
                    journal.ViewEntries();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
