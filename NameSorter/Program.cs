
using System;
using System.IO;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NameSorter
{
    public class Program
    {

       public static IConfiguration Configuration;


        static void Main(string[] args)
        {
            
            
            try
            {

                // Calling ConfigureServices Function
                 ConfigureServices();

                /* File location is stored in config.json file,this allows for ease in case the file needs to be moved somewhere else.*/
                string unSortedFilePath = Configuration["Paths:UnSortedfile"];
                string sortedFilePath = Configuration["Paths:Sortedfile"];

                //Defines an array of strings
                string[] lines=null;

                // checks whether the file existed or not
                if (File.Exists(unSortedFilePath))
                {
                   // Reads data from unsorted-names-list.txt file
                   lines = File.ReadAllLines(unSortedFilePath);

                    //calling GetLastWordToFirst Method to move Lastname to Front and storing dats into sortstring
                    var sortstring = lines.Select(GetLastWordToFirst).ToArray();

                    //sorting the given data using the key "sortstring" into lines
                    Array.Sort(sortstring, lines);
                 
                    //Displaying sorted data on console
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }

                    //path for the sorted file
                    Console.WriteLine("Path for the Sorted file : \\NameSorter\\NameSorter\\bin\\Debug\\net5.0");

                    //writing sorted data into sorted-names-list.txt file
                    File.WriteAllLines(sortedFilePath, lines);


                    Console.ReadLine();
                }
                //If file does not exist, throw file not found exception, as no point in continuing
                 else throw new FileNotFoundException("FileNotFound Check config.json file");
            }
            //Displaying the error message
              catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string GetLastWordToFirst(string word)
        {
            //splitting the line into words based on blankspace
            var words = word.Split(' ');
           
            //finding the count/length of the words
            var length = words.Length;

            //Adding the last word infront of the line and returns the string
            return words[length - 1] + " " + string.Join(" ", words, 0, length - 1);


        }
        // Adding the json file and set path for the text file
        private static void ConfigureServices()
        {

            // build configuration
            Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("config.json", false)
                    .Build();

        }
    }

}

