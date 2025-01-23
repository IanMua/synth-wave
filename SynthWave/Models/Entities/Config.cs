using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class Config
{
    [Key] public int Id { get; set; }
    public required string AppId { get; set; }
}