using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MovementV2 : MonoBehaviour
{
    Rigidbody rig;
    readonly float magnitude = 5;
    readonly float jumpForce = 10;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null)
            return;

        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            move += transform.forward;

        if (Keyboard.current.sKey.isPressed)
            move -= transform.forward;

        if (Keyboard.current.aKey.isPressed)
            move -= transform.right;

        if (Keyboard.current.dKey.isPressed)
            move += transform.right;

        if (move != Vector3.zero)
            rig.AddForce(move.normalized * magnitude, ForceMode.Acceleration);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}