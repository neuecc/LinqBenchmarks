﻿using System.Collections.Immutable;

namespace LinqBenchmarks;

public partial class ImmutableArrayInt32BenchmarkBase : BenchmarkBase
{
    protected ImmutableArray<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Count, Seed).ToImmutableArray();
    }
}