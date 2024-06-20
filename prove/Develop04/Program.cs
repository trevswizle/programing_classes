using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JournalApp
{
    public class JournalEntry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public JournalEntry(string prompt, string response)
        {
            Date = DateTime.Today.ToString("yyyy-MM-dd");
            Prompt = prompt;
            Response = response;
        }
    }

    public class Journal
    {
        public List<JournalEntry> Entries { get; set; } = new List<JournalEntry>();

        public void AddEntry(JournalEntry entry)
        {
            Entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (Entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            foreach (var entry in Entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public void SaveToFile(string filename)
        {
            var json = JsonConvert.SerializeObject(Entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine($"Journal saved to {filename}");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var json = File.ReadAllText(filename);
            Entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json) ?? new List<JournalEntry>();
            Console.WriteLine($"Journal loaded from {filename}");
        }
    }

    public class JournalApp
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What new thing did I learn today?",
            "What made me smile today?",
            "What challenges did I face today and how did I overcome them?",
            "What am I grateful for today?",
            "What did I do today to work towards my goals?"
        };

        private Journal _journal = new Journal();

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nJournal Menu");
                Console.WriteLine("1. New Entry");
                Console.WriteLine("2. Display Entries");
                Console.WriteLine("3. Save Journal to File");
                Console.WriteLine("4. Load Journal from File");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        NewEntry();
                        break;
                    case "2":
                        _journal.DisplayEntries();
                        break;
                    case "3":
                        SaveJournalToFile();
                        break;
                    case "4":
                        LoadJournalFromFile();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void NewEntry()
        {
            var random = new Random();
            var prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("Your response: ");
            var response = Console.ReadLine();
            var entry = new JournalEntry(prompt, response);
            _journal.AddEntry(entry);
            Console.WriteLine("Entry added.");
        }

        private void SaveJournalToFile()
        {
            Console.Write("Enter filename to save journal: ");
            var filename = Console.ReadLine();
            _journal.SaveToFile(filename);
        }

        private void LoadJournalFromFile()
        {
            Console.Write("Enter filename to load journal: ");
            var filename = Console.ReadLine();
            _journal.LoadFromFile(filename);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var app = new JournalApp();
            app.ShowMenu();
        }
    }
}
