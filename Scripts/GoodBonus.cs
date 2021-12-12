using UnityEngine;
using static UnityEngine.Time;


namespace ArtomStatsenko
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private Material _material;
        private float _lengthFly = 1.0f;
        private float _startPositionY;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _startPositionY = transform.localPosition.y;
        }
        public override void Execute()
        {
            if (!IsInteractable) return;

            Fly();
            Flicker();
        }

        protected override void Interaction()
        {
            FindObjectOfType<Player>().Accelerate();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                                                  _startPositionY + Mathf.PingPong(time, _lengthFly), 
                                                  transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, 
                                        _material.color.b, Mathf.PingPong(time, 1.0f));
        }
    }
}
