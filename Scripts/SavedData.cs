using System;
using System.Collections.Generic;


namespace ArtomStatsenko
{
    [Serializable]
    public sealed class SavedData
    {
        public List<ObjectData> SavedObjects;

        public SavedData()
        {
            SavedObjects = new List<ObjectData>();
        }
    }
}