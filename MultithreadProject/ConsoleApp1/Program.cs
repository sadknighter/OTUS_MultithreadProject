// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
var attempts = new List<int>
{
    10, 100, 10000, 100000, 1000000, 10000000
};

foreach (var attempt in attempts)
{
    Console.WriteLine($"Attempt with number of ints in array: {attempt}");
    var numOfInts = attempt;
    Random rand = new Random();
    var numbers = Enumerable.Range(0, numOfInts)
        .Select(i => rand.Next(100))
        .ToArray();

    Stopwatch sw = Stopwatch.StartNew();
    var serialSum = ArrayHelper.SimpleFinderSum(numbers);
    sw.Stop();
    Console.WriteLine($"Method=SimpleSumFind\tSum: \t{serialSum:n0} \t Time: {sw.ElapsedTicks:n0}\t ticks");

    sw = Stopwatch.StartNew();
    var threadListSum = ArrayHelper.ThreadListFinderSum(numbers);
    sw.Stop();
    Console.WriteLine($"Method=ThreadSumFind\tSum: \t{threadListSum:n0} \t Time: {sw.ElapsedTicks:n0}\t ticks");

    sw = Stopwatch.StartNew();
    var linqSum = ArrayHelper.LinqFinderSum(numbers);
    sw.Stop();
    Console.WriteLine($"Method=LinqSumFind\tSum: \t{threadListSum:n0} \t Time: {sw.ElapsedTicks:n0}\t ticks");

    sw = Stopwatch.StartNew();
    var parallelLinqSum = ArrayHelper.ParallelLinqFinderSum(numbers);
    sw.Stop();
    Console.WriteLine($"Method=ParallelLinq\tSum: \t{threadListSum:n0} \t Time: {sw.ElapsedTicks:n0}\t ticks");

    Console.WriteLine("End of Attempt");
    Console.WriteLine("");
}

