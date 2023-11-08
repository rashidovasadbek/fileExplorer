using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Applicatoin.FIleStorege.Services;
using FileExplorer.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Controller;

[ApiController]
[Route("api/controller")]
public class DriveController : ControllerBase
{
    private readonly IMapper _mapper;

    public DriveController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    public async ValueTask<IActionResult> GetAsync([FromServices] IDriverService driverService)
    {
        var data = await driverService.GetAsync();
        var result = _mapper.Map<IEnumerable<StorageDriveDto>>(data);
        return result.Any() ? Ok(result) : NoContent();
    }
}