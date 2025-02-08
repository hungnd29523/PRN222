using System;
using System.Collections.Generic;
using OpenClosed_Principle_Demo.Model;
using OpenClosed_Principle_Demo.Utillities;

class Program
{
    static List<Book> bookList;

    static void PrintBooks(List<Book> books)
    {
        Console.WriteLine(" List of Books");
        Console.WriteLine(" --------------------");
        foreach (var item in books)
        {
            Console.WriteLine($"{item.Title.PadRight(39, ' ')} {item.Price}");
            Console.WriteLine($"{item.Author.PadRight(20, ' ')} {item.Price}");
        }
        Console.ReadLine();
    } //end PrintBooks
   static void Main(string[] args)
    {
        Console.WriteLine("Please, press 'yes' to read an extra file, ");
        Console.WriteLine("or any other key for a single file");
        var ans = Console.ReadLine();
        bookList = (ans.ToLower() == "yes") ? Utillities.ReadData() : Utillities.ReadDataExtra();
        PrintBooks(bookList);
    } //end Main
}
