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
        if (collision.TryGetComponent<Coin>(out _))
        {
            AddCoin(collision.GetComponent<Coin>().PickUp());
        }

        if (collision.TryGetComponent<Enemy>(out _))
        {
            _die?.Invoke();
        }
    }

    private void AddCoin(int value)
    {
        _coins += value;
    }
}
