using System;
using System.Threading;

namespace singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() => write());
            Thread thread1 = new Thread(() => write());
            thread.Start();
            thread1.Start();
        }

        static void write()
        {
            Singleton singleton = Singleton.GetInstance;
            singleton.write();
        }
    }

    sealed class Singleton
    {
        private static Singleton _Singleton = null;
        private static int _counter = 0;

        private static object sample = new object();
        private static Lazy<Singleton> instance = new Lazy<Singleton>(() =>
            new Singleton()
        );

        private Singleton()
        {
            _counter++;
        }


        public static Singleton GetInstance
        {
            //general way of doing 
            //get
            //{
            //    lock (sample)
            //    {
            //        if (_Singleton is null)
            //        {
            //            _Singleton = new Singleton();
            //            _counter++;
            //        }

            //        return _Singleton;
            //    }
            //}

            get
            {
                return instance.Value;
            }
        }

        public void write()
        {
            Console.WriteLine("I am calling from singleton object. Object Count {0}", _counter);
        }
    }
}
