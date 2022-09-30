using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG.Framework.InputSystem
{
    [Serializable]
    public class ValueKey
    {
        public string name;
        public Vector2 range;
        [HideInInspector]
        public float value;
        public float addSpeed;
        public KeyCode keyCode;
        public bool enable = true;

        public void SetKey(KeyCode _keycode)
        {
            keyCode = _keycode;
        }

        public void SetEnable(bool _enable)
        {
            enable = _enable;
        }
    }
}