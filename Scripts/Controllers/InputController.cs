using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;

        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0.0f, 
                             Input.GetAxis(AxisManager.VERTICAL));
        }
    }
}