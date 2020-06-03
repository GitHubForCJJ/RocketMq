using CJJ.RocketMq.Models;
using System;

namespace CJJ.RocketMq.ProducerMq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BlogMsg blogMsg = new BlogMsg { Blogid = "111222333", Type = 1 };
            BlogProducerMq blogProducerMq = new BlogProducerMq(blogMsg);
            Console.ReadKey();
        }
    }
}
