using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _saveKey = KeyCode.F5;
        private readonly KeyCode _loadKey = KeyCode.F10;

        public InputController(PlayerBase player)
        {
            _playerBase = player;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0.0f, 
                             Input.GetAxis(AxisManager.VERTICAL));

            if(Input.GetKeyDown(_saveKey))
            {
                _saveDataRepository.Save(_playerBase);
            }

            if(Input.GetKeyDown(_loadKey))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }
    }
}