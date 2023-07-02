using Microsoft.EntityFrameworkCore;
using MyDevice.Context;
using MyDevice.Entities;
using MyDevice.Models;

namespace MyDevice.Managers;

public class DeviceManager
{
    private readonly DeviceAppContext _appContext;

    public DeviceManager(DeviceAppContext appContext)
    {
        _appContext = appContext;
    }


    public async Task<Device> CreateDevice(CreateModelDto model)
    {
        if (await _appContext.Devices.AnyAsync(d => d.SerialNumber == model.SerialNumber))
        {
            throw new Exception("Device alredy exists");
        }

        var device = new Device()
        {
            Name = model.Name,
            SerialNumber = model.SerialNumber,
            Ip = model.Ip,
            Date = model.Date,
            Tomorrow = model.Tomorrow,

        };

        _appContext.Devices.Add(device);
        await _appContext.SaveChangesAsync();

        return device;
    }


    public async Task<Device?> GetDevice(Guid id)
    {
        return await _appContext.Devices.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task DeleteDevice(Guid id)
    {
        var device = await _appContext.Devices.FirstAsync(d => d.Id == id);

        if (device != null)
        {
            _appContext.Devices.Remove(device);
            await _appContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception($"Unable to delete device: {id}");
        }
    }
}
