using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class ConfigType
{
    [Key] public int Id { get; set; }
    public int ConfigId { get; set; }
    public int TypeId { get; set; }
}