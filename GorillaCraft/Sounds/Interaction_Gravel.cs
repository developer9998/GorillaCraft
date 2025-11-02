using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_Gravel : IDataType
    {
        public string Name => "Gravel";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int Range => 4;
    }
}
