using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldBonus;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            UIGameManager.instance.gold += goldBonus;
            UIGameManager.instance.UpdateStat();
            AudioManager.instance.PlaySFX("Coin");
            Destroy(gameObject);
        }
    }
}
