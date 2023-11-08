namespace FileExplorer.Applicatoin.Common.Filtering;

public class DynamicFilterPagination
{
    private readonly FilterPagination _paginationOptions;
    private readonly uint _dynamicPageSize;
    private  uint _dynamicPageSizeRemainder;

    public DynamicFilterPagination(FilterPagination paginationOptions, uint callsCount)
    {
        if (callsCount == 0) throw new ArgumentException("Calls count must be greater than zero", nameof(callsCount));

        _paginationOptions = paginationOptions;
        (_dynamicPageSize, _dynamicPageSizeRemainder) = _paginationOptions.PageSize < callsCount
            ? (_paginationOptions.PageSize, default)
            : (_paginationOptions.PageSize / callsCount, _paginationOptions.PageSize % callsCount);
    }

    public uint PageToken
    {
        get => _paginationOptions.PageToken;
        set => _paginationOptions.PageToken = value;
    }

    public uint PageSize
    {
        get
        {
            if (_paginationOptions.PageSize == default) return default;

            var currentDynemicPageSize = _dynamicPageSize;
            if (_dynamicPageSizeRemainder > 0)
            {
                currentDynemicPageSize++;
                _dynamicPageSizeRemainder--;
            }

            _paginationOptions.PageSize -= currentDynemicPageSize;

            return currentDynemicPageSize;
        }

        set => _paginationOptions.PageSize = value;
    }
}