namespace FallingBalls.SaveLoadSystem
{
    public interface ISaver
    {
        void Save(ISaveable obj);
        void Load(ISaveable obj);
        bool IsFileExist(ISaveable obj);
    }
}