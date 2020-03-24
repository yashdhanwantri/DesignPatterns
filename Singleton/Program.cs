using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase: IDatabase
    {
        private Dictionary<string, int> capitals;
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(()=> new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
        private SingletonDatabase()
        {
            Console.WriteLine("Initializing database");
            capitals = File.ReadAllLines("Cities.txt")
                .Batch(2)
                .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1))
                );
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Delhi";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}
