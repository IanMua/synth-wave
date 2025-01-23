using Microsoft.EntityFrameworkCore;
using SynthWave.Models.Entities;

namespace SynthWave.Data.Repositories.Impl;

public class AppRepository : IAppRepository
{
    private readonly SynthWaveDbContext _context;

    public AppRepository(SynthWaveDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateApp(App app)
    {
        _context.Apps.Add(app);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> RemoveApp(App app)
    {
        _context.Remove(app);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> BatchRemoveApp(List<App> apps)
    {
        apps.ForEach(x => _context.Remove(x));
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateApp(App app)
    {
        _context.Apps.Update(app);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<App>> GetAll()
    {
        return await _context.Apps.AsNoTracking().ToListAsync();
    }

    public Task<App?> GetAppById(string appId)
    {
        return _context.Apps.AsNoTracking().FirstOrDefaultAsync(x => x.AppId == appId);
    }
}