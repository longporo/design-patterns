using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace reflection_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Get inner data of an object by Reflection
        /// </summary>
        public static void Reflection()
        {
            Type type = typeof(Program);
            FieldInfo[] fields = type.GetFields();
            foreach (var field in fields)
            {
                string name = field.Name;
                object value = field.GetValue(null);
                Console.WriteLine($"name: {name}, value: {value}");
            }
        }
        
        /// <summary>
        /// Deeply clone an object by Serialisation
        /// </summary>
        public static T Serialisation<T>(T obj)
        {
            using var ms = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            return (T) formatter.Deserialize(ms);
        }
    }
}