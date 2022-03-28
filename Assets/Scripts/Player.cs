using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private UnityEvent _die;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            AddCoin(collision.GetComponent<Coin>().PickUp());
        }

        if (collision.GetComponent<Enemy>())
        {
            _die?.Invoke();
        }
    }

    private void AddCoin(int value)
    {
        _coins += value;
    }
}
