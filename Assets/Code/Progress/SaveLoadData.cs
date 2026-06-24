using System.IO;
using UnityEngine;

namespace Code.Progress
{
    public static class SaveLoadData
    {
        private const string FOLDER_NAME = "DefaultSaves";
        private const string FILE_SAVE_NAME = "Save.json";
        
        public static bool HasFileSavedProgress => 
            File.Exists(SaveFilePath);

        public static string SaveFolderPath => 
            Path.Combine(Application.persistentDataPath, FOLDER_NAME);

        public static string SaveFilePath => 
            Path.Combine(SaveFolderPath, FILE_SAVE_NAME);

        public static void EnsureSaveFolderExists()
        {
            if (Directory.Exists(SaveFolderPath))
                return;
            Directory.CreateDirectory(SaveFolderPath);
        }
    }
}