﻿namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32WhereCount : EnumerableInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForeachLoop()
        {
            var count = 0;
            foreach (var item in source)
            {
                if (item.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
        public int Linq()
            => source.Count(item => item.IsEven());

        [Benchmark]
        public int LinqAF()
            => LinqAfExtensions.Count(source, item => item.IsEven());

        [Benchmark]
        public int StructLinq()
            => source
                .ToStructEnumerable()
                .Where(item => item.IsEven())
                .Count();

        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var predicate = new Int32IsEven();
            return source
                .ToStructEnumerable()
                .Where(ref predicate, x => x)
                .Count(x => x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Count();

        [Benchmark]
        public int Hyperlinq_ValueDelegate()
            => source.AsValueEnumerable()
                .Where<Int32IsEven>()
                .Count();
    }
}

namespace LinqBenchmarks.Enumerable.Int32
{
    using ZLinq;
    public partial class EnumerableInt32WhereCount : EnumerableInt32BenchmarkBase
    {

        [Benchmark]
        public int ZLinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Count();
    }
}