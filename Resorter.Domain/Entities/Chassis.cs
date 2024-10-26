using Resorter.Domain.Constants;

namespace Resorter.Domain.Entities;

public class Chassis
{
    public TransmissionEnum Transmission { get; set; }
    public DriveTypeEnum Drive { get; set; }
    public bool Abs { get; set; }
    public bool Ebd { get; set; }
    public bool Esp { get; set; }
}
