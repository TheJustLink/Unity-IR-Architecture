using System;

using IR;

namespace IR
{
    /// <summary>
    /// Don't use repository, just smart access to temporary data
    /// </summary>
    sealed class ScoreInteractor : IInteractor
    {
        public Action<int> Changed;

        public int Value
        {
            get => _value;
            set
            {
                if (Value == value)
                    return;

                _value = value;
                Changed?.Invoke(value);
            }
        }
        private int _value;
    }
}