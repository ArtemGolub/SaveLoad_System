using Newtonsoft.Json;

namespace Code.Progress.Data
{
    public class ProgressData 
    {
        [JsonProperty("player")] public PlayerData PlayerData = new();
        [JsonProperty("settings")] public SettingsData SettingsData = new();
        [JsonProperty("vnState")] public VNState VnState = new();
        [JsonProperty("gameFlags")] public GameFlags GameFlags = new();
    }
}
