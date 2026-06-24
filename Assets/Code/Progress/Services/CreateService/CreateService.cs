using System;
using UnityEngine;

namespace Code.Progress.Services.CreateService
{
    public sealed class CreateService: ICreateService
    {
        public bool TryCreate<T>(out T data) where T : new()
        {
            try
            {
                data = new T();

                Debug.Log($"CreateService: Created data of type {typeof(T).Name}.");

                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"CreateService: Failed to create data of type {typeof(T).Name}: {exception.Message}");

                data = default;
                return false;
            }
        }
    }
}