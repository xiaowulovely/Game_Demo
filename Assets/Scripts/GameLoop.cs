using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Framework.InputSystem;
using RPG.Framework.EventSystem;

public class GameLoop : MonoBehaviour
{
    public InputData InputData = new InputData();

    private InputManager m_InputManager;

    void Start()
    {
        m_InputManager = new InputManager(InputData);
    }

    // Update is called once per frame
    void Update()
    {
        m_InputManager.Update();
        GameEventManager.Update();
    }
}
