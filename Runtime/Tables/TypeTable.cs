using System;
using System.Collections;
using System.Collections.Generic;

namespace IR.Tables
{
    abstract class TypeTable<T> : IEnumerable<T>
    {
        private readonly Dictionary<Type, T> _table = new Dictionary<Type, T>();

        public void Clear()
        {
            _table.Clear();
        }

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
            var value = CreateInternal<U>();

            _table.Add(type, value);

            TryInitialize(value);
            return value;
        }

        protected virtual U CreateInternal<U>() where U : T, new()
        {
            return new U();
        }

        private void TryInitialize<U>(U value) where U : T
        {
            if (value is IInitializable initializable)
                initializable.Initialize();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _table)
                yield return item.Value;
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}