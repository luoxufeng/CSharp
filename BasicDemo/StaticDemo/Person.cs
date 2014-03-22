using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticDemo
{
    class Person
    {
        private static string name;

        public string GetName()
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "哈哈，我是来测试静态变量的哦";
            }
            return name;
        }
    }
}
