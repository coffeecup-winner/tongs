using System;

namespace Tongs
{
    public static class ConsoleOutputExtensions
    {
        public static T Print<T>(this T obj, string line)
        {
            Console.WriteLine(line);
            return obj;
        }

        public static T PrintDump<T>(this T obj)
            where T: IDumpable
        {
            Console.WriteLine(obj.GetDump());
            return obj;
        }
    }
}
