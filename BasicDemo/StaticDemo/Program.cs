using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = new Person().GetName();
            Console.WriteLine("哈哈，我的值是多少了?=="+name);

            Console.Write("我的值为:"+new Person().GetName());
            Console.Read();
        }
    }
}
