using System;
using UnityEngine;

namespace Code.Progress.Services.UpdateService
{
    public sealed class UpdateService : IUpdateService
    {
        public bool TryUpdate<T>(T data, Action<T> updateAction)
        {
            if (data == null)
            {
                Debug.LogWarning($"UpdateService: Cannot update null data of type {typeof(T).Name}.");
                return false;
            }

            if (updateAction == null)
            {
                Debug.LogWarning($"UpdateService: Update action is null for type {typeof(T).Name}.");
                return false;
            }

            try
            {
                updateAction.Invoke(data);

                Debug.Log($"UpdateService: Updated data of type {typeof(T).Name}.");

                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"UpdateService: Failed to update data of type {typeof(T).Name}: {exception.Message}");
                return false;
            }
        }
    }
}