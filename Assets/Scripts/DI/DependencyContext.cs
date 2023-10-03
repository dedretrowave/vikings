using System;
using System.Collections.Generic;

namespace DI
{
    public class DependencyContext
    {
        public static DependencyCollection Dependencies { get; } = new();
    }

    public class DependencyCollection
    {
        private Dictionary<Type, Dependency> _dependencies = new();

        public void Add(Dependency dependency)
        {
            if (!_dependencies.ContainsKey(dependency.Type))
            {
                _dependencies.Add(dependency.Type, dependency);
            }

            _dependencies[dependency.Type] = dependency;
        }

        public void Add(Type type, Func<object> func)
        {
            Dependency dependency = new Dependency(type, func);
            
            Add(dependency);
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        private object Get(Type type)
        {
            if (!_dependencies.ContainsKey(type))
            {
                throw new ArgumentException($"{type} NOT FOUND");
            }

            return _dependencies[type].Factory();
        }
    }

    public class Dependency
    {
        public Type Type { get; }
        public Func<object> Factory { get; }

        public Dependency(Type type, Func<object> factory)
        {
            Type = type;
            Factory = factory;
        }
    }
}