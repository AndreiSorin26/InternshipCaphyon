using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Internship
{
    class Program
    {
        static void Task1()
        {
            SortedSet<string> packages = new SortedSet<string>();
            foreach (string line in File.ReadAllLines("deps.in") )
            {
                string[] pair = line.Split(' ');
                packages.Add(pair[0]);
                packages.Add(pair[1]);
            }
            
            StringBuilder text = new StringBuilder("");
            foreach (string package in packages.ToArray())
                text.Append(package + "\n");
            File.WriteAllText("task1.out", text.ToString());
        }

        static void Task2()
        {
            SortedDictionary<string, SortedSet<string>> deps = new SortedDictionary<string, SortedSet<string>>();
            foreach (string line in File.ReadAllLines("deps.in"))
            {
                string[] pair = line.Split(' ');

                if( !deps.ContainsKey(pair[0]) )
                    deps.Add(pair[0], new SortedSet<string>());
                deps[pair[0]].Add(pair[1]);

                foreach (var aux in deps.Values)
                    if (aux.Contains(pair[0]))
                        aux.Add(pair[1]);

                if (deps.ContainsKey(pair[1]))
                    foreach (string dep in deps[pair[1]])
                        deps[pair[0]].Add(dep);
                else
                    deps.Add(pair[1], new SortedSet<string>());
            }

            StringBuilder text = new StringBuilder("");
            foreach(string package in deps.Keys)
            {
                text.Append(package + " ");
                foreach (string dep in deps[package])
                    text.Append(dep + " ");
                text.Append("\n");
            }
            File.WriteAllText("task2.out",text.ToString());
        }

        static void Task3()
        {
            SortedSet<string> packages = new SortedSet<string>();
            foreach (string line in File.ReadAllLines("deps.in"))
            {
                string[] pair = line.Split(' ');
                packages.Add(pair[0]);
                packages.Add(pair[1]);
            }

            StringBuilder text = new StringBuilder("");
            foreach (string line in File.ReadAllLines("computers.in"))
            {
                string[] installed = line.Split(' ');
                foreach (string package in packages)
                    if (!installed.Contains(package))
                        text.Append(package + " ");
                text.Append("\n");
            }
            File.WriteAllText("task3.out", text.ToString());
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
    }
}
