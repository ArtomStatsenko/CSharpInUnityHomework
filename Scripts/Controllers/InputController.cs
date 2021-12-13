using System.Collections.Generic;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly InputData _inputData;

        public InputController(PlayerBase player, InputData inputData)
        {
            _playerBase = player;
            _inputData = inputData;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0.0f, 
                             Input.GetAxis(AxisManager.VERTICAL));

            if (Input.GetKeyDown(_inputData.Save))
            {
                _saveDataRepository.Save();
            }

            if (Input.GetKeyDown(_inputData.Load))
            {
                _saveDataRepository.Load();
            }

            if (Input.GetKeyDown(_inputData.CreateScreenShot))
            {
                _playerBase.StartCoroutine(new PhotoController().DoTapExampleAsync());
            }
        }
    }
}