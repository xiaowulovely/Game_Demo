using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace RPG.Framework.InputSystem
{
    [Serializable]
    public class InputData
    {
        public const string AxisPos = "Pos";
        public const string AxisNeg = "Neg";

        [SerializeField] private List<Key> keys = new List<Key>();
        [SerializeField] private List<ValueKey> valueKeys = new List<ValueKey>();
        [SerializeField] private List<AxisKey> axisKeys = new List<AxisKey>();

        /// <summary>
        /// ��ʹ�ù��ļ�
        /// </summary>
        //private List<KeyCode> m_UsedKeys = new List<KeyCode>();
        private Dictionary<string, KeyCode> m_UsedKeys = new Dictionary<string, KeyCode>();

        /// <summary>
        /// ���ݼ�λ����ȡ��λ����
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public Key GetKeyObject(string _name)
        {
            return keys.Find(k => k.name == _name);
        }
        /// <summary>
        /// ���ݼ�λ����ȡ��λ����
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <returns></returns>
        public ValueKey GetValueKeyObject(string _name)
        {
            return valueKeys.Find(k => k.name == _name);
        }
        /// <summary>
        /// ���ݼ�λ����ȡ�����λ����
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <returns></returns>
        public AxisKey GetAxisKeyObject(string _name)
        {
            return axisKeys.Find(k => k.name == _name);
        }

        /// <summary>
        /// ���Ҫ���õİ����Ƿ�ʹ�ù�
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        private bool CheckKeyCanBeUse(KeyCode keyCode)
        {
            return !m_UsedKeys.ContainsValue(keyCode);
        }

        private void AddUsedKey(string key,KeyCode keycode)
        {
            if (m_UsedKeys.ContainsKey(key))
            {
                m_UsedKeys[key] = keycode;
            }
            else
            {
                m_UsedKeys.Add(key, keycode);
            }
        }

        /// <summary>
        /// ���ü�λ��Ӧ�ļ��̰���
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <param name="_keyCode">���̰���</param>
        public bool SetKey(string _name,KeyCode _keyCode)
        {
            Key key = GetKeyObject(_name);
            if(key==null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            if (!CheckKeyCanBeUse(_keyCode))
            {
                Debug.Log($"{_keyCode}�ѱ�ʹ��");
                return false;
            }
            AddUsedKey(_name, _keyCode);
            key.SetKey(_keyCode);
            return true;
        }
        /// <summary>
        /// �������ּ�λ��Ӧ�ļ��̰���
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <param name="_keyCode">��ũ������</param>
        public bool SetValueKey(string _name,KeyCode _keyCode)
        {
            ValueKey valueKey = GetValueKeyObject(_name);
            if(valueKey==null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            if (!CheckKeyCanBeUse(_keyCode))
            {
                Debug.Log($"{_keyCode}�ѱ�ʹ��");
                return false;
            }
            AddUsedKey(_name, _keyCode);
            valueKey.SetKey(_keyCode);
            return true;
        }
        /// <summary>
        /// ���÷����λ��Ӧ�ļ��̰���
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <param name="_posKeyCode">����</param>
        /// <param name="_negKeyCode">����</param>
        public bool SetAxisKey(string _name,KeyCode _posKeyCode,KeyCode _negKeyCode)
        {
            AxisKey axisKey = GetAxisKeyObject(_name);
            if(axisKey==null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            if (!CheckKeyCanBeUse(_posKeyCode)&& !CheckKeyCanBeUse(_negKeyCode))
            {
                Debug.Log($"{_posKeyCode}��{_negKeyCode}�ѱ�ʹ��");
                return false;
            }
            AddUsedKey(_name + InputData.AxisPos, _posKeyCode);
            AddUsedKey(_name + InputData.AxisNeg, _negKeyCode);
            axisKey.SetKey(_posKeyCode,_negKeyCode);
            return true;
        }

        public bool SetAxisPosKey(string _name,KeyCode _posKeyCode)
        {
            AxisKey axisKey = GetAxisKeyObject(_name);
            if (axisKey == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            if (!CheckKeyCanBeUse(_posKeyCode))
            {
                Debug.Log($"{_posKeyCode}�ѱ�ʹ��");
                return false;
            }
            AddUsedKey(_name + InputData.AxisPos, _posKeyCode);
            axisKey.SetPosKey(_posKeyCode);
            return true;
        }
        public bool SetAxisNegKey(string _name, KeyCode _negKeyCode)
        {
            AxisKey axisKey = GetAxisKeyObject(_name);
            if (axisKey == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            if (!CheckKeyCanBeUse(_negKeyCode))
            {
                Debug.Log($"{_negKeyCode}�ѱ�ʹ��");
                return false;
            }
            AddUsedKey(_name + InputData.AxisNeg, _negKeyCode);
            axisKey.SetNegKeey(_negKeyCode);
            return true;
        }
        /// <summary>
        /// ��ȡ��λ����
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <returns></returns>
        public bool GetKeyDown(string _name)
        {
            Key key = GetKeyObject(_name);
            if(key==null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            return key.isDown;
        }
        /// <summary>
        /// ��ȡ��λ˫��
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <returns></returns>
        public bool GetKeyDownTwince(string _name)
        {
            Key key = GetKeyObject(_name);
            if (key == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return false;
            }
            return key.isDoubleDown;
        }

        public float GetValue(string _name)
        {
            ValueKey valueKey = GetValueKeyObject(_name);
            if (valueKey == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return 0;
            }

            return valueKey.value;
        }
        /// <summary>
        /// ��ȡ���������ֵ
        /// </summary>
        /// <param name="_name">�������</param>
        /// <returns></returns>
        public float GetAxis(string _name)
        {
            AxisKey axisKey = GetAxisKeyObject(_name);
            if(axisKey == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return 0;
            }
            return axisKey.value;
        }
        /// <summary>
        /// ���ü�λ�����û�ͣ��
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <param name="_enable">trueΪ���ã�falseΪ����</param>
        public void SetKeyEnable(string _name,bool _enable)
        {
            Key key = GetKeyObject(_name);
            if(key ==null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return;
            }
            key.SetEnable(_enable);
        }
        /// <summary>
        /// ���ü�λ�����û�ͣ��
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <param name="_enable">trueΪ���ã�falseΪ����</param>
        public void SetValueEnable(string _name,bool _enable)
        {
            ValueKey valueKey = GetValueKeyObject(_name);
            if(valueKey == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return;
            }
            valueKey.SetEnable(_enable);
        }
        /// <summary>
        /// ���ü�λ�����û�ͣ��
        /// </summary>
        /// <param name="_name">��λ��</param>
        /// <param name="_enable">trueΪ���ã�falseΪ����</param>
        public void SetAxisEnable(string _name,bool _enable)
        {
            AxisKey axisKey = GetAxisKeyObject(_name);
            if(axisKey == null)
            {
                Debug.LogError("Can not find the key!Please check the name again!");
                return;
            }
            axisKey.SetEnable(_enable);
        }

        public void AcceptUpdate()
        {
            KeyUpdate();
            ValueKeyUpdate();
            AxisKeyUpdate();
        }

        private void KeyUpdate()
        {
            for(int i=0;i<keys.Count;i++)
            {
                if(keys[i].enable)
                {
                    keys[i].isDown = false;
                    keys[i].isDoubleDown = false;
                    switch (keys[i].trigger)
                    {
                        case KeyTrigger.Once:
                            if(Input.GetKeyDown(keys[i].keyCode))
                            {
                                keys[i].isDown = true;
                            }
                            break;
                        case KeyTrigger.Double:
                            if(keys[i].acceptDoubleDown)
                            {
                                keys[i].realInterval += Time.deltaTime;
                                if (keys[i].realInterval> keys[i].pressInterval)
                                {
                                    keys[i].acceptDoubleDown = false;
                                    keys[i].isDoubleDown = false;
                                }
                                else
                                {
                                    if (Input.GetKeyDown(keys[i].keyCode))
                                    {
                                        keys[i].isDoubleDown = true;
                                        keys[i].acceptDoubleDown = false;
                                    }
                                    else if (Input.GetKeyUp(keys[i].keyCode))
                                    {
                                        keys[i].acceptDoubleDown = false;
                                    }
                                }       
                            }
                            else
                            {
                                if(Input.GetKeyDown(keys[i].keyCode))
                                {
                                    keys[i].acceptDoubleDown = true;
                                    keys[i].realInterval = 0f;
                                }
                            }
                            break;
                        case KeyTrigger.Continuity:
                            if(Input.GetKey(keys[i].keyCode))
                            {
                                keys[i].isDown = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        private void ValueKeyUpdate()
        {
            for(int i =0;i<valueKeys.Count;i++)
            {
                if (valueKeys[i].enable)
                {
                    if (Input.GetKey(valueKeys[i].keyCode))
                    {
                        valueKeys[i].value = Mathf.Clamp(valueKeys[i].value += valueKeys[i].addSpeed * Time.deltaTime, valueKeys[i].range.x, valueKeys[i].range.y);
                    }
                    else
                    {
                        valueKeys[i].value = Mathf.Clamp(valueKeys[i].value -= valueKeys[i].addSpeed * Time.deltaTime, valueKeys[i].range.x, valueKeys[i].range.y);
                    }
                }
            }
        }

        private void AxisKeyUpdate()
        {
            for (int i = 0; i < axisKeys.Count; i++)
            {
                if(axisKeys[i].enable)
                {
                    if(Input.GetKey(axisKeys[i].posKeyCode))
                    {
                        axisKeys[i].value = Mathf.Clamp(axisKeys[i].value + axisKeys[i].addSpeed*Time.deltaTime,axisKeys[i].range.x,axisKeys[i].range.y);
                    }
                    else if(Input.GetKey(axisKeys[i].negKeyCode))
                    {
                        axisKeys[i].value = Mathf.Clamp(axisKeys[i].value - axisKeys[i].addSpeed * Time.deltaTime, axisKeys[i].range.x, axisKeys[i].range.y);
                    }
                    else
                    {
                        axisKeys[i].value = Mathf.Lerp(axisKeys[i].value, 0f,axisKeys[i].addSpeed*Time.deltaTime);
                        if(Mathf.Abs(axisKeys[i].value)<0.01f)
                        {
                            axisKeys[i].value = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �����������÷���
        /// </summary>
        /// <param name="_path">�ļ�����·��</param>
        public void SaveInputSetting(string _path)
        {
            InputSettingData inputSettingData = new InputSettingData();
            foreach (var key in keys)
            {
                KeyData keyData = new KeyData();
                keyData.name = key.name;
                keyData.keyCode = key.keyCode.ToString();
                inputSettingData.keys.Add(keyData);
            }
            foreach (var valueKey in valueKeys)
            {
                ValueKeyData valueKeyData = new ValueKeyData();
                valueKeyData.name = valueKey.name;
                valueKeyData.keyCode = valueKey.keyCode.ToString();
                inputSettingData.valueKeys.Add(valueKeyData);
            }
            foreach (var axisKey in axisKeys)
            {
                AxisData axisData = new AxisData();
                axisData.name = axisKey.name;
                axisData.posKeyCode = axisKey.posKeyCode.ToString();
                axisData.negKeyCode = axisKey.negKeyCode.ToString();
                inputSettingData.axisKeys.Add(axisData);
            }
            string ISD = JsonUtility.ToJson(inputSettingData);
            //Debug.Log(ISD);
            string filePath = Application.dataPath + _path;
            FileInfo file = new FileInfo(filePath);
            StreamWriter sw = file.CreateText();
            sw.WriteLine(ISD);
            sw.Close();
            sw.Dispose();
        }
        /// <summary>
        /// �����������÷���
        /// </summary>
        /// <param name="_path">�ļ�����·��</param>
        public void LoadInputSetting(string _path)
        {
            string filePath = Application.dataPath + _path;
            if (!File.Exists(filePath)) return;

            string data = File.ReadAllText(filePath);
            InputSettingData inputSettingData = new InputSettingData();
            JsonUtility.FromJsonOverwrite(data, inputSettingData);
            foreach (var key in keys)
            {
                KeyCode keycode = String2Enum_KeyCoded(inputSettingData.keys.Find(k => k.name == key.name).keyCode);
                SetKey(key.name, keycode);
            }
            foreach (var valueKey in valueKeys)
            {
                KeyCode keycode = String2Enum_KeyCoded(inputSettingData.valueKeys.Find(k => k.name == valueKey.name).keyCode);
                SetValueKey(valueKey.name, keycode);
            }
            foreach (var axisKey in axisKeys)
            {
                AxisData axisData = inputSettingData.axisKeys.Find(k => k.name == axisKey.name);
                SetAxisKey(axisKey.name, String2Enum_KeyCoded(axisData.posKeyCode), String2Enum_KeyCoded(axisData.negKeyCode));
            }

        }

        //���ַ�������ת���ɰ���ö������
        private KeyCode String2Enum_KeyCoded(string _keycCode)
        {
            return (KeyCode)Enum.Parse(typeof(KeyCode),_keycCode);
        }
    }
}