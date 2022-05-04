using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.InputSystem;
using RPG.EventSystem;

public class MyTest : MonoBehaviour
{
    public float Horzontal;
    public float Vertical;
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.RegisterEvent("Event1", Check1);
        GameEventManager.RegisterEvent("Event2", Check2);

        GameEventManager.SubScribeEvent("Event1", Response1);
        GameEventManager.SubScribeEvent("Event2", Response2);
    }

    // Update is called once per frame
    void Update()
    {
        Horzontal = InputManager.GetAxis("Horizontal");
        Vertical = InputManager.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameEventManager.EnableEvent("Event2",false);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            GameEventManager.EnableEvent("Event2", true);
        }
    }

    private bool Check1(out object[] args)
    {
        args = new object[] { "AAA", "123" };
        return true;
    }

    private bool Check2(out object[] args)
    {
        args = new object[] { "ABC", "789","hello" };
        return true;
    }

    private void Response1(object[] args)
    {
        foreach (var item in args)
        {
            Debug.Log(item);
        }
    }

    private void Response2(object[] args)
    {
        foreach (var item in args)
        {
            Debug.Log(item);
        }
    }
}
