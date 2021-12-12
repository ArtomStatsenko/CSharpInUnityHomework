using UnityEngine;


namespace ArtomStatsenko
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public string Name = "Player";
        public float Speed = 3.0f;
        public float AccelerationRatio = 1.2f;
        public float DecelerationRatio = 1.2f;

        public abstract void Move(float x, float y, float z);
    }
}