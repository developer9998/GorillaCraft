using System;

namespace GorillaCraft.Models
{
    public class ButtonOptionData<T>
    {
        public string Name;
        public T Value;
        public Action<T> OnOptionSet;
    }
}
