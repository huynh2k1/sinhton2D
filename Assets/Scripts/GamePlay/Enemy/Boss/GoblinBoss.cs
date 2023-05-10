using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBoss : MonoBehaviour
{
     public bool isDie;
    private int _hpEnemy;
    public int hpEnemy;
    public int atkEnemy;
    public int speed;
    SpriteRenderer _spriteRenderer;
    public bool isFacingLeft;
    public ParticleSystem effectHealth;
    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hpEnemy = hpEnemy;
        isDie = false;
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
        Destroy(gameObject);
        isDie = true;
        UIGameManager.instance.killed += 1;
        UIGameManager.instance.gold += 500;
        UIGameManager.instance.ruby += 200;
        UIGameManager.instance.UpdateStat();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            effectHealth.Play();
            _hpEnemy -= Prefs.Attack;
            if(_hpEnemy <= 0)
            {
                EnemyDie();
                GameManager.instance.Win();
            }
        }
    }
}
