using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Surface_Default : IDataType
    {
        public string Name => "Stone";
        public float Volume => 0.15f;
        public float Pitch => 1f;
        public int MaxRange => 6;
    }
}
