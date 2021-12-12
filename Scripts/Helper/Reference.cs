using UnityEngine;
using UnityEngine.UI;


namespace ArtomStatsenko
{
    public class Reference : ScriptableObject
    {
        private Player _player;
        private Camera _mainCamera;
        private GameObject _score;
        private GameObject _endGame;
        private Canvas _canvas;
        private Button _restart;

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Player");
                    _player = Instantiate(gameObject);
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

        public Canvas Canvas
        {
            get
            {
                if(_canvas == null)
                {
                    _canvas = FindObjectOfType<Canvas>();
                }

                return _canvas;
            }
        }

        public GameObject Score
        {
            get
            {
                if(_score == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Score");
                    _score = Instantiate(gameObject, Canvas.transform);
                }

                return _score;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Instantiate(gameObject, Canvas.transform);
                }

                return _endGame;
            }
        }

        public Button Restart
        {
            get
            {
                if (_restart == null)
                {
                    var gameObject = Resources.Load<Button>("UI/Restart");
                    _restart = Instantiate(gameObject, Canvas.transform);
                }

                return _restart;
            }
        }    
    }
}