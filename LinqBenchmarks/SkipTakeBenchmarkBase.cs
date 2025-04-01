namespace LinqBenchmarks;

public partial class SkipTakeBenchmarkBase: BenchmarkBase
{
    [Params(1_000)]
    public int Skip { get; set; }
}