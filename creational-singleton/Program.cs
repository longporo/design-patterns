using System;
using System.Collections.Generic;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // creational-singleton: Ensure a class only has one instance and provide a global access to it.
            Console.WriteLine("Hello World!");
        }
    }

    // simple example(not thread safe)
    class Singleton
    {
        // private the constructure
        private Singleton()
        {
        }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    // elegant example(thread safe)
    public class ThreadSafeSingleton
    {
        private static readonly
            ThreadSafeSingleton _instance = new ThreadSafeSingleton();

        private ThreadSafeSingleton()
        {
        }

        public static ThreadSafeSingleton GetInstance => _instance;
    }

    // lazy initialisation
    public class LazyBlogAuthor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public Lazy<IList<Object>> Blogs =>
            new Lazy<IList<Object>>(() =>
                GetBlogDetailsForAuthor(this.Id));

        private IList<Object> GetBlogDetailsForAuthor(int Id)
        {
            // Code here to retrieve all blog
            // details for an author
            return new List<Object>();
        }
    }

    // Lazy Thread Safe creational-singleton
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> _instance =
                new Lazy<LazySingleton>(() => new
                    LazySingleton());

        public static LazySingleton GetInstance
        {
            get { return _instance.Value; }
        }

        private LazySingleton()
        {
        }
    }
}