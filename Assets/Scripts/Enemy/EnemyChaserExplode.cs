using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserExplode : MonoBehaviour
{
    EnemyMain meEnemy;

    private void Awake()
    {
        meEnemy = GetComponent<EnemyMain>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            meEnemy.player.TakeDamage(meEnemy.chaserDamage);
            meEnemy.TakeDamage(100f);
        }
    }
}