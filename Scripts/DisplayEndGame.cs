using UnityEngine;
using UnityEngine.UI;


namespace ArtomStatsenko
{
    public class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = string.Empty;
        }

        public void GameOver(object o, CaughtPlayerEventArgs args)
        {
            GameObject gameObject;

            try
            {
                if (o is GameObject @object)
                {
                    gameObject = @object;
                }
                else
                {
                    throw new MyException("Invalid cast...");
                }

                _finishGameLabel.text = $"You Lose! {args.Color} {gameObject.name} killed you.";
            }
            catch (MyException e)
            {
                Debug.Log(e.Message);
            }
        }
    }
    }

