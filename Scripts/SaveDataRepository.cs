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
                _data = new SerializableXMLData<SavedData>();
            }

            _path = Path.Combine(Application.dataPath, FOLDER_NAME);
        }

        public void Save(PlayerBase player)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = "Player 1",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, FILE_NAME));
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, FILE_NAME);

            if (!File.Exists(file)) return;

            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer);
        }
    }
}