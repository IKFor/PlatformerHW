using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private int _spawnDelay = 2;

    private Coin _coin;
    private bool _isSpawned = true;

    private void Update()
    {
       if (!_coin && _isSpawned)
        {
            StartCoroutine(Spawn());
        }
            
    }

    private IEnumerator Spawn()
    {
        _isSpawned = false;

        yield return new WaitForSeconds(_spawnDelay);

        _coin = Instantiate(_template, transform.position, Quaternion.identity);
        _coin.transform.SetParent(transform);

        _isSpawned = true;
    }
}
