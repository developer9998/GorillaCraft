using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_Wood : IDataType
    {
        public string Name => "Wood";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int Range => 4;
    }
}
