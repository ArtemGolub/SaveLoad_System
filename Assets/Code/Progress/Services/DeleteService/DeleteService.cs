using System;
using System.IO;
using UnityEngine;

namespace Code.Progress.Services.DeleteService
{
    public sealed class DeleteService : IDeleteService
    {
        public bool TryDelete(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Debug.LogError("DeleteService: File path is empty.");
                return false;
            }
            
            try
            {
                if (!File.Exists(filePath))
                    return true;

                File.Delete(filePath);

                Debug.Log($"Delete completed successfully. Path: {filePath}");
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"Failed to delete file: {exception.Message}");
                return false;
            }
        }
    }
}