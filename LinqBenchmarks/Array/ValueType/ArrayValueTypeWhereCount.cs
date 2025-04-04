﻿namespace LinqBenchmarks.Array.ValueType
{
    public partial class ArrayValueTypeWhereCount : ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var count = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
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
            => System.Linq.Enumerable.Count(source, item => item.IsEven());

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
                .ToRefStructEnumerable()
                .Where((in FatValueType item) => item.IsEven())
                .Count();

        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var predicate = new FatValueTypeIsEven();
            return source
                .ToRefStructEnumerable()
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
                .Where<FatValueTypeIsEven>()
                .Count();

        [Benchmark]
        public int Faslinq()
            => FaslinqExtensions
                .Where(source, item => item.IsEven())
                .Count();
    }
}
namespace LinqBenchmarks.Array.ValueType
{
    using ZLinq;
    public partial class ArrayValueTypeWhereCount : ValueTypeArrayBenchmarkBase
    {
        [Benchmark]
        public int ZLinq()
            => source.AsValueEnumerable()
                .Where(item => item.IsEven())
                .Count();

    }
}