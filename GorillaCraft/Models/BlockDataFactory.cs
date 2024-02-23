using GorillaCraft.Interfaces;
using System;
using Zenject;

namespace GorillaCraft.Models
{
    public class BlockDataFactory : IFactory<Type, IDataType>
    {
        private readonly DiContainer _container;
        public BlockDataFactory(DiContainer container) => _container = container;
        public IDataType Create(Type dataType) => (IDataType)_container.Instantiate(dataType);
    }
}
