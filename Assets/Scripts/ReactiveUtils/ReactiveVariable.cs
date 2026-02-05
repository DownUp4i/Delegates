using System;
using System.Diagnostics;

public class ReactiveVariable<T>: IReadOnlyReactiveVariable<T> where T : IEquatable<T>
{
    private T _value;

    public ReactiveVariable(T value) => _value = value;

    
    public event Action<T> Changed;

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;
            _value = value;

            if (oldValue.Equals(_value) == false)
            {
                Changed?.Invoke(_value);
            }
        }
    }
}
