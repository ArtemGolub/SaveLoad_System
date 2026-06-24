namespace Code.UI.ScoreBar
{
    public sealed class ScoreBarModel
    {
        private int _score;
        
        public void SetScore(int score) =>
            _score = score;
        
        public int GetScore() => 
            _score;
    }
}