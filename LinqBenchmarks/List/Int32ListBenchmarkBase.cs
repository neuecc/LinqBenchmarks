namespace LinqBenchmarks;

public partial class Int32ListBenchmarkBase : BenchmarkBase
{
    protected List<int> source;

    protected override void Setup()
    {
        base.Setup();
            
        source = Utils.GetRandomValues(Count, Seed).ToList();
    }
}