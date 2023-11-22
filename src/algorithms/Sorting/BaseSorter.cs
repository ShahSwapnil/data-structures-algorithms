namespace algorithms;

public abstract class BaseSorter
{
    protected SortOrder SortOrder { get; set; }
    protected IAlgoLogger Logger { get; set; }

    public BaseSorter(SortOrder sortOrder, IAlgoLogger logger)
    {
        this.SortOrder = sortOrder;
        this.Logger = logger;
    }

    public abstract void Sort(int[]? input);
}
