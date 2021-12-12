using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ArtomStatsenko
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] private InputData _inputData;

        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayScore _displayScore;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private int _countScore;

        private void Awake()
        {
            _reference = new Reference();
            _interactiveObject = new ListExecuteObject();
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayScore = new DisplayScore(_reference.Score);

            _cameraController = new CameraController(_reference.Player.transform,
                                                     _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(_reference.Player, _inputData);
            _interactiveObject.AddExecuteObject(_inputController);

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

            _reference.Restart.onClick.AddListener(RestartGame);
            _reference.Restart.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.Restart.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
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
