namespace MyDevice.Models;

public class CreateModelDto
{
    public required string Name { get; set; }
    public required string SerialNumber { get; set; }
    public string? Ip { get; set; }
    public DateTime Date { get; set; }
    public DateTime Tomorrow { get; set; }
}
