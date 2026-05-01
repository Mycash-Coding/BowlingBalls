using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MovementV4 : MonoBehaviour
{
    Rigidbody rig;
    readonly float magnitude = 5;
    readonly float jumpForce = 5;
    readonly float drag = 2;
    bool jumpRequested;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.linearDamping = drag;

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = new Color32(0, 204, 102, 255);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            jumpRequested = true;
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
            rig.AddForce(move.normalized * magnitude, ForceMode.VelocityChange);

        if (jumpRequested)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }
}