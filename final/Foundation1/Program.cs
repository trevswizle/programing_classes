using System;

// Abstraction with YouTube Videos
class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Video of Cats!!!", "PewDiePiE", 300);
        Video video2 = new Video("Scary Games 500", "Markiplier", 600);
        Video video3 = new Video("Make UP Tutorial Video", "Logan Paul", 900);

        // Add comments to videos
        video1.AddComment(new Comment("trevswizle", "Great video!"));
        video1.AddComment(new Comment("G.garder", "Thanks for sharing."));
        video1.AddComment(new Comment("willbilly", "Awesome content!"));
        video1.AddComment(new Comment("Taylorswifty250", "Do do dod dodo dododo do"));

        video2.AddComment(new Comment("RealDonaldTrump", "Very informative."));
        video2.AddComment(new Comment("Hotmoms", "I learned a lot."));
        video2.AddComment(new Comment("Unicornflame", "Keep it up!"));

        video3.AddComment(new Comment("ninjaman", "Nice explanation."));
        video3.AddComment(new Comment("JoeBiden", "Well done."));
        video3.AddComment(new Comment("URmom", "Fantastic video!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
    public List<Comment> GetComments()
    {
        return Comments;
    }
}
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}