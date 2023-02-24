using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    [HideInInspector]
    public PlayerMain player;
    [HideInInspector]
    public EnemyAnimationStates enemyAnimationStates;

    [Header("STATUS INFO")]
    public float chaserDamage = 100f;
    public float cannonDamage = 50f;
    public float maxHealth;
    public string enemyType;

    [HideInInspector]
    public float health;
    private float healthBarScale;
    [SerializeField]
    private GameObject healthUI;

    public float scoreValue;

    private void Awake()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMain>();
        enemyAnimationStates = GetComponent<EnemyAnimationStates>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(enemyAnimationStates.OnDeath());
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBarScale = health / maxHealth;
        healthUI.transform.localScale = new Vector3(healthBarScale, healthUI.transform.localScale.y, 1f);
    }
}
