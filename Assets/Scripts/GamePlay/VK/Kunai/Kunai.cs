using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D _rb2D;
    private Vector3 _mousePos;
    private Vector3 _mouseDir;
    // public Transform firePoint;
    float lookAngle;


    private void Start() {
        _rb2D = GetComponent<Rigidbody2D>();
        _mouseDir = _mousePos - transform.position;
    }
    private void Update() {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
        // firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        Move();
    }
    private void Move(){
        // _rb2D.AddForce(_mouseDir * moveSpeed *Time.deltaTime , ForceMode2D.Impulse);
        transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        _rb2D.velocity = Vector2.right * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }

    }
}
