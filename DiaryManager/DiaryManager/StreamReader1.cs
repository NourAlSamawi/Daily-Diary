using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryManager
{
    internal class StreamReader1
    {
        public static void StreamMethod(string filepath)
        {
            if (File.Exists(filepath))
            {
                StreamReader? sReader = null;

                try
                {
                    sReader = new StreamReader(filepath);
                    string line;
                    while ((line = sReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }

                }
                finally
                {

                    sReader.Close();
                }

            }
            else
            {
                Console.WriteLine("File not found");
            }



        }
    }
}
