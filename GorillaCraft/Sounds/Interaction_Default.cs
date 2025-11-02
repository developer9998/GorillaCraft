using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_Default : IDataType
    {
        public string Name => "Stone";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int Range => 4;
    }
}
