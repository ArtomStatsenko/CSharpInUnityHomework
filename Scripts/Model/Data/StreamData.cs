using System.IO;


namespace ArtomStatsenko
{
    public sealed class StreamData : IData<ObjectData>
    {
        public void Save(ObjectData data, string path = null)
        {
            if (path == null) return;

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(data.Name);
                sw.WriteLine(data.Position.X);
                sw.WriteLine(data.Position.Y);
                sw.WriteLine(data.Position.Z);
                sw.WriteLine(data.IsEnabled);
            }
        }

        public ObjectData Load(string path = null)
        {
            var result = new ObjectData();

            using(var sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    result.Name = sr.ReadLine();
                    result.Position.X = float.Parse(sr.ReadLine());
                    result.Position.Y = float.Parse(sr.ReadLine());
                    result.Position.Z = float.Parse(sr.ReadLine());
                    result.IsEnabled = bool.Parse(sr.ReadLine());
                }
            }

            return result;
        }
    }
}