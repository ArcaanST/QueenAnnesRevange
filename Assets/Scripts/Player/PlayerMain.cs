using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float playerMoveSpeed = 5f;

    [Header("BULLET SPAWN")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnFrontal;
    public Transform[] bulletSpawnLateralLeft;
    public Transform[] bulletSpawnLateralRight;
    public float bulletSpeed;
    public float bulletDamage;

    [Header("STATUS INFO")]
    public float radius;
    public float maxHealth = 1000f;
    [HideInInspector]
    public float health;
    private float healthBarScale;
    [SerializeField]
    private GameObject healthUI;

    [HideInInspector]
    public Rigidbody2D playerRigidbody;
    [HideInInspector]
    public Transform playerTransform;
    [HideInInspector]
    public InputManager inputManager;
    [HideInInspector]
    public PlayerAnimatonStates playerAnimationState;
    [HideInInspector] 
    public static PlayerMain playerMainInstance;

    private void Awake()
    {
        health = maxHealth;
        Time.timeScale = 1;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        playerAnimationState = GetComponent<PlayerAnimatonStates>();

        GameManager.gameManagerInstance.inGame = true;

        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(playerAnimationState.OnDeath());
        }

        else if(health > 0 && GameManager.gameManagerInstance.CurrentTime <= 0)
        {
            UIManager.uiManagerInstance.YouWin();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        healthBarScale = health / maxHealth;
        healthUI.transform.localScale = new Vector3(healthBarScale, healthUI.transform.localScale.y, 1f);
    }
}
