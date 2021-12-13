using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace ArtomStatsenko
{ 
    public sealed class SaveDataRepository
    {
        private readonly IData<List<SavedData>> _data;
        private InteractiveObject[] _interactiveObjects;
        private const string FOLDER_NAME = "dataSave";
        private const string FILE_NAME = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<List<SavedData>>();
            _path = Path.Combine(Application.dataPath, FOLDER_NAME);
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }

        public void Save()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            List<SavedData> savedData = new List<SavedData>();   
            foreach (var obj in _interactiveObjects)
            {
                savedData.Add(new SavedData
                {
                    Id = obj.GetInstanceID(),
                    Position = obj.transform.position,
                    Name = obj.name,
                    IsEnabled = obj.enabled
                }) ;
            }            

            _data.Save(savedData, Path.Combine(_path, FILE_NAME));
        }

        public void Load()
        {
            var file = Path.Combine(_path, FILE_NAME);

            if (!File.Exists(file)) return;

            var newObject = _data.Load(file);
            foreach (var obj in _interactiveObjects)
            {
                SavedData savedObject = newObject.Find(x => x.Id == obj.GetInstanceID()); //?

                obj.transform.position = savedObject.Position;
                obj.name = savedObject.Name;
                obj.enabled = savedObject.IsEnabled;

                Debug.Log(savedObject);
            }


        }
    }
}