using UnityEngine;
using UnityEngine.Events;
using System;

public class KeyMapper : MonoBehaviour
{
    public MappingDictionary mappingList;

    void Update()
    {
        foreach (KeyCode kcode in mappingList.Keys)
        {
            if (Input.GetKeyDown(kcode))
            {
                mappingList[kcode].Invoke();
            }
        }
    }
}

[Serializable]
public class MappingDictionary : SerializableDictionary<KeyCode, UnityEvent>{}