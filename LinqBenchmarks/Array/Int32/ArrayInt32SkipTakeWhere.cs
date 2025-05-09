﻿namespace LinqBenchmarks.Array.Int32
{
    public partial class ArrayInt32SkipTakeWhere : ArrayInt32SkipTakeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public int ForLoop()
        {
            var sum = 0;
            var end = Skip + Count;
            for (var index = Skip; index < end; index++)
            {
                var item = source[index];
                if (item.IsEven())
                    sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int Linq()
        {
            var items = source.Skip(Skip).Take(Count).Where(item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFaster()
        {
            var items = source.SkipF(Skip).TakeF(Count).WhereF(item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqFasterer()
        {
            var items = EnumerableF.WhereF(EnumerableF.TakeF(EnumerableF.SkipF(source, Skip), Count), item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }

        [Benchmark]
        public int LinqAF()
        {
            var items = global::LinqAF.ArrayExtensionMethods.Skip(source, Skip).Take(Count).Where(item => item.IsEven());
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
                .Skip(Skip)
                .Take(Count)
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
                .Skip(Skip, x => x)
                .Take(Count, x => x)
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
                .Skip(Skip)
                .Take(Count)
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
                .Skip(Skip)
                .Take(Count)
                .Where<Int32IsEven>();
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}

namespace LinqBenchmarks.Array.Int32
{
    using ZLinq;

    public partial class ArrayInt32SkipTakeWhere : ArrayInt32SkipTakeBenchmarkBase
    {
        [Benchmark]
        public int ZLinq()
        {
            var items = source.AsValueEnumerable()
                .Skip(Skip)
                .Take(Count)
                .Where(item => item.IsEven());
            var sum = 0;
            foreach (var item in items)
                sum += item;
            return sum;
        }
    }
}