using System;
using System.Collections;
using UnityEngine;


namespace ArtomStatsenko
{
    public class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;

        public ListInteractableObject()
        {
            _interactiveObjects = UnityEngine.Object.FindObjectsOfType<InteractiveObject>();
            Array.Sort(_interactiveObjects);
        }

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if(_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;
        
        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        public int Count => _interactiveObjects.Length;
    }
}