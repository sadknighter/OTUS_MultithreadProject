using System.Numerics;

namespace ConsoleApp1
{
    public static class ArrayHelper
    {

        public static long SimpleFinderSum(int[] digits)
        {
            var sum = 0;
            foreach (var item in digits)
            {
                sum += item;
            }

            return sum;
        }

        public static long ThreadListFinderSum(int[] digits) 
        {
            int sumPartsCount = 5;
            var digitsLength = digits.Length;
            var peacesArrayCount = digitsLength / sumPartsCount;
            long[] partialSums = new long[sumPartsCount];

            Parallel.For(0, sumPartsCount, (counter) =>
            {
                int sum = 0;
                for (int i = counter * peacesArrayCount; i < (counter + 1) * peacesArrayCount; i++)
                {
                    if (i == digitsLength + 1)
                    {
                        break;
                    }

                    sum += digits[i];
                }

                partialSums[counter] = sum;
            });

            return partialSums.Sum();
        }

        public static long LinqFinderSum(int[] digits)
        {
            return digits.Sum();
        }

        public static long ParallelLinqFinderSum(int[] digits)
        {
            return digits.AsParallel().Sum();
        }

    }
}
