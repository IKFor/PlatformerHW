using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_rb2D.Cast(-transform.up, _results, 0.1f) > 0)
        {
            _rb2D.AddForce(Vector3.up * _jumpForce);
        }
    }

    public void Move(float direction)
    {
        _rb2D.velocity = new Vector2(_speed * direction, _rb2D.velocity.y);
    }
}
