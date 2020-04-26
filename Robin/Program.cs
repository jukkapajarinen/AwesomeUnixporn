using System;

namespace Robin
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseController db = new DatabaseController();

            db.Add(new Item {
                Title = "test",
                Url = "test",
                ImgUrl = "test",
                Author = "test",
                Category = "test",
                RedditId = "test",
                Score = 1,
                CreatedUtc = 1,
                AddedUtc = 1,
            });
            db.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}
