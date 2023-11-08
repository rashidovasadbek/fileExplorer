using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Broker;

public interface IFileBroker
{
    StorageFile GetByPath(string filePath);
}