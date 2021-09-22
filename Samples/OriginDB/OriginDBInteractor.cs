using System;

using IR;

namespace IR
{
    sealed class OriginDBInteractor : Interactor<OriginDBRepository>
    {
        public event Action ValueChanged;

        public int Value
        {
            get => Repository.Value;
            set
            {
                if (Value == value)
                    return;

                Value = value;
                ValueChanged?.Invoke();
            }
        }
    }
}