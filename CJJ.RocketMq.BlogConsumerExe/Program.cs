using CJJ.RocketMq.Consumer;
using CJJ.RocketMq.Models;
using System;

namespace CJJ.RocketMq.BlogConsumerExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string userCommand = string.Empty;

            // 启动消费端
            RocketConsumer consumer = new RocketConsumer(6, "Go_MicroShop_User_ShopMessage");
            consumer.OnConsume = msg => DoHandle(msg);
            consumer.Start();

            while (userCommand != "exit")
            {
                if (string.IsNullOrEmpty(userCommand) == false)
                    Console.WriteLine("     非退出指令,自动忽略...");
                userCommand = Console.ReadLine();
            }
        }

        private static bool DoHandle(ConsumerMsg msg)
        {
            Console.WriteLine($"{msg.Message}");
            return true;
        }
    }
}
