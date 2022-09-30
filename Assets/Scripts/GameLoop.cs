using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Framework.InputSystem;
using RPG.Framework.EventSystem;

public class GameLoop : MonoBehaviour
{
    #region 单例

    private static GameLoop m_Instance;

    void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [Header("输入系统")]
    [SerializeField] private InputData InputData = new InputData();

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
