using TMPro;

namespace Code.UI.ScoreBar
{
    public sealed class ScoreBarView
    {
        private readonly TextMeshProUGUI _scoreText;

        public ScoreBarView(TextMeshProUGUI scoreText) => 
            _scoreText = scoreText;
        
        public void SetScore(int getScore) =>
            _scoreText.text = getScore.ToString();
        
    }
}