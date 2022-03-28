using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _mover.Move(Input.GetAxis("Horizontal"));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _mover.Jump();
        }
    }

    public void Stop()
    {
        this.enabled = false;
    }
}
