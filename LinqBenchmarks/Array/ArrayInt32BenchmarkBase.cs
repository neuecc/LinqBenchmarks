namespace LinqBenchmarks;

public partial class ArrayInt32BenchmarkBase : BenchmarkBase
{
    protected int[] source;

    protected override void Setup()
    {
        base.Setup(); 
        source = Utils.GetRandomValues(Count, Seed);
    }
}