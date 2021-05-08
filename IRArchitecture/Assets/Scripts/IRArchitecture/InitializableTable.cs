using System;
using System.Collections;
using System.Collections.Generic;

namespace IRArchitecture
{
    public class InitializableTable<T> : IEnumerable<T> where T : IInitializable
    {
        private Dictionary<Type, T> _table = new Dictionary<Type, T>();

        public U Get<U>() where U : T, new()
        {
            var type = typeof(U);
            if (_table.ContainsKey(type))
                return (U)_table[type];

            return Create<U>();
        }
        private U Create<U>() where U : T, new()
        {
            var type = typeof(U);
            var initializable = new U();

            _table.Add(type, initializable);
            initializable.Initialize();

            return initializable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _table)
                yield return item.Value;
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}