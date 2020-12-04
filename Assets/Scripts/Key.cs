using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //Variable for the value of the key
    public string keyType = "";
    public int points;

    //Returns the value of the key
    public string getKeyType()
    {
        return keyType;
    }
}
