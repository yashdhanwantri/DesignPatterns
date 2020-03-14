using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Prototype
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXMLSerializer<T>(this T self)
        {
            using(var stream = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(stream, self);
                stream.Position = 0;
                return (T)s.Deserialize(stream);
            }
        }
    }

    //For Binary Serialization, Class should have Serializable attribute
    [Serializable]
    public class Person1
    {
        public string[] Names;
        public Address1 Address;

        //When using XML Serialization, empty constructor is required, no [Serializable] attribute is required.
        public Person1()
        {

        }
        public Person1(string[] names, Address1 address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {String.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

    }

    
    [Serializable]
    public class Address1
    {
        public string HouseNumber;
        public string City;

        public Address1()
        {

        }
        public Address1(string houseNumber, string city)
        {
            HouseNumber = houseNumber;
            City = city;
        }

        public override string ToString()
        {
            return $"{nameof(HouseNumber)}: {HouseNumber}, {nameof(City)}: {City}";
        }
    }
    class CopyThroughSerialization
    {
        static void Main(string[] args)
        {
            var yash = new Person1(new[] { "Yash", "Dhanwantri" },
                new Address1("House123", "Minnesota"));

            var suzi = yash.DeepCopy();

            suzi.Names = new[] { "Suzi", "Oliver" };
            suzi.Address = new Address1("HouseSuzi", "Suzi Town");
            Console.WriteLine("Performing Deep copy using BinarySerializer");
            Console.WriteLine(yash);
            Console.WriteLine(suzi);

            var mike = yash.DeepCopyXMLSerializer();
            mike.Names[0] = "Mike";
            mike.Names[1] = "Taylor";
            mike.Address.HouseNumber = "Dungeon95";
            mike.Address.City = "Ghost Town";
           
            Console.WriteLine("Performing Deep copy using XMLSerializer");
            Console.WriteLine(yash);
            Console.WriteLine(mike);


        }
    }
}
