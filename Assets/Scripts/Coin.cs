using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    public int PickUp()
    { 
        Destroy(gameObject);

        return _value;
    }
}
