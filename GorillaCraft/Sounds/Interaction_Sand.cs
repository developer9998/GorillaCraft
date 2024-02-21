using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_Sand : IDataType
    {
        public string Name => "Sand";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int MaxRange => 4;
    }
}
