namespace FallingBalls.SaveLoadSystem
{
    public interface ISaveable
    {
        string GetFileName();
        object GetObject();
    }
}