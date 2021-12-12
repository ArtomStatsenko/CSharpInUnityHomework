using System;
using UnityEngine;
using static UnityEngine.Time;


namespace ArtomStatsenko
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        public event Action<string, Color> OnCaughtPlayerChange = 
            delegate (string str, Color color) { };

        private float _lengthFly = 1.0f;
        private float _speedRotation = 50.0f;
        private float _startPositionY;
 
        private void Awake()
        {
            _startPositionY = transform.localPosition.y;
        }

        public override void Execute()
        {
            if (!IsInteractable) return;

            Fly();
            Rotation();
        }

        protected override void Interaction()
        {
            FindObjectOfType<Player>().Decelerate();

            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                                                  _startPositionY + Mathf.PingPong(time, _lengthFly),
                                                  transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation), Space.World);
        }
    }
}
