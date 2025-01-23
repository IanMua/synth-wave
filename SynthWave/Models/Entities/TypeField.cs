using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class TypeField
{
    [Key] public int Id { get; set; }
    public int TypeId { get; set; }
    public required string FieldName { get; set; }
    public required string FieldType { get; set; }
}