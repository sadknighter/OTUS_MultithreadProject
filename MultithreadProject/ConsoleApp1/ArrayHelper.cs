using System.Collections.Concurrent;

namespace ConsoleApp1
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] arr, int size)
        {
            return arr.Select((s, i) => arr.Skip(i * size).Take(size)).Where(a => a.Any());
        }
    }

    public static class ArrayHelper
    {

        public static long SimpleFinderSum(IEnumerable<int> digits)
        {
            var sum = 0;
            foreach (var item in digits)
            {
                sum += item;
            }

            return sum;
        }

        public static long TaskListFinderSum(int[] digits, int parts = 5)
        {
            var tasks = new List<Task>();
            var sums = new ConcurrentBag<long>();
            var arrays = digits.Split(parts);

            foreach (var array in arrays)
            {
                Task task = Task.Run(() =>
                {
                    sums.Add(SimpleFinderSum(array));
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            long sum = 0;

            foreach (long item in sums)
            {
                sum += item;
            }

            return sum;
        }

        public static long ParallelForFinderSum(int[] digits, int parts = 5) 
        {
            var sums = new ConcurrentBag<long>();
            var arrays = digits.Split(parts);


            Parallel.ForEach(arrays, (arrayPart) => sums.Add(SimpleFinderSum(arrayPart)));

            long sum = 0;

            foreach (long item in sums)
            {
                sum += item;
            }

            return sum;
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
