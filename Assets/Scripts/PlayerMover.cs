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

    private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Jump()
    {
        if (_rb2D.Cast(-transform.up, _results, _minMoveDistance) > 0)
        {
            _rb2D.AddForce(Vector3.up * _jumpForce);
        }
    }

    public void Move(float direction)
    {
        if (_rb2D.Cast(new Vector2(direction, 0), _results, _minMoveDistance) == 0)
        {
            _rb2D.velocity = new Vector2(_speed * direction, _rb2D.velocity.y);

            _animator.SetFloat("speed", _rb2D.velocity.x);

            if (_rb2D.velocity.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
