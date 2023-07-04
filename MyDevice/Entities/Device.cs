namespace MyDevice.Entities;

public class Device
{
    public Guid Id { get; set; } = new Guid();
    public required string Name { get; set; }
    public required string SerialNumber { get; set; }
    public string? Ip { get; set; }
    public DateTime Date { get; set; }
    public DateTime Tomorrow { get; set; }


}
