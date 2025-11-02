using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Surface_Ladder : IDataType
    {
        public string Name => "ladder";
        public float Volume => 0.3f;
        public float Pitch => 1f;
        public int Range => 5;
    }
}
