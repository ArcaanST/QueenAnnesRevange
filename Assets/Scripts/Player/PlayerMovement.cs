using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerMain player;

    private Vector2 moveVector;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMain>();
    }

    private void Update()
    {
        if (player != null)
        {
            Move();
            Rotate();
        }

        else
            return;
    }

    private void Move()
    {
        Vector2 input = player.inputManager.moveAction.ReadValue<Vector2>();
        moveVector = new Vector2(input.x, input.y);

        if (moveVector.sqrMagnitude > 1)
            moveVector = moveVector.normalized;

        player.playerRigidbody.velocity = new Vector2(moveVector.x * player.playerMoveSpeed, moveVector.y * player.playerMoveSpeed);
    }

    private void Rotate()
    {
        Vector2 input = player.inputManager.moveAction.ReadValue<Vector2>();
        if (input == Vector2.zero)
        {
            return;
        }

        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg + 90;
        var lookRotation = Quaternion.Euler(angle * Vector3.forward);
        transform.rotation = lookRotation;
    }
}
