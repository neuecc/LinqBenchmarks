﻿namespace LinqBenchmarks.Array.Int32
{
    public partial class ArrayInt32WhereCount : ArrayInt32BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var count = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                if (item.IsEven())
                    count++;
            }
            return count;
        }

        [Benchmark]
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
        public int LinqFaster()
            => source.CountF(item => item.IsEven());

        [Benchmark]
        public int LinqFasterer()
            => EnumerableF.CountF(source, item => item.IsEven());

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Count(source, item => item.IsEven());

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

        [Benchmark]
        public int Faslinq()
            => FaslinqExtensions
                .Where(source, item => item.IsEven())
                .Count();
    }
}

namespace LinqBenchmarks.Array.Int32
{
    using ZLinq;
    public partial class ArrayInt32WhereCount : ArrayInt32BenchmarkBase
    {

        [Benchmark]
        public int ZLinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Count();
    }
}