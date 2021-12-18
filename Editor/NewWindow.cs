using UnityEditor;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class NewWindow : EditorWindow
    {
        private static GameObject _gameObject;
        private bool _groupEnabled;
        private int _objectCount;

        private void OnGUI()
        {
            GUILayout.Label("Game Object", EditorStyles.boldLabel);

            _gameObject = EditorGUILayout.ObjectField
                ("Object", _gameObject, typeof(GameObject), true) as GameObject;

            _groupEnabled = EditorGUILayout.BeginToggleGroup("Additives", _groupEnabled);
            _objectCount = EditorGUILayout.IntSlider("Object Count", _objectCount, 1, 10);
            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Create Objects");
            if(button)
            {
                CreateObjects();
            }
        }

        private void CreateObjects()
        {
            GameObject root = new GameObject("Root");
            for (var i = 0; i < _objectCount; i++)
            {
                float angle = i * Mathf.PI * 2 / _objectCount;
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0,
                                 Mathf.Sin(angle)) * 5;
                GameObject temp = Instantiate(_gameObject, pos, Quaternion.identity);
                temp.name = $"{nameof(_gameObject)}({i})";
                temp.transform.parent = root.transform;
            }            
        }
    }
}