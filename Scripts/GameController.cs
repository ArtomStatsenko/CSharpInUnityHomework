using System;
using UnityEngine;
using UnityEngine.UI;


namespace ArtomStatsenko
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayScore _displayScore;
        private int _countScore;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _displayEndGame = new DisplayEndGame();
            _displayScore = new DisplayScore();

            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is VictoryPoint victoryPoint)
                {
                    victoryPoint.OnPointChange += AddPoint;
                }
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            Time.timeScale = 0.0f; //?
        }

        private void AddPoint(int value)
        {
            _countScore += value;
            _displayScore.Display(_countScore);
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                interactiveObject.Execute();
            }
        }
        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is VictoryPoint victoryPoint)
                {
                    victoryPoint.OnPointChange -= AddPoint;
                }
            }
        }
    }
}
