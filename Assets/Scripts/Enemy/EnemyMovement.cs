using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("SPEED VARIABLES")]
    [SerializeField]
    private float speed, rotationSpeed;

    [Header("TYPES OF ENEMIES")]
    private EnemyCannon enemyCannon;
    private EnemyMain enemyMain;

    private Rigidbody2D enemyRigidbody;
    private Transform playerTransform;
    private Vector2 targetDirection;
    private Vector2 distanceFromPlayer;

    private Quaternion rotationInfo;
    [SerializeField]
    private Transform raycastPos;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyCannon = GetComponent<EnemyCannon>();
        enemyMain = GetComponent<EnemyMain>();
    }

    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        ObstacleAvoid();
    }

    void UpdateTargetDirection()
    {
        distanceFromPlayer = playerTransform.position - transform.position;
        targetDirection = - distanceFromPlayer.normalized;
    }

    void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rotationInfo = rotation;

        enemyRigidbody.SetRotation(rotationInfo);
    }

    void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
            enemyRigidbody.velocity = Vector2.zero;

        //Shooter enemy
        if(enemyMain.enemyType == "Shooter")
        {
            if (enemyMain.enemyType == "Shooter" && Vector3.Distance(playerTransform.position, transform.position) >= 4f)
            {
                enemyRigidbody.velocity = transform.up * -speed;
            }
            else if (enemyMain.enemyType == "Shooter" && Vector3.Distance(playerTransform.position, transform.position) <= 4f)
            {
                enemyRigidbody.velocity = Vector2.zero;
            }
            if (enemyMain.enemyType == "Shooter" && Vector3.Distance(playerTransform.position, transform.position) <= 5.5f)
            {
                if (enemyCannon != null && Time.time > enemyCannon.attackTimer)
                {
                    enemyCannon.Shot(rotationInfo *= Quaternion.Euler(0, 0, -90));
                }
            }
        }

        //Chaser enemy
        if(enemyMain.enemyType == "Chaser")
            enemyRigidbody.velocity = transform.up * -speed;
    }

    void ObstacleAvoid()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastPos.position, - targetDirection);
        if (hit.collider.tag == "Wall") 
        {
            transform.Rotate(0, 0, -90 * Time.deltaTime);
            enemyRigidbody.velocity = transform.up * -speed;
        }

        else
        {
            enemyRigidbody.velocity = transform.up * -speed;
        }
    }
}