namespace ArtomStatsenko
{
    public interface ISave
    {
        //TODO
        string Name { get; set; }
        Vector3Serializable Position { get; set; }
        bool IsEnable { get; set; }
    }
}