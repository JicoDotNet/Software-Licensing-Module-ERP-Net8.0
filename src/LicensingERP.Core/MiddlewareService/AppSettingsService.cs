using Microsoft.Extensions.Configuration;

public class AppSettingsService : IAppSettingsService
{
    private readonly IConfiguration _configuration;

    public AppSettingsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetSetting(string key)
    {
        var value = _configuration[key];

        if (string.IsNullOrEmpty(value))
        {
            var sections = key.Split('.');

            if (sections.Length > 1)
            {
                var section = _configuration.GetSection(sections[0]);
                value = section[sections[1]];
            }
        }

        return value;
    }
}

public interface IAppSettingsService 
{
    string GetSetting(string key);
}

