using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharactorBehavior
{
    public static PlayerController instance;
    Animator _animator;
    public Vector3 moveInput;
    public float movementBlend;
    public float moveSpeed;

    public float fireTime;
    private float _fireTime;
    public Transform firePoint;
    Vector2 lookDirection;
    float lookAngle;
    public float kunaiSpeed = 4;

    private void Awake() {
        _fireTime = fireTime;
        instance = this;
    }
    private void Start() {
    }
    private void Update() {
        _animator = GetComponentInChildren<Animator>();
        //Lật
        if(moveInput.x < 0 && !isFacingLeft ||
        moveInput.x > 0 && isFacingLeft)
        {
            Flip();
        }
        //Bắn
        
        _fireTime -= Time.deltaTime;
        if(_fireTime <= 0 && Input.GetMouseButtonDown(0))
        {
            Fire();
            AudioManager.instance.PlaySFX("Shoot");
            _fireTime = fireTime;
        }
        Move();
        BlendAnimation();
    }
    public void Move(){
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    private void BlendAnimation(){
        float _speedBlend = moveSpeed;
        if(moveInput == Vector3.zero)
        {
            _speedBlend = 0;
        }
        movementBlend = Mathf.Lerp(movementBlend, _speedBlend, Time.deltaTime * 100f);
        var speed = Mathf.Round(movementBlend * 100f) / 100f;
        _animator.SetFloat("Speed", speed);
    }
    private void Fire(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - firePoint.position;
        float angle = Mathf.Atan2(lookDir.y , lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        firePoint.rotation = rotation;
        GameObject _kunai = ObjectPool.Instance.GetPooledKunai();
        if(_kunai != null)
        {
            _kunai.transform.position = firePoint.transform.position;
            _kunai.SetActive(true);
            Rigidbody2D rb = _kunai.GetComponent<Rigidbody2D>();
            rb.velocity = lookDir * kunaiSpeed;
        }
    }
    public Vector3 GetPosPlayer()
    {
        return transform.position;
    }
}
