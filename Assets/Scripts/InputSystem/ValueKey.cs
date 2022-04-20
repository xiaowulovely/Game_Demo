using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.InputSystem
{
    public class ValueKey
    {
        public string name;
        public Vector2 range;
        [HideInInspector]
        public float value;
        public float addSpeed;
        public KeyCode keyCode;
        public bool Enable { get; private set; }

        public void SetKey(KeyCode _keycode)
        {
            keyCode = _keycode;
        }

        public void SetEnable(bool _enable)
        {
            Enable = _enable;
        }
    }
}