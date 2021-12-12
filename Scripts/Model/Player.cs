using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class Player : PlayerBase
    {
        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidBody.AddForce(new Vector3(x, y, z) * Speed);
        }
              
        public void Decelerate()
        {
            Speed /= DecelerationRatio;
        }

        public void Accelerate()
        {
            Speed *= AccelerationRatio;
        }
    }
}