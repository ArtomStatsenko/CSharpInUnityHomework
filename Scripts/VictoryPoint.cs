using UnityEngine;
using static UnityEngine.Time;


namespace ArtomStatsenko
{
    public class VictoryPoint : InteractiveObject, IFly
    {
        public int Point;

        private float _lengthFly;
        private float _startPositionY;
        private DisplayScore _displayScore;

        private void Awake()
        {
            _lengthFly = 0.5f;
            _startPositionY = transform.localPosition.y;

            _displayScore = new DisplayScore();
        }

        protected override void Interaction()
        {
            int score = FindObjectOfType<GameController>().Score += Point;
            _displayScore.Display(score);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                                                  _startPositionY + Mathf.PingPong(time, _lengthFly),
                                                  transform.localPosition.z);
        }
    }
}
