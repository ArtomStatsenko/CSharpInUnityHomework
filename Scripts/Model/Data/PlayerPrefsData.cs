using UnityEngine;


namespace ArtomStatsenko
{
    public class PlayerPrefsData : IData<ObjectData>
    {
        public void Save(ObjectData data, string path = null)
        {
            PlayerPrefs.SetString("Name", data.Name);
            PlayerPrefs.SetFloat("PosX", data.Position.X);
            PlayerPrefs.SetFloat("PosY", data.Position.Y);
            PlayerPrefs.SetFloat("PosZ", data.Position.Z);
            PlayerPrefs.SetString("IsEnable", data.IsEnabled.ToString());

            PlayerPrefs.Save();
        }

        public ObjectData Load(string path = null)
        {
            var result = new ObjectData();

            var key = "Key";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = "PosX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }

            key = "PosY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Y = PlayerPrefs.GetFloat(key);
            }

            key = "PosZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Z = PlayerPrefs.GetFloat(key);
            }

            key = "IsEnabled";
            if (PlayerPrefs.HasKey(key))
            {
                result.IsEnabled = PlayerPrefs.GetString(key).TryBool();
            }

            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}