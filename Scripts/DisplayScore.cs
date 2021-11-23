using UnityEngine.UI;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class DisplayScore : MonoBehaviour
    {
        private Text _text;

        public DisplayScore()
        {
            // from code
        }

        public void Display(int value)
        {
            _text.text = $"Score = {value}";
        }
    }
}
