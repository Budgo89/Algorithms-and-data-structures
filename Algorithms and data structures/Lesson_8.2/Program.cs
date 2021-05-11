using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_8._2
{
    class Program
    {

        static void ExternalSort(string file)
        {
            Split(file);
            SortTheChunks();
            MergeTheChunks();
        }
        static void Split(string file)
        {
            int split_num = 1;
            StreamWriter sw = new StreamWriter(string.Format("split{0:d5}.dat", split_num));
            //long read_line = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                while (sr.Peek() >= 0)
                {
                    sw.WriteLine(sr.ReadLine());

                    if (sw.BaseStream.Length > 100000 && sr.Peek() >= 0)
                    {
                        sw.Close();
                        split_num++;
                        sw = new StreamWriter(string.Format("split{0:d5}.dat", split_num));
                    }
                }
            }
            sw.Close();
        }
        static void SortTheChunks()
        {
            string cat = Directory.GetCurrentDirectory();
            foreach (string path in Directory.GetFiles(cat,"split*.dat"))
            {
                string[] contents = File.ReadAllLines(path);
                int[] contentsint = new int[contents.Length]; 
                for (int i = 0; i < contents.Length; i++)
                {
                    contentsint[i] = Convert.ToInt32(contents[i]);
                }
                Array.Sort(contentsint);
                for (int i = 0; i < contentsint.Length; i++)
                {
                    contents[i] = Convert.ToString(contentsint[i]);
                }
                Array.Sort(contentsint);
                string newpath = path.Replace("split", "sorted");
                File.WriteAllLines(newpath, contents);
                File.Delete(path);
                contents = null;
                GC.Collect();
            }
        }
        static void MergeTheChunks()
        {
            string cat = Directory.GetCurrentDirectory();
            string[] paths = Directory.GetFiles(cat,"sorted*.dat");
            int chunks = paths.Length; 
            int recordsize = 100; 
            int maxusage = 500000000; 
            int buffersize = maxusage / chunks; 
            double recordoverhead = 7.5; 
            int bufferlen = (int)(buffersize / recordsize / recordoverhead); 

            StreamReader[] readers = new StreamReader[chunks];
            for (int i = 0; i < chunks; i++)
                readers[i] = new StreamReader(paths[i]);

            Queue<string>[] queues = new Queue<string>[chunks];
            for (int i = 0; i < chunks; i++)
                queues[i] = new Queue<string>(bufferlen);

            for (int i = 0; i < chunks; i++)
                LoadQueue(queues[i], readers[i], bufferlen);

            StreamWriter sw = new StreamWriter("DataSort.txt");
            bool done = false;
            int lowest_index, j;
            string lowest_value;
            while (!done)
            {

                lowest_index = -1;
                lowest_value = "";
                for (j = 0; j < chunks; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 || String.Compare(queues[j].Peek(), lowest_value, StringComparison.CurrentCulture) < 0)
                        {
                            lowest_index = j;
                            lowest_value = queues[j].Peek();
                        }
                    }
                }

                if (lowest_index == -1) { done = true; break; }

                sw.WriteLine(lowest_value);

                queues[lowest_index].Dequeue();
                if (queues[lowest_index].Count == 0)
                {
                    LoadQueue(queues[lowest_index],
                      readers[lowest_index], bufferlen);
                    if (queues[lowest_index].Count == 0)
                    {
                        queues[lowest_index] = null;
                    }
                }
            }
            sw.Close();

           
            for (int i = 0; i < chunks; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }

        static void LoadQueue(Queue<string> queue, StreamReader file, int records)
        {
            for (int i = 0; i < records; i++)
            {
                if (file.Peek() < 0) break;
                queue.Enqueue(file.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            //var rand = new Random();
            //StreamReader sr = new StreamReader("..\\..\\data.txt");
            //Генератор файла
            //int a = 0;
            //int b = 0;
            //for (int i = 0; i < 10000000; i++)
            //{
            //    a = rand.Next(-100000, 100000);
            //    File.AppendAllText("data.txt", Convert.ToString(a));
            //    File.AppendAllText("data.txt", Environment.NewLine);

            //    Console.WriteLine(++b);
            //}
            ExternalSort("data.txt");

        }
    }
}
