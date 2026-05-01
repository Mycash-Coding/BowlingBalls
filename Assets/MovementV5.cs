using UnityEngine;
using UnityEngine.InputSystem;

public class MovementV5 : MonoBehaviour
{
    Rigidbody rig;
    readonly float magnitude = 10f; 
    readonly float jumpForce = 5f;
    readonly float drag = 2f;
    bool jumpRequested;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
        rig.linearDamping = drag;

        rig.freezeRotation = true;
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) move += transform.forward;
        if (Keyboard.current.sKey.isPressed) move -= transform.forward;
        if (Keyboard.current.aKey.isPressed) move -= transform.right;
        if (Keyboard.current.dKey.isPressed) move += transform.right;

        if (move != Vector3.zero)
        {
            // normalised ensures diagonal movement isn't faster
            rig.AddForce(move.normalized * magnitude, ForceMode.Acceleration);
        }

        if (jumpRequested)
        {
            // Reset vertical velocity before jumping for consistent height
            Vector3 vel = rig.linearVelocity;
            vel.y = 0;
            rig.linearVelocity = vel;

            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }
}