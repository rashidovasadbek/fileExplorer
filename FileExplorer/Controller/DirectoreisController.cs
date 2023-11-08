using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Models;
using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Applicatoin.FIleStorege.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Controller;

[ApiController]
[Route("api/[controller]")]
public class DirectoreisController : ControllerBase
{
    private readonly IDirectoryService _directoryService;
    private readonly IDirectoryProcessingService _directoryProcessingService;
    private readonly IMapper _mapper;

    public DirectoreisController(IDirectoryService directoryService, IDirectoryProcessingService directoryProcessingService, IMapper mapper)
    {
        _directoryService = directoryService;
        _directoryProcessingService = directoryProcessingService;
        _mapper = mapper;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync(
        [FromQuery] StorageDirectoryEntryFilterModel storageDirectoryEntryFilterModel,
        [FromServices] IWebHostEnvironment webHostEnvironment)
    {
        var data = await _directoryProcessingService.GetEntriesAsync(webHostEnvironment.WebRootPath,
            storageDirectoryEntryFilterModel);
        return data.Any() ? Ok(data) : NoContent();
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetDirectoryEntriesbyPath(
        [FromRoute] string directoryPath,
        [FromQuery] StorageDirectoryEntryFilterModel storageDirectoryEntryFilterModel)
    {
        var data = await _directoryProcessingService.GetEntriesAsync(directoryPath, storageDirectoryEntryFilterModel);
        return data.Any() ? Ok(data) : NoContent();
    }
}