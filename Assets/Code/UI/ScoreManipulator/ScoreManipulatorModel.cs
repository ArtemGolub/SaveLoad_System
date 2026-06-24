using Code.Meta.Score.Services;

namespace Code.UI.ScoreManipulator
{
    public sealed class ScoreManipulatorModel
    {
        private readonly IScoreService _scoreService;
        private readonly (int min, int max) _amountRange;

        private int CurrentAmount =>
            _scoreService.currentAmount;

        public ScoreManipulatorModel(
            IScoreService scoreService,
            (int min, int max) amountRange)
        {
            _scoreService = scoreService;
            _amountRange = amountRange;
        }

        public void IncreaseScore(int amount) =>
            _scoreService.IncreaseScore(amount);

        public void DecreaseScore(int amount) =>
            _scoreService.DecreaseScore(amount);

        public bool CanIncrease(int amount) =>
            CurrentAmount + amount <= _amountRange.max;

        public bool CanDecrease(int amount) =>
            CurrentAmount - amount >= _amountRange.min;

        public bool isMin() =>
            CurrentAmount <= _amountRange.min;

        public bool isMax() =>
            CurrentAmount >= _amountRange.max;
    }
}