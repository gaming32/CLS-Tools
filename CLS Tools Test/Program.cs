﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLS_Tools;
using System.IO;

namespace CLS_Tools_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Serialization.Load<Person>(Directory.GetCurrentDirectory() + @"\" + "unknown" + ".person.bin"));
            Console.WriteLine(Serialization.Load<Person>(Directory.GetCurrentDirectory() + @"\" + "Sarah Jones" + ".person.bin"));

            // Call the constructor that has no parameters.
            var person1 = new Person();
            Serialization.Save(person1, Directory.GetCurrentDirectory() + @"\" + person1.Name + ".person.bin");
            Console.WriteLine(person1.Name);

            // Call the constructor that has one parameter.
            var person2 = new Person("Sarah Jones");
            Serialization.Save(person2, Directory.GetCurrentDirectory() + @"\" + person2.Name + ".person.bin");
            Console.WriteLine(person2.Name);
            // Get the string representation of the person2 instance.
            Console.WriteLine(person2);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    [Serializable]
    public class Person
    {
        // Constructor that takes no arguments:
        public Person()
        {
            Name = "unknown";
        }

        // Constructor that takes one argument:
        public Person(string name)
        {
            Name = name;
        }

        // Auto-implemented readonly property:
        public string Name { get; }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return Name;
        }
    }
}