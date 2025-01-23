using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class Type
{
    [Key] public int Id { get; set; }
    public required string TypeName { get; set; }
    public string? Annotation { get; set; }
}