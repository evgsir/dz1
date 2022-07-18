using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill", "Tot" };

// создаем новый список для результатов
            var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                where p.ToUpper().StartsWith("T") && p.ToUpper().EndsWith("T") //фильтрация по критерию
                select p; // выбираем объект в создаваемую коллекцию

            foreach (string person in selectedPeople)
                Console.WriteLine(person);

            string[] files = { "a.txt", "bbb.jpg", "ccc.jpg", "dd.txt", "eeee.exe" };

            var indexExtation = 0;

            List <string> extensions = new List <string>();

            for (var i = 0; i < files.Length; i++)
            {
                indexExtation = files[i].LastIndexOf('.');
                extensions.Add(files[i].Substring(indexExtation));
            }
            
            var uniqExtention = extensions.Distinct();
            foreach (var ext in uniqExtention)
            {
                Console.WriteLine(ext);
            }
            
            var query = extensions.GroupBy(x => x)
                .Where(g => g.Count() > 0)
                .Select(y => new { Element = y.Key, Counter = y.Count() })
                .ToList();
           
            foreach (var ext in query)
            {
                Console.Write(ext.Element);
                Console.Write("  ");
                Console.Write(ext.Counter);
                Console.Write("  ");
            }
        }
    }
}