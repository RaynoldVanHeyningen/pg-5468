using System.IO;
using Newtonsoft.Json;
using Playground.Shared.Core.Utils;
using Playground.Shared.Models;

namespace Playground.Shared.Core.Managers;

public static class ConfigManager
{
    private static string _configFilePath = "config.json";
    private static GameConfig _config;

    public static void Initialize(string configFilePath = "config.json")
    {
        _configFilePath = configFilePath;

        if (File.Exists(_configFilePath)) LoadConfig();
        else
        {
            _config = new GameConfig();
            SaveConfig();
        }
        
        Logger.Log("ConfigManager initialized.");
    }

    public static GameConfig GetConfig()
    {
        return _config;
    }

    public static void SaveConfig()
    {
        var json = JsonConvert.SerializeObject(_config, Formatting.Indented);

        File.WriteAllText(_configFilePath, json);
        Logger.Log("Configuration saved.");
    }

    private static void LoadConfig()
    {
        var json = File.ReadAllText(_configFilePath);
        _config = JsonConvert.DeserializeObject<GameConfig>(json);
        
        Logger.Log("Configuration loaded.");
    }
}