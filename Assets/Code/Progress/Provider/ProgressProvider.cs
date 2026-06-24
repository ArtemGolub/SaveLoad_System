using Code.Progress.Data;
using R3;

namespace Code.Progress.Provider
{
    public sealed class ProgressProvider : IProgressProvider<ProgressData>
    {
        private readonly ReactiveProperty<ProgressData> _progressData = new();

        public ProgressData progressData { get; private set; }

        public ReadOnlyReactiveProperty<ProgressData> ProgressData =>
            _progressData;

        public void SetProgressData(ProgressData data)
        {
            progressData = data;
            _progressData.Value = data;
        }
    }
}