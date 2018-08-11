using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;

            foreach (var item in sequence)
            {
                count += 1;
            }

            return count;
        }

        public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
            {
                action(element);
                yield return element;
            }
        }
    }
}
