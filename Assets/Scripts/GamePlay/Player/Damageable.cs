using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    
    public void TakeDamage(int damage)
    {
        Debug.Log("Take damage: " + damage);
    }
}
