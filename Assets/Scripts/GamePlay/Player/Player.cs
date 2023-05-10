using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float health;
    public int attack;
    private Damageable _closeTarget;
    public float damageTime;
    private float _damageTime;
    Enemy _enemy;
    Boss _boss;
    public HealthBar healthBar;
    private void Start() {
        health = Prefs.Health;
        attack = Prefs.Attack;
        _damageTime = damageTime;
        Debug.Log("máu: " + health);
        Debug.Log("tấn công: " + attack);
        healthBar.UpdateHealthBar(health, Prefs.Health);
        UpdateTextStat();
    }
    private void Update() {
        _enemy = FindObjectOfType<Enemy>();
        _boss = FindObjectOfType<Boss>();
        if(_closeTarget)
        {
            _damageTime += Time.deltaTime;
            if(_damageTime >= damageTime)
            {
                if(_enemy)
                {
                    health -= _enemy.atkEnemy;
                    healthBar.UpdateHealthBar(health, Prefs.Health);
                    UpdateTextStat();
                    Debug.Log(health);
                    _damageTime = 0;
                }
                if(_boss)
                {
                    health -= _boss.atkBoss;
                    healthBar.UpdateHealthBar(health, Prefs.Health);
                    UpdateTextStat();
                    Debug.Log(health);
                    _damageTime = 0;
                }
                
            }
        }
        if(health <= 0)
        {
            Debug.Log("Da chet");
            GameManager.instance.Lose();
            gameObject.SetActive(false);
            return;
        }
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {
    //         if(other.gameObject.TryGetComponent<Damageable>(out var damageable))
    //         {
    //             _closeTarget = damageable;
    //         }
    //     }
    // }
    private void UpdateTextStat(){
        UIGameManager.instance.hpText.text = "HP : " + health.ToString() + "/" + Prefs.Health.ToString();
        UIGameManager.instance.atkText.text = "ATK : " + attack.ToString();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject.TryGetComponent<Damageable>(out var damageable))
            {
                _closeTarget = damageable;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            _closeTarget = null;
        }
    }
}
