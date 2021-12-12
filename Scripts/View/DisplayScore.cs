using UnityEngine.UI;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class DisplayScore : MonoBehaviour
    {
        private Text _scoreLabel;

        public DisplayScore(GameObject score)
        {
            _scoreLabel = score.GetComponentInChildren<Text>();
            _scoreLabel.text = string.Empty;
        }

        public void Display(int value)
        {
            _scoreLabel.text = $"Score = {value}";
        }
    }
}
