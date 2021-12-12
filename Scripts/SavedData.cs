using System;


namespace ArtomStatsenko
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;

        public override string ToString() => 
            $"Name {Name} Position {Position} IsVisible {IsEnabled}";
    }
}