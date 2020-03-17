using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{

    public bool initValue;
    [HideInInspector]
    public bool currentValue;

    public void OnAfterDeserialize()
    {
        currentValue = initValue;
    }

    public void OnBeforeSerialize()
    {

    }
}

