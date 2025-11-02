using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    internal class Surface_Snow : IDataType
    {
        public string Name => "Snow";
        public float Volume => 0.15f;
        public float Pitch => 1f;
        public int Range => 4;
    }
}
