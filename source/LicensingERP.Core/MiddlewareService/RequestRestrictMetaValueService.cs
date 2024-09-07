using System.IO;
using LicensingERP.Logic.DTO.Class;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;


public interface IRequestRestrictMetaValueService
{
    RequestRestrictsMeta GetRestrictMetaValues();
}

public class RequestRestrictMetaValueService : IRequestRestrictMetaValueService
{
    private readonly IWebHostEnvironment _env;
    private RequestRestrictsMeta _restrictMetaValues;

    public RequestRestrictMetaValueService(IWebHostEnvironment env)
    {
        _env = env;
        LoadRestrictMetaValues();
    }

    private void LoadRestrictMetaValues()
    {
        var filePath = Path.Combine(_env.WebRootPath, "JsonFile", "restrictjson.Json");
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            _restrictMetaValues = JsonConvert.DeserializeObject<RequestRestrictsMeta>(json);
        }
        else
        {
            _restrictMetaValues = new RequestRestrictsMeta();
        }
    }

    public RequestRestrictsMeta GetRestrictMetaValues()
    {
        foreach(RequestRestrictMeta requestRestrictMeta in _restrictMetaValues)
            requestRestrictMeta.Name = requestRestrictMeta?.Name?.Trim().Replace(" ", "");
        return _restrictMetaValues;
    }
}