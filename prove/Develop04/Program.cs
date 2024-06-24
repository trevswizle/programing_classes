using System;
using System.Collections.Generic;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Content { get; set; }
    public List<string> Notes { get; set; }

    public JournalEntry(string content)
    {
        Date = DateTime.Now;
        Content = content;
        Notes = new List<string>();
    }

    public void AddNote(string note)
    {
        Notes.Add(note);
    }

    public override string ToString()
    {
        string notes = Notes.Count > 0 ? string.Join("\n  - ", Notes) : "No notes";
        return $"{Date.ToString("yyyy-MM-dd HH:mm:ss")}: {Content}\nNotes:\n  - {notes}";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string content)
    {
        entries.Add(new JournalEntry(content));
    }

    public void AddNoteToEntry(int entryIndex, string note)
    {
        if (entryIndex >= 0 && entryIndex < entries.Count)
        {
            entries[entryIndex].AddNote(note);
        }
        else
        {
            Console.WriteLine("Invalid entry index.");
        }
    }

    public void ViewEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"Entry {i + 1}:\n{entries[i]}");
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
            Console.WriteLine("3. Add Note to Entry");
            Console.WriteLine("4. Exit");
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
                    Console.Write("Enter the entry number to add a note to: ");
                    int entryIndex = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Enter your note: ");
                    string note = Console.ReadLine();
                    journal.AddNoteToEntry(entryIndex, note);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
