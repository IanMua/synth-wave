using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class CloudExcel
{
    [Key] public required string Token { get; set; }
    public required string Name { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? ChangedTime { get; set; }
}