using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Basics", "CodeWithSara", 725);
        video1.AddComment(new Comment("Mike Johnson", "This helped me understand classes so much better!"));
        video1.AddComment(new Comment("Priya Patel", "Great explanation of constructors."));
        video1.AddComment(new Comment("Tom Alvarez", "Could you do a video on inheritance next?"));

        Video video2 = new Video("Top 10 Travel Destinations 2026", "WanderlustWorld", 612);
        video2.AddComment(new Comment("Ana Souza", "Added Kyoto to my bucket list because of this!"));
        video2.AddComment(new Comment("Jake Lin", "Your camera work keeps getting better."));
        video2.AddComment(new Comment("Fatima Noor", "What drone do you use?"));
        video2.AddComment(new Comment("Chris Bell", "Number 4 is underrated, glad you included it."));

        Video video3 = new Video("Easy 20-Minute Pasta Recipe", "ChefDaniel", 480);
        video3.AddComment(new Comment("Laura Kim", "Made this tonight, my family loved it!"));
        video3.AddComment(new Comment("Omar Haddad", "Can I substitute the cream with coconut milk?"));
        video3.AddComment(new Comment("Grace Miller", "So simple and quick, thank you!"));

        Video video4 = new Video("Building a Home Gym on a Budget", "FitLifeWithJordan", 900);
        video4.AddComment(new Comment("Derek Wu", "This saved me so much money, thanks!"));
        video4.AddComment(new Comment("Nina Costa", "Where did you get that adjustable bench?"));
        video4.AddComment(new Comment("Sam Okafor", "Doing this exact setup this weekend."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}