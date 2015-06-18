using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingTests
{
    public class ListGenerator
    {
        public static List<int> Generate(int quantity)
        {
            return RandomSequence(new Random()).Take(quantity).ToList();
        }

        static IEnumerable<int> RandomSequence(Random random)
        {
            while (true)
            {
                yield return random.Next();
            }
        }
    }
}
