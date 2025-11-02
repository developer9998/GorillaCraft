using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_BreakingGlass : IDataType
    {
        public string Name => "Glass";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int Range => 3;
    }
}
