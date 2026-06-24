using System;

namespace Code.Progress.Services.UpdateService
{
    public interface IUpdateService
    {
        bool TryUpdate<T>(T data, Action<T> updateAction);
    }
}