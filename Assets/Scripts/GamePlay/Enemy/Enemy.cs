using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _hpEnemy;
    public int hpEnemy;
    public int atkEnemy;
    private int _speed;
    public int speed;
    public bool isFacingLeft;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    BoxCollider2D _boxCollider2D;
    public ParticleSystem effectHealth;
    private Damageable _closeTarget;

    public GameObject goldIcon;
    private void Awake() {
        _animator = GetComponent<Animator>();
    }
    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _hpEnemy = hpEnemy;
        _speed = speed;
    }
    private void Update() {
        Move();
        
    }
    public void Move(){
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.GetPosPlayer(), _speed * Time.deltaTime);
        if(transform.position.x - PlayerController.instance.GetPosPlayer().x > 0)
        {
            _spriteRenderer.flipX = true;
        }else{
            _spriteRenderer.flipX = false;
        }
    }
    public void EnemyDie(){
        StartCoroutine(DieAnim());
        UIGameManager.instance.killed += 1;
        UIGameManager.instance.UpdateStat();
    }
    IEnumerator DieAnim(){
        _speed = 0;
        _animator.SetTrigger("Dead");
        _boxCollider2D.enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        GameObject gold = Instantiate(goldIcon, transform.position, Quaternion.identity);
        _hpEnemy = hpEnemy;
        _speed = speed;
        _boxCollider2D.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            effectHealth.Play();
            _hpEnemy -= Prefs.Attack;
            if(_hpEnemy <= 0)
            {
                EnemyDie();
            }
        }
        if(other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            _closeTarget = null;
        }
        if(other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("Attack", false);
        }
    }
    
}
