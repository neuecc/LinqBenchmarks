﻿namespace LinqBenchmarks.Enumerable.Int32
{
    public partial class EnumerableInt32Contains : EnumerableInt32BenchmarkBase
    {
        int value = int.MaxValue;

        [Benchmark(Baseline = true)]
        public bool ForeachLoop()
        {
            foreach (var item in source)
            {
                if (item == value)
                    return true;
            }
            return true;
        }

        [Benchmark]
        public bool Linq()
            => source.Contains(value);

        [Benchmark]
        public bool LinqAF()
            => LinqAfExtensions.Contains(source, value);

        [Benchmark]
        public bool StructLinq()
            => source
                .ToStructEnumerable()
                .Contains(value);

        [Benchmark]
        public bool StructLinq_ValueDelegate()
            => source
                .ToStructEnumerable()
                .Contains(value, x => x);

        [Benchmark]
        public bool Hyperlinq()
            => source
                .AsValueEnumerable()
                .Contains(value);
    }
}
namespace LinqBenchmarks.Enumerable.Int32
{
    using ZLinq;
    public partial class EnumerableInt32Contains : EnumerableInt32BenchmarkBase
    {
        [Benchmark]
        public bool ZLinq()
            => source
                .AsValueEnumerable()
                .Contains(value);
    }
}