using System;
using UnityEngine;
using static UnityEngine.Time;


namespace ArtomStatsenko
{
    public class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
    {
        private float _lengthFly;
        private float _speedRotation;
        private float _startPositionY;

        private void Awake()
        {
            _lengthFly = 1.0f;
            _speedRotation = 50.0f;
            _startPositionY = transform.localPosition.y;
        }

        protected override void Interaction()
        {
            //smth Bad
            FindObjectOfType<Player>().Slowdown();
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

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation,
                                     transform.parent);
            return result;
        }
    }
}
