using UnityEngine.UI;

namespace Code.UI.SaveLoad
{
    public sealed class SaveLoadView
    {
        private readonly (Button btnSave, Button btnLoad, Button btnDelete, Button btnCreate) _buttons;

        public SaveLoadView((Button btnSave, Button btnLoad, Button btnDelete, Button btnCreate) buttons)
        {
            _buttons = buttons;
        }

        private void UpdateSaveButtonState(bool isSaveButtonEnabled) =>
            _buttons.btnSave.interactable = isSaveButtonEnabled;
        
        private void UpdateLoadButtonState(bool isLoadButtonEnabled) =>
            _buttons.btnLoad.interactable = isLoadButtonEnabled;
        
        private void UpdateDeleteButtonState(bool isDeleteButtonEnabled) =>
            _buttons.btnDelete.interactable = isDeleteButtonEnabled;
        
        private void UpdateCreateButtonState(bool isDeleteButtonEnabled) =>
            _buttons.btnDelete.interactable = isDeleteButtonEnabled;

        public void UpdateButtonsState(bool hasFileSave)
        {
            UpdateSaveButtonState(hasFileSave);
            UpdateLoadButtonState(hasFileSave);
            UpdateDeleteButtonState(!hasFileSave);
            UpdateCreateButtonState(hasFileSave);
        }
    }
}