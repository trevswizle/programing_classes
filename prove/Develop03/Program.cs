using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        Reference reference = new Reference("John", 3, new List<int> { 16 });
        Scripture scripture = new Scripture(new List<string> { "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life." });
        
        Console.WriteLine(reference.GetReference());
        Console.WriteLine(scripture.GetScripture());

        Word word = new Word();
        word.ParseScripture(scripture);
    }
}

class Scripture
{
    private List<string> words;

    public Scripture(List<string> words)
    {
        this.words = words;
    }

    public string GetScripture()
    {
        return string.Join(" ", words);
    }
}

class Reference
{
    private string book;
    private int chapter;
    private List<int> verses;

    public Reference(string book, int chapter, List<int> verses)
    {
        this.book = book;
        this.chapter = chapter;
        this.verses = verses;
    }

    public string GetReference()
    {
        return $"{book} {chapter}:{string.Join(",", verses)}";
    }
}

class Word
{
    public void ParseScripture(Scripture scripture)
    {
        string script = scripture.GetScripture();
        string[] words = script.Split(' ');

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
