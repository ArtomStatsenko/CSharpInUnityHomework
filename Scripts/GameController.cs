using System;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public int Score { get; set; } 

        private InteractiveObject[] _interactiveObject;

        private void Awake()
        {
            _interactiveObject = FindObjectsOfType<InteractiveObject>();
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
            foreach (var obj in _interactiveObject)
            {
                Destroy(obj.gameObject);
            }
        }

    }
}
