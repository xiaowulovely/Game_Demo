using System;
using UnityEngine;

namespace RPG.InputSystem
{
    [Serializable]
    public class Key
    {
        public string name;
        public KeyTrigger trigger;
        public bool isDown;
        public bool isDoubleDown;
        public bool acceptDoubleDown;

        public float pressInterval = 0.3f;
        public float realInterval;
        public KeyCode keyCode;

        public bool Enable { get; private set; }
        
        /// <summary>
        /// 设置按键
        /// </summary>
        /// <param name="_keycode">按键</param>
        public void SetKey(KeyCode _keycode)
        {
            keyCode = _keycode;
        }
        /// <summary>
        /// 启用/禁用按键
        /// </summary>
        /// <param name="_enable"></param>
        public void SetEnable(bool _enable)
        {
            Enable = _enable;
        }
    }
}