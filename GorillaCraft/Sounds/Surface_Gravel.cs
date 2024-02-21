using GorillaCraft.Interfaces;

namespace GorillaCraft.Sounds
{
    public class Surface_Gravel : IDataType
    {
        public string Name => "Gravel";
        public float Volume => 0.15f;
        public float Pitch => 1f;
        public int MaxRange => 6;
    }
}
