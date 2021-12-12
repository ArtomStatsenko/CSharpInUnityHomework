using System.IO;
using UnityEngine;


namespace ArtomStatsenko
{ 
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;
        private const string FOLDER_NAME = "dataSave";
        private const string FILE_NAME = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }

            _path = Path.Combine(Application.dataPath, FOLDER_NAME);
        }

        public void Save(PlayerBase player)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            var savedData = new SavedData
            {
                Position = player.transform.position,
                Name = "Player",
                IsEnabled = true
            };

            _data.Save(savedData, Path.Combine(_path, FILE_NAME));
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, FILE_NAME);

            if (!File.Exists(file)) return;

            var newObject = _data.Load(file);
            player.transform.position = newObject.Position;
            player.name = newObject.Name;
            player.gameObject.SetActive(newObject.IsEnabled);

            Debug.Log(newObject);
        }
    }
}