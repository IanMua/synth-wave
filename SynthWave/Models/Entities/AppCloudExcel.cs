using System.ComponentModel.DataAnnotations;

namespace SynthWave.Models.Entities;

public class AppCloudExcel
{
    [Key] public required int Id { get; set; }
    public required string AppId { get; set; }
    public required string CloudExcelToken { get; set; }
}