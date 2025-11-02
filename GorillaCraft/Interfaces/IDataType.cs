namespace GorillaCraft.Interfaces
{
    public interface IDataType
    {
        public string Name { get; }
        public float Volume { get; }
        public float Pitch { get; }
        public int Range { get; }
    }
}
