using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose item to run: ");

            using (StreamReader fs = new StreamReader(File.OpenRead("options.json")))
            {
                var txt = fs.ReadToEnd();
                var json = JsonSerializer.Deserialize<Menu>(txt);
                

                for (int i = 0; i < json.Itens.Count; i++)
                {
                    var item = json.Itens[i];
                    Console.WriteLine($"{i} - {item.Name}");
                }

                var itemToRun = Convert.ToInt32(Console.ReadLine());
                
                System.Console.WriteLine("");
                System.Console.WriteLine("Choose the sub-item to run:");

                for (int i = 0; i < json.Itens[itemToRun].Itens.Count; i++)
                {
                    var item = json.Itens[itemToRun].Itens[i];
                    Console.WriteLine($"{i} - {item.Name}");
                }

                var subItemToRun = Convert.ToInt32(Console.ReadLine());
                var itemName = json.Itens[itemToRun].Name;
                var subItem = json.Itens[itemToRun].Itens[subItemToRun].Name;

                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("========================================================================");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("");

                try
                {
                    Type type = Type.GetType($"algorithms.{itemName}.{subItem}");
                    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                    var obj = constructor.Invoke(new object[]{});

                    System.Console.WriteLine("");
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }

            }
        }
    }

    public class Menu {
        public List<Options> Itens { get; set; }
    }
    public class Options
    {
        public string Name { get; set; }
        public List<Options> Itens { get; set; }
    }
}
