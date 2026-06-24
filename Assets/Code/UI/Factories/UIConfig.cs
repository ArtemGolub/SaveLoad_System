using UnityEngine;

namespace Code.UI.Factories
{
    // Simplified
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Configs/UIConfig")]
    public sealed class UIConfig : ScriptableObject
    {
        public GameObject ScoreBarPrefab;
        public GameObject ScoreManipulatorPrefab;
        public GameObject SaveLoadPrefab;
    }
}