using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    EnemyMain meEnemy;

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private GameObject enemyBulletPrefab;

    private float attackCooldown = 0.7f;
    [HideInInspector]
    public float attackTimer;

    private void Awake()
    {
        meEnemy = GetComponent<EnemyMain>();
    }

    public void Shot(Quaternion rotation)
    {
        StartCoroutine(meEnemy.enemyAnimationStates.OnExplosionFrontal());
        GameObject currentBullet = Instantiate(enemyBulletPrefab, spawnPosition.position, rotation);
        
        currentBullet.GetComponent<EnemyBullet>().bulletDamage = meEnemy.cannonDamage;

        attackTimer = Time.time + attackCooldown;
    }
}
