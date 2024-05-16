using System;
using Random = UnityEngine.Random;

namespace GorillaCraft.Models
{
    public class RngObject(int min, int max) : IDisposable
    {
        private readonly int Min = min, Max = max;

        public int Get() => Random.Range(Min, Max + 1);
        public void Out(Action<int> action) => action?.Invoke(Get());

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
