using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MovementV1 : MonoBehaviour
{
    Rigidbody rig;
    float magnitude = 5;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("W pressed");
            rig.AddForce(transform.forward * magnitude, ForceMode.Impulse);
        }
    }
}