using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantProperty<TType> where TType: class
{
    private TType _value;
    public delegate void OnValueChanged(TType _value);
    public OnValueChanged OnChanged;
    public TType Value
    {
        get { return _value; }
        set 
        {
            if (_value == value)
                return;
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }
    public PersistantProperty(TType value)
    {
        _value = value;
    }
}
