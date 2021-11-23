using UnityEngine;


namespace ArtomStatsenko
{
    public class Reference : ScriptableObject
    {
        private Player _player;
        private Camera _mainCamera;

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }

                return _player;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if(_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;
            }
        }
    }
}