using System;
using System.IO;
using Code.Utility.Serialization;
using UnityEngine;

namespace Code.Progress.Services.SaveService
{
    public sealed class SaveService : ISaveService
    {
        public bool TrySave<T>(string filePath, T data)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Debug.LogError("SaveService: File path is empty.");
                return false;
            }

            if (data == null)
            {
                Debug.LogWarning($"SaveService: Cannot save null data of type {typeof(T).Name}.");
                return false;
            }
            
            try
            {
                SaveLoadData.EnsureSaveFolderExists();
                
                File.WriteAllText(filePath, data.ToJson());

                Debug.Log($"SaveService: Save completed successfully. Save path: {SaveLoadData.SaveFilePath}");
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"SaveService: Failed to save progress: {exception.Message}");
                return false;
            }
        }
    }
}