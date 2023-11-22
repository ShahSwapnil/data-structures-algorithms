using System;

namespace algorithms;

public abstract class BaseSorter<T> where T : IComparable<T>
{
    protected SortOrder SortOrder { get; set; }
    protected IAlgoLogger Logger { get; set; }

    private bool _enableLogger; 

    public BaseSorter(SortOrder sortOrder, IAlgoLogger logger, bool enableLogger = true)
    {
        this.SortOrder = sortOrder;
        this.Logger = logger;
        _enableLogger = enableLogger;
    }

    public  void Sort(T[]? input)
    {
        if (input is null)
            return;

        if (input.Length == 0)
            return;

        helper(input, 0, input.Length - 1);
    }

    protected abstract void helper(T[] input, int start, int end);

    protected void swap(T[] input, int indexA, int indexB)
    {
        T temp = input[indexA];
        input[indexA] = input[indexB];
        input[indexB] = temp;
    }

    protected void LogCurrentState(string description, T[] input, int start, int end)
    {
        if (!_enableLogger)
            return;

        Logger.Info("{0} - Start: {1} End: {2} Input Array: [{3}]",
            description,
            start,
            end,
            string.Join(", ",
                input.Select((integer, idx) => new { integer, idx })
                    .Where(x => start <= x.idx && x.idx <= end)
                    .Select(x => x.integer)
            )
        );
    }
}
