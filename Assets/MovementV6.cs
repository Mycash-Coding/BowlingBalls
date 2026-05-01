using UnityEngine;
using UnityEngine.InputSystem;

public class MovementV6 : MonoBehaviour
{
    Rigidbody rig;
    
    // Movement Constants
    readonly float magnitude = 10f; 
    readonly float jumpForce = 7f;
    readonly float drag = 2f;


    // Gravity Constants
    readonly float fallMultiplier = 2.5f;     // Makes falling feel heavy
    readonly float lowJumpMultiplier = 2.0f;  // Cuts the jump short if Space is released
    readonly float gravityStandard = 9.81f;
    readonly float groundCheckDistance = 1.1f;

    bool jumpRequested;

    bool IsGrounded()
    {
        // Checks with a line from the object's position downwards, if it hits anything within groundCheckDistance, object is grounded
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
        // Sets air resistance
        rig.linearDamping = drag;

        // Prevents the object from rolling over
        rig.freezeRotation = true;
    }

    void Update()
    {
        // Detect Jump Input and if object is grounded before allowing jump
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        Movement();
        StrongerGravity();
    }

    void Movement()
    {
        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) move += transform.forward;
        if (Keyboard.current.sKey.isPressed) move -= transform.forward;
        if (Keyboard.current.aKey.isPressed) move -= transform.right;
        if (Keyboard.current.dKey.isPressed) move += transform.right;

        if (move != Vector3.zero)
        {
            rig.AddForce(move.normalized * magnitude, ForceMode.Acceleration);
        }

        if (jumpRequested)
        {
            // Reset Y velocity for consistent jump height regardless of current fall speed
            Vector3 vel = rig.linearVelocity;
            vel.y = 0;
            rig.linearVelocity = vel;

            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    void StrongerGravity()
    {
        // 1. If falling: Apply extra downward force
        if (rig.linearVelocity.y < 0)
        {
            rig.AddForce(Vector3.down * (fallMultiplier * gravityStandard), ForceMode.Acceleration);
        }
        // 2. If rising but NOT holding Space: Apply extra force to stop the jump early (Short Hop)
        else if (rig.linearVelocity.y > 0 && !Keyboard.current.spaceKey.isPressed)
        {
            rig.AddForce(Vector3.down * (lowJumpMultiplier * gravityStandard), ForceMode.Acceleration);
        }
    }
}