using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Controller;
[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IFileProcessingService _fileProcessingService;

    public FilesController(IWebHostEnvironment hostEnvironment, IFileProcessingService fileProcessingService)
    {
        _hostEnvironment = hostEnvironment;
        _fileProcessingService = fileProcessingService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetFileSummaryAsync()
    {
        var result = await _fileProcessingService.GetFilterDataModelAsync(_hostEnvironment.WebRootPath);
        return Ok(result);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetFilesAsync([FromBody] StorageFileFilterModel storageFileFilterModel)
    {
        var files = await _fileProcessingService.GetByFilterAsync(storageFileFilterModel);

        return files.Any() ? Ok(files) : NotFound(files);
    }
 }