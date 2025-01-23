using SynthWave.Models.Entities;

namespace SynthWave.Data.Repositories;

public interface IAppRepository
{
    /// <summary>
    /// 创建应用
    /// </summary>
    Task<int> CreateApp(App app);

    /// <summary>
    /// 删除应用
    /// </summary>
    Task<int> RemoveApp(App app);

    /// <summary>
    /// 批量删除应用
    /// </summary>
    Task<int> BatchRemoveApp(List<App> apps);

    /// <summary>
    /// 更新应用
    /// </summary>
    Task<int> UpdateApp(App app);

    /// <summary>
    /// 获取所有应用
    /// </summary>
    Task<List<App>> GetAll();

    /// <summary>
    /// 根据应用Id获取应用
    /// </summary>
    Task<App?> GetAppById(string appId);
}