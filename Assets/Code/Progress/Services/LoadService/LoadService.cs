using System;
using System.IO;
using Code.Utility.Serialization;
using UnityEngine;

namespace Code.Progress.Services.LoadService
{
    public sealed class LoadService : ILoadService
    {
        public bool TryLoad<T>(string filePath, out T data)
        {
            data = default;
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Debug.LogError("LoadService: File path is empty.");
                return false;
            }
            
            try
            {
                if (!File.Exists(filePath))
                {
                    Debug.LogWarning($"LoadService: Save file not found. Path: {filePath}");
                    return false;
                }

                string json = File.ReadAllText(filePath);
                data = json.FromJson<T>();

                Debug.Log($"LoadService: Load completed successfully. Load path: {filePath}");
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"LoadService: Failed to load progress: {exception.Message}");
                data = default;
                return false;
            }
        }
    }
}