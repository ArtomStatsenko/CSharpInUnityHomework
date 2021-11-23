using System;
using UnityEngine;
using static UnityEngine.Time;


namespace ArtomStatsenko
{
    public sealed class VictoryPoint : InteractiveObject, IFly
    {
        public int Point;
        public event Action<int> OnPointChange = delegate (int i) { };

        private float _lengthFly = 0.5f;
        private float _startPositionY;

        private void Awake()
        {
            _startPositionY = transform.localPosition.y;
        }
        public override void Execute()
        {
            if (!IsInteractable) return;

            Fly();
        }

        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                                                  _startPositionY + Mathf.PingPong(time, _lengthFly),
                                                  transform.localPosition.z);
        }
    }
}
