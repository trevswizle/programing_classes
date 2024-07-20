using System;

public class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string ZipCode { get; set; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

public abstract class Event
{
    private string Title { get; set; }
    private string Description { get; set; }
    private DateTime Date { get; set; }
    private string Time { get; set; }
    private Address Address { get; set; }

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    private string Speaker { get; set; }
    private int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

public class Reception : Event
{
    private string RSVPEmail { get; set; }

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RSVPEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {RSVPEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main()
    {
        Address lectureAddress = new Address("123 Main St", "Cityville", "State", "12345");
        Lecture lecture = new Lecture("Tech Innovations", "A lecture on the latest in tech.", new DateTime(2024, 8, 15), "10:00 AM", lectureAddress, "John Doe", 100);

        Address receptionAddress = new Address("456 Elm St", "Townsville", "State", "67890");
        Reception reception = new Reception("Company Year-End Party", "A party to celebrate the end of the year.", new DateTime(2024, 12, 20), "7:00 PM", receptionAddress, "rsvp@example.com");

        Address outdoorGatheringAddress = new Address("789 Pine St", "Village", "State", "11223");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Fest", "A fun outdoor festival.", new DateTime(2024, 6, 30), "3:00 PM", outdoorGatheringAddress, "Sunny with a chance of rain");

        Event[] events = { lecture, reception, outdoorGathering };

        foreach (Event evt in events)
        {
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine();
        }
    }
}
