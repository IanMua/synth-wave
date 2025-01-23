using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class App
{
    [Key] public required string AppId { get; set; }

    public required string AppSecret { get; set; }
}