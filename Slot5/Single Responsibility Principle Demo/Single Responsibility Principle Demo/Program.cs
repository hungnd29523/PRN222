using System;
using System.IO;
using Newtonsoft.Json;
using Single_Responsibility_Principle_Demo.Model;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("List of Book");
        Console.WriteLine("---------------");
        var CadJSON = File.ReadAllText("Data/BookStore.json");
        var bookList = JsonConvert.DeserializeObject<Book[]>(CadJSON);
        foreach(var item in bookList)
        {
            Console.WriteLine($"{item.Title.PadRight(39,' ')}"+
                $"{item.Author.PadRight(15,' ')} {item.Price}");
        }
        Console.ReadLine();
    }
}