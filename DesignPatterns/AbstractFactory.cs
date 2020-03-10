using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Please consume Tea");
        }
    }
    internal class Coffee :IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Consume Coffee");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
    internal class TeaFactory: IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"{amount}ml Tea Preparing ");
            return new Tea();
        }
    }
    internal class CoffeeFactory: IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"{amount}ml Coffee Preparing");
            return new Coffee();
        }
    }
    class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee,Tea
        }
        private Dictionary<AvailableDrink,IHotDrinkFactory> factories = new Dictionary<AvailableDrink,IHotDrinkFactory>();
        public HotDrinkMachine()
        {
            foreach(AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("Factory." + Enum.GetName(typeof(AvailableDrink),drink) +"Factory"));
                factories.Add(drink, factory);
            }
        }
        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    class HotDrinkMachineVer2
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachineVer2()
        {
            foreach(var t in typeof(HotDrinkMachineVer2).Assembly.GetTypes())
            {
                if(typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("Factory", String.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }
        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available Drink");
            for(var index = 0; index<factories.Count;index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }
            while(true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i > 0
                    && i<factories.Count)
                {
                    Console.Write("Specify Amount: ");
                    s = Console.ReadLine();
                    if(s!=null 
                        && int.TryParse(s, out int amount)
                        && amount>0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }

                    Console.WriteLine("Incorrect Input, Try Again!");
                }
            }
        }
    }
    class AbstractFactory
    {
        static void Main(string[] args)
        {
            //var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 25);
            //drink.Consume();

            //var machine2 = new HotDrinkMachineVer2();
            //var drink2 = machine2.MakeDrink();
            //drink2.Consume();
            PersonFactory pf = new PersonFactory();
            Console.WriteLine(pf.CreatePerson("Yash"));
            Console.WriteLine(pf.CreatePerson("Rahul"));

        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
    
    public class PersonFactory
    {
        int index = -1;
        public Person CreatePerson(string Name)
        {
            index+= 1;
            return new Person() { Id = index, Name = Name };
        }
    }
}
