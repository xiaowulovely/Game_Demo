using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.InputSystem
{
    public class AxisKey
    {
        public string name;
        public Vector2 range;
        [HideInInspector]
        public float value;
        public float addSpeed;
        //�������
        public KeyCode posKeyCode;
        //�������
        public KeyCode negKeyCode;

        public bool Enable { get; private set; }

        public void SetKey(KeyCode _posKeyCode,KeyCode _negKeyCode)
        {
            this.posKeyCode = _posKeyCode;
            this.negKeyCode = _negKeyCode;
        }

        public void SetPosKey(KeyCode _posKeyCode)
        {
            this.posKeyCode = _posKeyCode;
        }

        public void SetNegKeey(KeyCode _negKeyCode)
        {
            this.negKeyCode = _negKeyCode;
        }
        /// <summary>
        /// ����/���ü�λ
        /// </summary>
        /// <param name="_enable"></param>
        public void SetEnable(bool _enable)
        {
            Enable = _enable;
        }
    }
}