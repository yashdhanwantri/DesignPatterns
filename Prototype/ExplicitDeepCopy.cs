using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    interface IPrototype<T>
    {
        public T DeepCopy();
    }

    class PersonPrototype: IPrototype<PersonPrototype>
    {
        public string[] Names;
        public AddressPrototype Address;
        public PersonPrototype(string[] names, AddressPrototype address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {String.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public PersonPrototype DeepCopy()
        {
            return new PersonPrototype(Names,Address); 
        }
    }

    class AddressPrototype: IPrototype<AddressPrototype>
    {
        public string HouseNumber;
        public string City;

        public AddressPrototype(string houseNumber, string city)
        {
            HouseNumber = houseNumber;
            City = city;
        }

        public override string ToString()
        {
            return $"{nameof(HouseNumber)}: {HouseNumber}, {nameof(City)}: {City}";
        }

        public AddressPrototype DeepCopy()
        {
            return new AddressPrototype(HouseNumber, City);
        }
    }
    class ExplicitDeepCopy
    {
        public static void Main(string[] args)
        {
            var yash = new PersonPrototype(new[] { "Yash", "Dhanwantri" },
                new AddressPrototype("House123", "Minnesota"));

            var suzi = yash.DeepCopy();
            suzi.Names = new[] { "Suzi", "Nate" };
            suzi.Address = new AddressPrototype("House234", "Luxembourg");
            Console.WriteLine(suzi);
            Console.WriteLine(yash);
        }
    }
}
