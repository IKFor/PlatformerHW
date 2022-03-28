using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private int _spawnDelay = 2;

    private Coin _coin;
    private float _timeToSpawn;

    private void Awake()
    {
        Spawn();
    }

    private void Update()
    {
        if (!_coin)
        {
            _timeToSpawn += Time.deltaTime;

            if (_timeToSpawn >= _spawnDelay)
            {
                _timeToSpawn = 0;
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        _coin = Instantiate(_template, transform.position, Quaternion.identity);

        _coin.transform.SetParent(transform);
    }
}
