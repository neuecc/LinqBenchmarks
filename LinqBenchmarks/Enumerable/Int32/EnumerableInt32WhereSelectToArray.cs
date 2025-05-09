﻿// ReSharper disable LoopCanBeConvertedToQuery
namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32WhereSelectToArray : EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int[] ForeachLoop()
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                if (item.IsEven())
                    list.Add(item * 3);
            }
            return list.ToArray();
        }

        [Benchmark]
        public int[] Linq()
            => source
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] LinqAF()
            => LinqAfExtensions
                .Where(source, item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] StructLinq()
            => source.ToStructEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] StructLinq_ValueDelegate()
        {
            var predicate = new Int32IsEven();
            var selector = new TripleOfInt32();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Select(ref selector, x => x, x => x)
                .ToArray(x => x);
        }

        [Benchmark]
        public int[] Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Select(item => item * 3)
                .ToArray();

        [Benchmark]
        public int[] Hyperlinq_ValueDelegate()
            => source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Select<int, TripleOfInt32>()
                .ToArray();
    }
}
namespace LinqBenchmarks.Enumerable.Int32
{
    using ZLinq;
    public partial class EnumerableInt32WhereSelectToArray : EnumerableInt32BenchmarkBase
    {
        [Benchmark]
        public int[] ZLinq()
         => source.AsValueEnumerable()
             .Where(item => item.IsEven())
             .Select(item => item * 3)
             .ToArray();
    }
}