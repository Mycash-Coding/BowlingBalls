using UnityEngine;

public class ColourNewSphere : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Find("Sphere (New)").GetComponent<Renderer>().material.color = new Color(0, 1.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
