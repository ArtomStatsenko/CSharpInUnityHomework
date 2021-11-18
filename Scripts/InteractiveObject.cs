using System;
using UnityEngine;


namespace ArtomStatsenko
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        public bool IsInteractable { get; } = true;

        protected Color _color;

        private void Start()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                _color = renderer.material.color;
            }
        }

        protected abstract void Interaction();

        public void Action()
        {
            _color = UnityEngine.Random.ColorHSV();

            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }

            Interaction();
            Destroy(gameObject);
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}