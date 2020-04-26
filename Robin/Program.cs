using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Robin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DatabaseController db = new DatabaseController();
            RedditController reddit = new RedditController();

            List<RedditChildData> posts = await reddit.FetchUnixpornPosts();
            foreach (var post in posts)
            {
                Console.WriteLine(post.Title);
            }

            // db.Add(new Item {
            //     Title = "test",
            //     Url = "test",
            //     ImgUrl = "test",
            //     Author = "test",
            //     Category = "test",
            //     RedditId = "test",
            //     Score = 1,
            //     CreatedUtc = 1,
            //     AddedUtc = 1,
            // });
            // db.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}
