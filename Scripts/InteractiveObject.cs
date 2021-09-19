using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace ArtomStatsenko
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        public bool IsInteractable { get; } = true;

        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }

            Interaction();
            Destroy(gameObject);
        }

        void IAction.Action()
        {
            if(TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        void IInitialization.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}
