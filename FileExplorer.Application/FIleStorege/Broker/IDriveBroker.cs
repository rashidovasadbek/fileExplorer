using FileExplorer.Applicatoin.FIleStorege.Models;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Broker;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}
