﻿namespace LinqBenchmarks.Array.ValueType
{
    public partial class ArrayValueTypeSelectSum : ValueTypeArrayBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int ForeachLoop()
        {
            var sum = 0;
            foreach (var item in source)
            {
                sum += item.Value0;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
            => System.Linq.Enumerable.Sum(source, item => item.Value0);

        [Benchmark]
        public int LinqFaster()
            => source.SumF(item => item.Value0);

        [Benchmark]
        public int LinqFasterer()
            => EnumerableF.SumF(source, item => item.Value0);

        [Benchmark]
        public int LinqAF()
            => global::LinqAF.ArrayExtensionMethods.Sum(source, item => item.Value0);

        [Benchmark]
        public int StructLinq()
            => source
                .ToRefStructEnumerable()
                .Sum((in FatValueType item) => item.Value0);

        [Benchmark]
        public int StructLinq_ValueDelegate()
        {
            var selector = new Value0Selector();
            return source
                .ToRefStructEnumerable()
                .Sum(ref selector, x => x, x => x);
        }

        [Benchmark]
        public int Hyperlinq()
            => source.AsValueEnumerable()
                .Select(item => item.Value0)
                .Sum();

        [Benchmark]
        public int Hyperlinq_ValueDelegate()
            => source.AsValueEnumerable()
                .Select<int, Value0Selector>()
                .Sum();

        [Benchmark]
        public int Faslinq()
            => FaslinqExtensions.Select(
                    source,
                    item => item.Value0 * 3)
                .Sum();
    }
}
namespace LinqBenchmarks.Array.ValueType
{
    using ZLinq;
    public partial class ArrayValueTypeSelectSum : ValueTypeArrayBenchmarkBase
    {

        [Benchmark]
        public int ZLinq()
            => source.AsValueEnumerable()
                .Select(item => item.Value0)
                .Sum();
    }
}