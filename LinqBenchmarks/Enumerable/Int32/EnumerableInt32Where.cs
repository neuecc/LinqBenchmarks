﻿namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32Where : EnumerableInt32BenchmarkBase
    {
        [BenchmarkCategory("Enumerable", "Int32")]
        [Benchmark(Baseline = true)]
        public int Linq()
        {
            var sum = 0;
            foreach (var item in source.Where(item => item.IsEven()))
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var items = LinqAfExtensions
                .Where(source, item => item.IsEven());
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
                .Where(item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var predicate = new Int32IsEven();
            var items = source
                .ToStructEnumerable()
                .Where(ref predicate, x => x);
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq()
        {
            var items = source.AsValueEnumerable()
                .Where(item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int Hyperlinq_ValueDelegate()
        {
            var items = source.AsValueEnumerable()
                .Where<Int32IsEven>();
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
    public partial class EnumerableInt32Where : EnumerableInt32BenchmarkBase
    {
        [Benchmark]
        public int ZLinq()
        {
            var items = source.AsValueEnumerable()
                .Where(item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}
