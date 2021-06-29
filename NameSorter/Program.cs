
using System;
using System.IO;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NameSorter
{
    class Program
    {

        //public static IConfiguration Configuration;


        static void Main(string[] args)
        {
            //ConfigureServices();
            //string unSortedFilePath = Configuration["UnsortPaths:Upath"];
            //string sortedFilePath = Configuration["sortPaths:SPath"];
                        
              string []   lines = File.ReadAllLines("unsorted-names-list.txt");
                var sortstring = lines.Select(GetLastWordToFirst).ToArray();
                Array.Sort(sortstring, lines);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
          
            File.WriteAllLines(@"sorted-names-list.txt", lines);

            Console.ReadLine();
        }

        private static string GetLastWordToFirst(string word)
        {

            var words = word.Split(' ');

            var length = words.Length;

            return words[length - 1] + " " + string.Join(" ", words, 0, length - 1);


        }

        //private static void ConfigureServices()
        //{

        //    // Build configuration
        //    Configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
        //            .AddJsonFile("config.json", false)
        //            .Build();

        //}
    }

}

