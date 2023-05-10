using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isDie;
    private int _hpEnemy;
    public int hpEnemy;
    public int atkBoss;
    private int _speed;
    public int speed;
    public bool isFacingLeft;
    public int goldBonus;
    public int rubyBonus;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    public HealthBar healthBar;
    public ParticleSystem effectHealth;
    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _hpEnemy = hpEnemy;
        _speed = speed;
        isDie = false;
        healthBar.UpdateHealthBar(_hpEnemy, hpEnemy);
    }
    private void Update() {
        Move();
        
    }
    public void Move(){
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.GetPosPlayer(), speed * Time.deltaTime);
        if(transform.position.x - PlayerController.instance.GetPosPlayer().x > 0)
        {
            _spriteRenderer.flipX = true;
        }else{
            _spriteRenderer.flipX = false;
        }
    }
    public void EnemyDie(){
        isDie = true;
        StartCoroutine(DieAnim());
        
    }
    IEnumerator DieAnim(){
        _speed = 0;
        _animator.SetTrigger("Dead");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        UIGameManager.instance.killed += 1;
        UIGameManager.instance.gold += goldBonus;
        UIGameManager.instance.ruby += rubyBonus;
        UIGameManager.instance.UpdateStat();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            effectHealth.Play();
            _hpEnemy -= Prefs.Attack;
            healthBar.UpdateHealthBar(_hpEnemy, hpEnemy);
            if(_hpEnemy <= 0)
            {
                EnemyDie();
                GameManager.instance.Win();

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
            _animator.SetBool("Attack", false);
        }
    }
}
