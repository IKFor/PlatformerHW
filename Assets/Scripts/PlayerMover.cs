using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _minMoveDistance;
    [SerializeField] private Animator _animator;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private const string _animationSpeed = "speed";

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Jump()
    {
        if (_rigidbody2D.Cast(-transform.up, _results, _minMoveDistance) > 0)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce);
        }
    }

    public void Move(float direction)
    {
        if (_rigidbody2D.Cast(new Vector2(direction, 0), _results, _minMoveDistance) == 0)
        {
            _rigidbody2D.velocity = new Vector2(_speed * direction, _rigidbody2D.velocity.y);

            _animator.SetFloat(_animationSpeed, _rigidbody2D.velocity.x);

            if (_rigidbody2D.velocity.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_rigidbody2D.velocity.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
