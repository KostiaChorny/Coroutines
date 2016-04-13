using System;
using System.Collections.Generic;

namespace Coroutines
{
    class Program
    {
        static void Main(string[] args)
        {
            CoroutineManager cm = new CoroutineManager();

            cm.RegisterCoroutine(Cor1);
            cm.RegisterCoroutine(Cor3);

            cm.Start();
        }

        public static IEnumerable<object> Cor1()
        {
            while (true)
            {
                Console.WriteLine("Hello!");
                yield return new Coroutine(Cor2);
                yield return new WaitForSeconds(1000);
            }
        }

        public static IEnumerable<object> Cor2()
        {
            Console.WriteLine("Hello1!!!!!");
            yield return new WaitForSeconds(2000);
            Console.WriteLine("Hello2!!!!!");
            yield break;
        }

        public static IEnumerable<object> Cor3()
        {
            while (true)
            {
                Console.WriteLine("........");
                yield return new WaitForSeconds(500);
            }
        }
    }
}
