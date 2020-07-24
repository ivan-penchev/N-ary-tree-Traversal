using System;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(
             1,
             new Node(
                 2,
                 new Node(3),
                 new Node(4)),
             new Node(
                 5,
                 new Node(6),
                 new Node(7)));

            var n = root;
            while (n != null)
            {
                Console.WriteLine(n != null ? n.Data.ToString() : "null");
                n = n.Next();
            }
           
            n = root;
            Console.WriteLine($"Node Data Should be 1, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be 2, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be 3, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be 4, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be 5, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be 6, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be 7, it is: {n.Data}");
            n = n.Next();
            Console.WriteLine($"Node Data Should be null, it is null: {n == null}");
        }

    }
}
