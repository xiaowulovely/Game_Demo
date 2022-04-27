using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG.InputSystem
{
    public class InputManager
    {
        private static string m_DefaultDataSavePath = "/Resources/UserData/DefaultInputData.json";
        private static string m_CustomDataSavePath = "/Resources/UserData/CustomInputData.json";
        private static InputData m_InputData;
        private static bool m_ActiveInput = false;
        private static Action<KeyCode> SetKeyHandle;
        private static Action<KeyCode> DisplayKeyHandle;

        public InputManager(InputData _inputData)
        {
            m_InputData = _inputData;
            SaveDefaultSetting();
            LoadDefaultSetting();
        }

        public void Update()
        {
            m_InputData.AcceptUpdate();
            if(m_ActiveInput)
            {
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if(Input.GetKeyDown(key))
                    {
                        if(SetKeyHandle!=null)
                        {
                            SetKeyHandle(key);
                        }
                        if(DisplayKeyHandle!=null)
                        {
                            DisplayKeyHandle(key);
                        }
                        m_ActiveInput = false;
                        SetKeyHandle = null;
                        DisplayKeyHandle = null;
                    }
                }
            }
        }
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static bool GetKey(string _name)
        {
            return m_InputData.GetKeyDown(_name);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static bool GetKeyDown(string _name)
        {
            return m_InputData.GetKeyDown(_name);
        }
        /// <summary>
        /// ����˫��
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static bool GetKeyDownTwice(string _name)
        {
            return m_InputData.GetKeyDownTwince(_name);
        }
        /// <summary>
        /// ��ֵ��
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static float GetValue(string _name)
        {
            return m_InputData.GetValue(_name);
        }
        /// <summary>
        /// �����
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static float GetAxis(string _name)
        {
            return m_InputData.GetAxis(_name);
        }
        /// <summary>
        /// ���ü�λ��Ӧ�ļ��̰���
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_keyCode"></param>
        public static void SetKey(string _name,KeyCode _keyCode)
        {
            m_InputData.SetKey(_name,_keyCode);
        }
        /// <summary>
        /// �������ּ���Ӧ�ļ��̰���
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_keyCode"></param>
        public static void SetValueKey(string _name,KeyCode _keyCode)
        {
            m_InputData.SetValueKey(_name,_keyCode);
        }
        /// <summary>
        /// ���÷������Ӧ�ļ��̰���
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_posKeyCode"></param>
        /// <param name="_negKeyCode"></param>
        public static void SetAxisKey(string _name,KeyCode _posKeyCode,KeyCode _negKeyCode)
        {
            m_InputData.SetAxisKey(_name, _posKeyCode, _negKeyCode);
        }
        /// <summary>
        /// ���÷������������̰���
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_posKeyCode"></param>
        public static void SetAxisPosKey(string _name,KeyCode _posKeyCode)
        {
            m_InputData.SetAxisPosKey(_name, _posKeyCode);
        }
        /// <summary>
        /// ���÷�����ĸ�����̰���
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_negKeyCode"></param>
        public static void SetAxisNegKey(string _name,KeyCode _negKeyCode)
        {
            m_InputData.SetAxisNegKey(_name,_negKeyCode);
        }
        /// <summary>
        /// ��ʼ���ü�λ
        /// </summary>
        /// <param name="setKey"></param>
        /// <param name="displayKey"></param>
        public static void StartSetKey(Action<KeyCode> setKey, Action<KeyCode> displayKey)
        {
            m_ActiveInput = true;
            SetKeyHandle = setKey;
            DisplayKeyHandle = displayKey;
        }
        /// <summary>
        /// ����Ĭ�ϰ�������
        /// </summary>
        public static void SaveDefaultSetting()
        {
            m_InputData.SaveInputSetting(m_DefaultDataSavePath);
        }
        /// <summary>
        /// ����Ĭ�ϼ�λ����
        /// </summary>
        public static void LoadDefaultSetting()
        {
            m_InputData.LoadInputSetting(m_DefaultDataSavePath);
        }
        /// <summary>
        /// ������˰�������
        /// </summary>
        public static void SaveCustomSetting()
        {
            m_InputData.SaveInputSetting(m_CustomDataSavePath);
        }
        /// <summary>
        /// ���ظ��˰�������
        /// </summary>
        public static void LoadCustomSetting()
        {
            m_InputData.LoadInputSetting(m_CustomDataSavePath);
        }
        /// <summary>
        /// ��ȡ�����ļ��̼�
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static KeyCode GetKeyCode(string _name)
        {
            Key key = m_InputData.GetKeyObject(_name);
            if(key!=null)
            {
                return key.keyCode;
            }
            return KeyCode.None;
        }
        /// <summary>
        /// ��ȡ��ֵ���ļ��̼�
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static KeyCode GetValueKeyCode(string _name)
        {
            ValueKey valueKey = m_InputData.GetValueKeyObject(_name);
            if(valueKey!=null)
            {
                return valueKey.keyCode;
            }
            return KeyCode.None;
        }
        /// <summary>
        /// ��ȡ������̼�
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static KeyCode GetAxisPosKeyCode(string _name)
        {
            AxisKey axisKey = m_InputData.GetAxisKeyObject(_name);
            if(axisKey!=null)
            {
                return axisKey.posKeyCode;
            }
            return KeyCode.None;
        }
        /// <summary>
        /// ��ȡ������̼�
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static KeyCode GetAxisNegKeyCode(string _name)
        {
            AxisKey axisKey = m_InputData.GetAxisKeyObject(_name);
            if(axisKey!=null)
            {
                return axisKey.negKeyCode;
            }
            return KeyCode.None;
        }

    }
}