using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.InputSystem;

public class MyTest : MonoBehaviour
{
    public float Horzontal;
    public float Vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horzontal = InputManager.GetAxis("Horizontal");
        Vertical = InputManager.GetAxis("Vertical");
    }
}
