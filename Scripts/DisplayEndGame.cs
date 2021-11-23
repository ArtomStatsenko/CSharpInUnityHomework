using UnityEngine;
using UnityEngine.UI;


namespace ArtomStatsenko
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame()
        {
            // from code
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"You Lose! {color} {name} killed you.";
        }
    }
    }

