using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    private float attackCooldown = 0.7f;
    private float attackTimer;
    [HideInInspector]
    public float ability = 1;

    private Vector3 spawnPosition;

    PlayerMain player;

    private void Awake()
    {
        player = GetComponent<PlayerMain>();        
    }

    void Update()
    {
        AbilityOptions();

        if(Time.time > attackTimer)
        {
            ShootController();
        }
    }

    void AbilityOptions()
    {
        float abilityInput1 = player.inputManager.changeCannon1.ReadValue<float>();
        if (abilityInput1 != 0)
            ability = 1;

        float abilityInput2 = player.inputManager.changeCannon2.ReadValue<float>();
        if (abilityInput2 != 0)
            ability = 2;

        float abilityInput3 = player.inputManager.changeCannon3.ReadValue<float>();
        if (abilityInput3 != 0)
            ability = 3;
    }

    void ShootController()
    {
        if (ability == 1)
            FrontalShot();

        else if (ability == 2)
            LateralRightShot();


        else if (ability == 3)
            LateralLeftShot();
        
    }

    void FrontalShot()
    {
        float input = player.inputManager.attackAction.ReadValue<float>();

        if (player.bulletSpeed < 0)
            player.bulletSpeed *= -1;

        if (input != 0)
        {
            StartCoroutine(player.playerAnimationState.OnExplosionFrontal());

            spawnPosition = player.bulletSpawnFrontal.position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnFrontal.rotation);

            attackTimer = Time.time + attackCooldown;
        }
    }

    void LateralLeftShot()
    {
        float input = player.inputManager.attackAction.ReadValue<float>();

        if (player.bulletSpeed < 0)
            player.bulletSpeed *= -1;

        if (input != 0)
        {
            StartCoroutine(player.playerAnimationState.OnExplosionLeft());

            spawnPosition = player.bulletSpawnLateralLeft[0].position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnLateralLeft[0].rotation);

            spawnPosition = player.bulletSpawnLateralLeft[1].position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnLateralLeft[1].rotation);

            spawnPosition = player.bulletSpawnLateralLeft[2].position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnLateralLeft[2].rotation);

            attackTimer = Time.time + attackCooldown;
        }
    }

    void LateralRightShot()
    {
        float input = player.inputManager.attackAction.ReadValue<float>();

        if (player.bulletSpeed > 0)
            player.bulletSpeed *= -1;

        if (input != 0)
        {
            StartCoroutine(player.playerAnimationState.OnExplosionRight());

            spawnPosition = player.bulletSpawnLateralRight[0].position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnLateralRight[0].rotation);

            spawnPosition = player.bulletSpawnLateralRight[1].position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnLateralRight[1].rotation);

            spawnPosition = player.bulletSpawnLateralRight[2].position;
            Instantiate(player.bulletPrefab, spawnPosition, player.bulletSpawnLateralRight[2].rotation);

            attackTimer = Time.time + attackCooldown;
        }
    }
}