namespace LinqBenchmarks;

public partial class RangeBenchmarkBase : BenchmarkBase
{
    [Params(0)]
    public int Start { get; set; }
}