using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_Cloth : IDataType
    {
        public string Name => "Cloth";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int Range => 4;
    }
}
