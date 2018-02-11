using System;

namespace ReverseApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            var bytes = new byte[10];

            random.NextBytes(bytes);
            Reverse(bytes);
        }

        public static void Reverse(byte[] bytes)
        {
            Console.WriteLine("Test bytes___________    Reversed_____________");

            foreach (var b in bytes)
            {
                var int32 = (int) b;
                var result = 0;

                for (var i = 0; i < 8; i++, int32 >>= 1, result <<= 1)
                {
                    result |= int32 & 1;
                }
                result >>= 1;

                Console.WriteLine("{0, 10} {1, 10} -> {2, 10} {3, 10}",
                    b, Convert.ToString(b, 2), result, Convert.ToString(result, 2)
                );
            }
        }
    }
}