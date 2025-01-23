using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class CloudExcelSheet
{
    [Key] public int Id { get; set; }
    public required string SheetId { get; set; }
    public required string SheetName { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    public bool Hidden { get; set; }
    public string? SheetData { get; set; }
}