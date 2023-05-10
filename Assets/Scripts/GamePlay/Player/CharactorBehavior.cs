using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorBehavior : MonoBehaviour
{
    public bool isFacingLeft;
    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    private void Start() {
    }
    public void Flip(){
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        isFacingLeft = _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
