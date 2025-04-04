﻿// ReSharper disable ForCanBeConvertedToForeach
// ReSharper disable LoopCanBeConvertedToQuery

namespace LinqBenchmarks.Array.Int32
{
    public partial class ArrayInt32Contains : ArrayInt32BenchmarkBase
    {
        int value = int.MaxValue;

        [Benchmark(Baseline = true)]
        public bool ForLoop()
        {
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                if (item == value)
                    return true;
            }
            return true;
        }

        [Benchmark]
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
            => source
                .Contains(value);

        [Benchmark]
        public bool LinqFaster()
            => source.ContainsF(value);

        [Benchmark]
        public bool LinqFaster_SIMD()
            => source.ContainsS(value);

        [Benchmark]
        public bool LinqFasterer()
            => EnumerableF.ContainsF(source, value);

        [Benchmark]
        public bool LinqAF()
            => global::LinqAF.ArrayExtensionMethods
                .Contains(source, value);

        [Benchmark]
        public bool StructLinq()
            => source
                .ToStructEnumerable()
                .Contains(value);

        [Benchmark]
        public bool StructLinq_ValueDelegate()
        {
            return source
                .ToStructEnumerable()
                .Contains(value, x => x);
        }

        [Benchmark]
        public bool Hyperlinq()
            => source
                .AsValueEnumerable()
                .Contains(value);

        [Benchmark]
        public bool Hyperlinq_SIMD()
            => source
                .AsValueEnumerable()
                .ContainsVector(value);

        [Benchmark]
        public bool Faslinq()
            => FaslinqExtensions.Any(source, i => i.Equals(value));
    }
}

namespace LinqBenchmarks.Array.Int32
{
    using ZLinq;

    public partial class ArrayInt32Contains : ArrayInt32BenchmarkBase
    {
        [Benchmark]
        public bool ZLinq()
            => source
                .AsValueEnumerable()
                .Contains(value);

    }
}