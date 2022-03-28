using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        transform.position = _points[0].position;
    }

    private void Update()
    {
        Vector3 _targetPointPosition = _points[_currentPoint].position;
        transform.position = Vector3.MoveTowards(transform.position, _targetPointPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPointPosition)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
