using UnityEngine.UI;
using UnityEngine;


namespace ArtomStatsenko
{
    public class DisplayScore : MonoBehaviour
    {
        private Text _text;

        public DisplayScore()
        {
            _text = FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            _text.text = $"Score = {value}";
        }
    }
}
