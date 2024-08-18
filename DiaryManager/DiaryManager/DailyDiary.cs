using System;
using System.Collections.Generic;
using System.IO;

namespace DiaryManager
{

    public class DailyDiary
    {
        private readonly string filePath;

        public DailyDiary(string filePath)
        {
            this.filePath = filePath;
        }

        public void AddEntry(DateTime date, string content)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{date:yyyy-MM-dd}|{content}");
            }
            Console.WriteLine("Entry added successfully.");
        }

        public void ReadAllEntries()
        {
            if (File.Exists(filePath))
            {
                string[] entries = File.ReadAllLines(filePath);
                foreach (string entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }

        public void DeleteEntry(DateTime date)
        {
            if (File.Exists(filePath))
            {
                var entries = File.ReadAllLines(filePath).ToList();
                bool entryFound = false;

                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].StartsWith(date.ToString("yyyy-MM-dd")))
                    {
                        entries.RemoveAt(i);
                        entryFound = true;
                        break;
                    }
                }

                if (entryFound)
                {
                    File.WriteAllLines(filePath, entries);
                    Console.WriteLine("Entry deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No entry found with that date.");
                }
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }

        public int CountEntries()
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).Length;
            }
            else
            {
                Console.WriteLine("Diary file not found.");
                return 0;
            }
        }

        public List<Entry> SearchByDate(DateTime date)
        {
            if (File.Exists(filePath))
            {
                var entries = File.ReadAllLines(filePath)
                                  .Where(line => line.StartsWith(date.ToString("yyyy-MM-dd")))
                                  .Select(line => CreateEntry(line))
                                  .ToList();

                return entries.Any() ? entries : null;
            }
            else
            {
                Console.WriteLine("Diary file not found.");
                return null;
            }
        }

        public List<Entry> SearchByKeyword(string keyword)
        {
            if (File.Exists(filePath))
            {
                var entries = File.ReadAllLines(filePath)
                                  .Where(line => line.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                  .Select(line => CreateEntry(line))
                                  .ToList();

                return entries.Any() ? entries : null;
            }
            else
            {
                Console.WriteLine("Diary file not found.");
                return null;
            }
        }

        private Entry CreateEntry(string line)
        {
            var parts = line.Split('|');
            DateTime date = DateTime.Parse(parts[0]);
            string content = parts.Length > 1 ? parts[1] : string.Empty;
            return new Entry(date, content);
        }
    }

  
}

   