using UnityEngine;

public class ColourOldSphere : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Find("Sphere (Old)").GetComponent<Renderer>().material.color = new Color(1.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
