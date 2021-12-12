using UnityEngine;


namespace ArtomStatsenko
{
    [CreateAssetMenu(menuName = "Data/Input", fileName = nameof(InputData))]
    public sealed class InputData : ScriptableObject
    {
        public KeyCode Save = KeyCode.F5;
        public KeyCode Load = KeyCode.F10;
        public KeyCode CreateScreenShot = KeyCode.F1;
    }
}
