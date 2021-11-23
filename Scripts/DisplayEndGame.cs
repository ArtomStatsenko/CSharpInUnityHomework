using UnityEngine;
using UnityEngine.UI;


namespace ArtomStatsenko
{
    public sealed class DisplayEndGame
    {
        private Text _endGameLabel;

        public DisplayEndGame(GameObject endGame)
        {
            _endGameLabel = endGame.GetComponentInChildren<Text>();
            _endGameLabel.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _endGameLabel.text = $"You Lose! {color} {name} killed you.";
        }
    }
    }

