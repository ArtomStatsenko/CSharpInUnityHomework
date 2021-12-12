using UnityEngine;


namespace ArtomStatsenko
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public string Name = "Player";
        public float Speed = 5.0f;
        public float AccelerationRatio = 2.0f;
        public float DecelerationRatio = 2.0f;

        public abstract void Move(float x, float y, float z);
    }
}