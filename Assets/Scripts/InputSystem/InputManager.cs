using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG.InputSystem
{
    public class InputManager
    {
        private string m_DefaultDataSavePath;
        private string m_CustomDataSavePath;
        private InputData m_InputData;
        private bool m_ActiveInput = true;
        private Action<KeyCode> SetKeyHandle;
        private Action<KeyCode> DisplayKeyHandle;

        public InputManager(InputData _inputData)
        {
            m_InputData = _inputData;
        }

        public void Update()
        {
            if (!m_ActiveInput) return;
            m_InputData.AcceptUpdate();
        }

        public bool GetKey(string _name)
        {
            return m_InputData.GetKeyDown(_name);
        }

        public bool GetKeyDown(string _name)
        {
            return m_InputData.GetKeyDown(_name);
        }

        public bool GetKeyDownTwice(string _name)
        {
            return m_InputData.GetKeyDownTwince(_name);
        }

        public float GetValue(string _name)
        {
            return m_InputData.GetValue(_name);
        }

        public float GetAxis(string _name)
        {
            return m_InputData.GetAxis(_name);
        }

        public void SetKey(string _name,KeyCode _keyCode)
        {
            m_InputData.SetKey(_name,_keyCode);
        }

        public void SetValueKey(string _name,KeyCode _keyCode)
        {
            m_InputData.SetValueKey(_name,_keyCode);
        }

        public void SetAxisKey(string _name,KeyCode _posKeyCode,KeyCode _negKeyCode)
        {
            m_InputData.SetAxisKey(_name, _posKeyCode, _negKeyCode);
        }

        public void SetAxisPosKey(string _name,KeyCode _posKeyCode)
        {
            m_InputData.SetAxisPosKey(_name, _posKeyCode);
        }

        public void SetAxisNegKey(string _name,KeyCode _negKeyCode)
        {
            m_InputData.SetAxisNegKey(_name,_negKeyCode);
        }


    }
}