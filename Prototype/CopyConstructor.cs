using System;

namespace Prototype
{
    //Demonstrating the use of Copy Constructor.
    /// <summary>
    /// ICloneable is bad, it creates shallow copy and moreover, we have to implement the clone() method which returns us the cloned object.
    /// Demonstrating copy constructor
    /// </summary>
    class Person
    {
        public string[] Names;
        public Address Address;
        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {String.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    class Address
    {
        public string HouseNumber;
        public string City;

        public Address(string houseNumber, string city)
        {
            HouseNumber = houseNumber;
            City = city;
        }

        public Address(Address other)
        {
            HouseNumber = other.HouseNumber;
            City = other.City;
        }
        public override string ToString()
        {
            return $"{nameof(HouseNumber)}: {HouseNumber}, {nameof(City)}: {City}";
        }
    }
    class CopyConstructor
    {
        static void Main(string[] args)
        {
            var yash = new Person(new[] { "Yash", "Dhanwantri" }, 
                new Address("House123", "Minnesota"));

            var suzi = new Person(yash);
            suzi.Address.HouseNumber = "House945";
            suzi.Names = new[] { "Suzi", "Wolker" };
            Console.WriteLine(yash);
            Console.WriteLine(suzi);
            Console.WriteLine("Verifying cloning");
            Console.WriteLine(yash);
        }
    }
}
