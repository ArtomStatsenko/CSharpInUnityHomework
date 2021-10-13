using System;
using UnityEngine;
using UnityEngine.UI;


namespace ArtomStatsenko
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public int Score { get; set; }
        private Text _finishGameLabel;

        private InteractiveObject[] _interactiveObject;
        private DisplayEndGame _displayEndGame;

        private CameraController _cameraController;

        private void Awake()
        {
            _interactiveObject = FindObjectsOfType<InteractiveObject>();
            _finishGameLabel = FindObjectOfType<Text>();

            _displayEndGame = new DisplayEndGame(_finishGameLabel);

            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }
            }
        }
        
        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            //Time.timeScale = 0.0f;
        }

        private void Update()
        {
            foreach (InteractiveObject interactiveObject in _interactiveObject)
            {
                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }
        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                    Destroy(o.gameObject);
                }
            }
        }

    }
}
