using R3;

namespace Code.Meta.Score.Services
{
    public interface IScoreService
    {
        int currentAmount { get; }

        ReadOnlyReactiveProperty<int> CurrentAmount { get; }

        Score GetScore();

        void SetScore(Score score);

        void IncreaseScore(int amount);

        void DecreaseScore(int amount);
    }
}