using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    internal class Interaction_Snow : IDataType
    {
        public string Name => "Snow";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int MaxRange => 4;
    }
}
