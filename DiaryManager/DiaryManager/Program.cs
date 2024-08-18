using System;
using System.Collections.Generic;
using System.IO;
namespace DiaryManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            DailyDiary diary = new DailyDiary("mydiary.txt");

            while (true)
            {
                Console.WriteLine("\nDaily Diary Manager");
                Console.WriteLine("1. Add Entry");
                Console.WriteLine("2. Read All Entries");
                Console.WriteLine("3. Delete Entry");
                Console.WriteLine("4. Count Entries");
                Console.WriteLine("5. Search Entries by Date");
                Console.WriteLine("6. Search Entries by Keyword");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the date (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                        {
                            Console.Write("Enter the content of the entry: ");
                            string content = Console.ReadLine();
                            diary.AddEntry(date, content);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "2":
                        diary.ReadAllEntries();
                        break;

                    case "3":
                        Console.Write("Enter the date (YYYY-MM-DD) of the entry to delete: ");
                        if (DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            diary.DeleteEntry(date);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "4":
                        Console.WriteLine($"Total Entries: {diary.CountEntries()}");
                        break;

                    case "5":
                        Console.Write("Enter the date (YYYY-MM-DD) to search for entries: ");
                        if (DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            var entries = diary.SearchByDate(date);
                            if (entries != null)
                            {
                                foreach (var entry in entries)
                                {
                                    Console.WriteLine(entry);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No entries found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "6":
                        Console.Write("Enter the keyword to search for: ");
                        string keyword = Console.ReadLine();
                        var keywordEntries = diary.SearchByKeyword(keyword);
                        if (keywordEntries != null)
                        {
                            foreach (var entry in keywordEntries)
                            {
                                Console.WriteLine(entry);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No entries found.");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    } 
}


