using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Serialize a custom class
public class Attribute
{
    [SerializeField]
    private int defaultValue; // A default value for any attribute declared

    public int GetValue()
    {
        return defaultValue;
    }

}
