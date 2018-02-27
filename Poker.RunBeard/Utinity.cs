using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
namespace Poker.RunBeard
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class Utinity
    {
        public static int[] BuildIntArray(int start, int end)
        {
            int[] array = new int[end - start + 1];
            for (var i = start; i <= end; i++)
            {
                array[i-start] = i;
            }
            return array;
        }

        public static IEnumerable<T> RandomSort<T>(this IEnumerable<T> array)
        {
            return (from item in array
                    orderby Guid.NewGuid().ToString()
                    select item).ToArray();
        }
    }
}
