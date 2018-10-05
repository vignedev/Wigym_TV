using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using TV.Models;

namespace TV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var data = new DisplayData
            //{
            //    Sections = new System.Collections.Generic.List<Section>
            //    {
            //        new Section
            //        {
            //            Position = Position.TopLeft,
            //            Interval = 5000,
            //            DisplayObjects = new System.Collections.Generic.List<Image>()
            //        },
            //        new Section
            //        {
            //            Position = Position.TopRight,
            //            Interval = 5000,
            //            DisplayObjects = new System.Collections.Generic.List<Image>()
            //        },
            //        new Section
            //        {
            //            Position = Position.BottomLeft,
            //            Interval = 5000,
            //            DisplayObjects = new System.Collections.Generic.List<Image>()
            //        },
            //        new Section
            //        {
            //            Position = Position.BottomRight,
            //            Interval = 5000,
            //            DisplayObjects = new System.Collections.Generic.List<Image>()
            //        }
            //    },
            //    FooterText = "gasdjhagdasda",
            //    ShowNameDay = true
            //};
            //var json = JsonConvert.SerializeObject(data);
            //File.WriteAllText("~Saves/ImageDetails.json", json);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}