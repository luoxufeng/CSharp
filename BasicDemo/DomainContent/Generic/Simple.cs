using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainContent.Generic
{
    /// <summary>
    /// 泛型类，实现泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class Simple<T>:IMyIfc<T>
    {
        public T ReturnIt(T intValue)
        {
            return intValue;
        }
    }

    internal delegate void MyDelegate<T>(T value);//泛型委托

    public class Simple
    {
        public static void PrintString(string s)
        {
            Console.WriteLine(s);
        }

        public static void PrintUpperStr(string s)
        {
            Console.WriteLine(s.ToUpper());
        }
    }
}
