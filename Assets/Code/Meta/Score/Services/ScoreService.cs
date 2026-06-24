using Code.Progress.Data;
using Code.Progress.Provider;
using R3;
using UnityEngine;

namespace Code.Meta.Score.Services
{
    public sealed class ScoreService : IScoreService
    {
        private readonly IProgressProvider<ProgressData> _progressProvider;
        private readonly ReactiveProperty<int> _currentAmount = new(0);
        private readonly CompositeDisposable _disposables = new();

        private Score score =>
            _progressProvider.progressData?.PlayerData?.Score;

        public int currentAmount =>
            _currentAmount.Value;

        public ReadOnlyReactiveProperty<int> CurrentAmount =>
            _currentAmount;

        public ScoreService(IProgressProvider<ProgressData> progressProvider)
        {
            _progressProvider = progressProvider;

            _progressProvider.ProgressData
                .Where(progressData => progressData != null)
                .Subscribe(OnProgressDataChanged)
                .AddTo(_disposables);
        }

        public Score GetScore() =>
            score;

        public void SetScore(Score newScore)
        {
            if (_progressProvider.progressData == null)
            {
                Debug.LogWarning("ScoreService: ProgressData is null. Cannot set score.");
                return;
            }

            Debug.Log($"ScoreService: Set Score on amount {newScore.Amount}");

            _progressProvider.progressData.PlayerData.Score = newScore;
            _currentAmount.Value = newScore.Amount;
        }

        public void IncreaseScore(int amount)
        {
            if (score == null)
            {
                Debug.LogWarning("ScoreService: Score is null. Cannot increase score.");
                return;
            }

            Debug.Log($"ScoreService: Increased Score by {amount}");

            score.Amount += amount;
            _currentAmount.Value = score.Amount;
        }

        public void DecreaseScore(int amount)
        {
            if (score == null)
            {
                Debug.LogWarning("ScoreService: Score is null. Cannot decrease score.");
                return;
            }

            Debug.Log($"ScoreService: Decreased by {amount}");

            score.Amount -= amount;
            _currentAmount.Value = score.Amount;
        }

        private void OnProgressDataChanged(ProgressData progressData)
        {
            int amount = progressData.PlayerData.Score?.Amount ?? 0;
            _currentAmount.Value = amount;
        }
    }
}