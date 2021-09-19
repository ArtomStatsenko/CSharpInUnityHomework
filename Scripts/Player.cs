using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidBody;

        private void Start()
        {
            _speed = 5f;
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidBody.AddForce(movement * _speed);
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Slowdown()
        {
            _speed /= 2;
        }

        public void Accelerate()
        {
            _speed *= 2;
        }
    }
}