using UnityEngine.UI;

namespace Code.UI.ScoreManipulator
{
    public sealed class ScoreManipulatorView
    {
        private readonly Button _btnIncrease;
        private readonly Button _btnDecrease;

        public ScoreManipulatorView( 
            Button btnIncrease,
            Button btnDecrease
            )
        {
            _btnIncrease = btnIncrease;
            _btnDecrease = btnDecrease;
        }
        
        public void SetIncreaseButtonInteractable(bool isInteractable) =>
            _btnIncrease.interactable = isInteractable;

        public void SetDecreaseButtonInteractable(bool isInteractable) =>
            _btnDecrease.interactable = isInteractable;
    }
}