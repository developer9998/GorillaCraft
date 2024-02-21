using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Interaction_Grass : IDataType
    {
        public string Name => "Grass";
        public float Volume => 1f;
        public float Pitch => 0.8f;
        public int MaxRange => 4;
    }
}
