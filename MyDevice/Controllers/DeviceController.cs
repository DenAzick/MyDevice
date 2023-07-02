using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDevice.Managers;
using MyDevice.Models;

namespace MyDevice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly DeviceManager _manager;

    public DeviceController(DeviceManager manager)
    {
        _manager = manager;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateDevice([FromBody] CreateModelDto model)
    {
        if (ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var device = await _manager.CreateDevice(model);

        return Ok(device);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetDevice(Guid id)
    {
        var device = await _manager.GetDevice(id);

        if (device == null) { return NotFound(); }

        return Ok(device);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(Guid id)
    {
        await _manager.DeleteDevice(id);
        return NoContent();
    }
}
