﻿// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32Select : EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
                sum += item * 3;
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var items = source
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var items = LinqAfExtensions
                .Select(source, item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq()
        {
            var items = source
                .ToStructEnumerable()
                .Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var selector = new TripleOfInt32();
            var items = source
                .ToStructEnumerable()
                .Select(ref selector, x => x, x => x);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var items = source.AsValueEnumerable().Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_ValueDelegate()
        {
            var items = source.AsValueEnumerable().Select<int, TripleOfInt32>();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}

namespace LinqBenchmarks.Enumerable.Int32
{
    using ZLinq;
    public partial class EnumerableInt32Select : EnumerableInt32BenchmarkBase
    {
        [Benchmark]
        public int ZLinq()
        {
            var items = source.AsValueEnumerable().Select(item => item * 3);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

    }
}