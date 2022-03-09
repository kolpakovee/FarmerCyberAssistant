using System.Text.Json;
using System.IO;

namespace App.Models
{
    public static class StaticSettings
    {
        public static readonly string ConfigFilePath = "config.json";
        public static readonly string AccountDataPath = "AccountData.json";

        public static ConfigVariables ConfigVariables { get; private set; } = new();
    }

    public class ConfigVariables
    {
        public string ServerUrl { get; init; } = "farming-assistant.eastus.cloudapp.azure.com";
        public int ServerPort { get; init; } = 80;
        public int SendingTimeout { get; init; } = 5000;
        public int ReceivingTimeout { get; init; } = 5000;
        public string DefaultToken { get; init; } = "0000000000000000000000000000000000000000000000000000000000000000";
        public int FieldListLimitSize { get; init; } = 100;

        public static ConfigVariables LoadFromFile() =>
            JsonSerializer.Deserialize<ConfigVariables>(File.ReadAllText(StaticSettings.ConfigFilePath));
    }
}
