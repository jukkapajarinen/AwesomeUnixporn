using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Batman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string webRoot = Directory.GetCurrentDirectory() + "/Public";
            string contentRoot = Directory.GetCurrentDirectory();
            string razorRoot = "/Views";

            IWebHostBuilder webApplication = new WebHostBuilder()
                .UseKestrel()
                .UseWebRoot(webRoot)
                .UseContentRoot(contentRoot)
                .UseUrls("http://localhost:5000")
                .Configure(app => {
                    app.UseStaticFiles();
                    app.UseRouting();
                    app.UseEndpoints(ep => ep.MapRazorPages());
                    app.UseStatusCodePagesWithRedirects("/");
                })
                .ConfigureServices(app => {
                    app.AddRazorPages().WithRazorPagesRoot(razorRoot);
                });

            Console.WriteLine("Starting self-hosted Batman via Kestrel.");
            webApplication.Build().Run();
        }
    }
}
