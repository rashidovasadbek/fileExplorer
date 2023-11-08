using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Services;

public interface IDriverService
{
    ValueTask<IList<StorageDrive>> GetAsync();
}