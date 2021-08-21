using System;
using System.Collections;
using System.Collections.Generic;

namespace IRCore.Tables
{
    abstract class TypeTable<T> : IEnumerable<T>
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
            var value = CreateValue<U>();

            _table.Add(type, value);

            return value;
        }

        protected virtual U CreateValue<U>() where U : T, new()
        {
            return new U();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _table)
                yield return item.Value;
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}