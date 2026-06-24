using R3;

namespace Code.Progress.Provider
{
    public interface IProgressProvider<TProgress>
    {
        TProgress progressData { get; }

        ReadOnlyReactiveProperty<TProgress> ProgressData { get; }

        void SetProgressData(TProgress progress);
    }
}