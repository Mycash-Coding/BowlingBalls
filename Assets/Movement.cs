using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    Rigidbody rig;
    float magnitude=5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig=GetComponent<Rigidbody>();
        rig.AddForce(Vector3.forward*magnitude,ForceMode.Impulse);
    }


}