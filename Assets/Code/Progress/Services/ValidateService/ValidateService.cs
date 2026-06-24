using Code.Meta.Score;
using Code.Progress.Data;
using UnityEngine;

namespace Code.Progress.Services.ValidateService
{
    public sealed class ValidateService : IValidateService
    {
        public bool TryValidate<T>(T data)
        {
            if (data == null)
            {
                Debug.LogWarning($"ValidateService: Data of type {typeof(T).Name} is null.");
                return false;
            }

            if (data is ProgressData progressData)
                return TryValidateProgressData(progressData);

            return true;
        }

        private bool TryValidateProgressData(ProgressData progressData)
        {
            if (progressData.PlayerData == null)
                progressData.PlayerData = new PlayerData();

            if (progressData.PlayerData.Score == null)
                progressData.PlayerData.Score = new Score();

            return true;
        }
    }
}