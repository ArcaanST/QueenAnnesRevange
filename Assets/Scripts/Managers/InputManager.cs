using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public InputAction moveAction;
    public InputAction attackAction;
    public InputAction changeCannon1;
    public InputAction changeCannon2;
    public InputAction changeCannon3;

    private void Awake()
    {
        playerInput = this.GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
        changeCannon1 = playerInput.actions["ChangeAbility1"];
        changeCannon2 = playerInput.actions["ChangeAbility2"];
        changeCannon3 = playerInput.actions["ChangeAbility3"];
    }
}
