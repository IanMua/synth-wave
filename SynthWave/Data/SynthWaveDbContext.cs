using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SynthWave.Models.Entities;
using Type = SynthWave.Models.Entities.Type;

namespace SynthWave.Data;

public class SynthWaveDbContext : DbContext
{
    public DbSet<App> Apps { get; set; }
    public DbSet<AppCloudExcel> AppCloudExcels { get; set; }
    public DbSet<CloudExcel> CloudExcels { get; set; }
    public DbSet<CloudExcelSheet> CloudExcelSheets { get; set; }
    public DbSet<Config> Configs { get; set; }
    public DbSet<ConfigType> ConfigTypes { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<TypeField> TypeFields { get; set; }

    private readonly IConfiguration _configuration;

    public SynthWaveDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // 将实体类名称映射为表名
            entityType.SetTableName(ToSnakeCase(entityType.ClrType.Name));

            // 遍历每个属性，将属性名映射为列名
            foreach (var property in entityType.GetProperties())
            {
                property.SetColumnName(ToSnakeCase(property.Name));
            }

            // 遍历每个导航属性，将外键名也映射为蛇形
            foreach (var key in entityType.GetKeys())
            {
                key.SetName(ToSnakeCase(key.GetName()));
            }

            foreach (var fk in entityType.GetForeignKeys())
            {
                fk.SetConstraintName(ToSnakeCase(fk.GetConstraintName()));
            }

            foreach (var index in entityType.GetIndexes())
            {
                index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()));
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_configuration.GetConnectionString("DefaultConnection")!);
    }

    // 辅助方法：将 PascalCase 转为 snake_case
    private string ToSnakeCase(string? input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        var regex = new Regex("([a-z0-9])([A-Z])");
        return regex.Replace(input, "$1_$2").ToLower();
    }
}