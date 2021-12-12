using TMPro;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class DisplayEndGame
    {
        private TextMeshProUGUI _endGameLabel;

        public DisplayEndGame(GameObject endGame)
        {
            _endGameLabel = endGame.GetComponentInChildren<TextMeshProUGUI>();
            _endGameLabel.text = string.Empty;  
        }

        public void GameOver(string name, Color color)
        {
            _endGameLabel.text = $"You Lose! <align=\"center\">{color} {name} killed you.";
        }
    }
    }

