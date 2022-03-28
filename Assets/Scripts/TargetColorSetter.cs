using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColorSetter : MonoBehaviour
{
    [SerializeField] private Color _reachedColor;
    [SerializeField] private SpriteRenderer _renderer;

    public void SetColor()
    {
        _renderer.color = _reachedColor;
    }
}
