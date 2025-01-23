using System.Reflection;

namespace SynthWave.Configurations;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        RegisterByConvention(services, "Service");
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        RegisterByConvention(services, "Repository");
    }

    private static void RegisterByConvention(IServiceCollection services, string suffix)
    {
        // 获取当前程序集中的所有类型
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            // 排除抽象类或接口本身
            if (!type.IsClass || type.IsAbstract) continue;

            // 找到实现的接口
            Type[] interfaces = type.GetInterfaces();

            foreach (Type @interface in interfaces)
            {
                // 按接口名称的后缀进行约定注册
                if (@interface.Name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    services.AddScoped(@interface, type);
                }
            }
        }
    }
}