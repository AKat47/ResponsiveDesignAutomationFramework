using System;
using System.Text;

namespace Automation
{
    public class Utilities
    {
        public static class RandomHelper
        {
            private static Random _random = new Random(Guid.NewGuid().GetHashCode());
            public static string GetString(int size)
            {
                StringBuilder builder = new StringBuilder();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                return builder.ToString();
            }
        }

    }
}