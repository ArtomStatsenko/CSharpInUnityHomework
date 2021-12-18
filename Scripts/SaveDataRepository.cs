using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace ArtomStatsenko
{ 
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;
        private InteractiveObject[] _interactiveObjects;
        private const string FOLDER_NAME = "dataSave";
        private const string FILE_NAME = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, FOLDER_NAME);
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }

        public void Save()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            SavedData savedData = new SavedData();

            foreach (var obj in _interactiveObjects)
            {
                ObjectData objectData = new ObjectData
                {
                    Id = obj.GetInstanceID(),
                    Position = obj.transform.position,
                    Name = obj.name,
                    IsEnabled = obj.enabled
                };

                savedData.SavedObjects.Add(objectData);
            }

            _data.Save(savedData, Path.Combine(_path, FILE_NAME));
        }

        public void Load()
        {
            var file = Path.Combine(_path, FILE_NAME);

            if (!File.Exists(file)) return;

            var loadedData = _data.Load(file);
            List<ObjectData> objectData = loadedData.SavedObjects;

            foreach (var obj in _interactiveObjects)
            {
                ObjectData savedObject = objectData.Find(x => x.Id == obj.GetInstanceID());

                obj.transform.position = savedObject.Position;
                obj.name = savedObject.Name;
                obj.enabled = savedObject.IsEnabled;
            }
        }
    }
}