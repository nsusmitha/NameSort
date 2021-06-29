using System;
using System.IO;
using System.Linq;
using System.Configuration;


namespace NameSorter
{
    class Program
    {
        private static string GetLastWordToFirst(string word)
        {
           
            var words = word.Split(' ');
            
            var length = words.Length;

            return words[length - 1] + " " + string.Join(" ", words, 0, length - 1);
            

        }
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines(@"D:\unsorted-names-list.txt");


            var sortstring = lines.Select(GetLastWordToFirst).ToArray();


            System.Array.Sort(sortstring, lines);

          
            


            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines(@"D:\sorted-names-list.txt", lines);


            Console.ReadLine();
        }
    }

}
