using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG.InputSystem
{
    [Serializable]
    public class InputSettingData
    {
        public List<KeyData> keys = new List<KeyData>();
        public List<ValueKeyData> valueKeys = new List<ValueKeyData>();
        public List<AxisData> axisKeys = new List<AxisData>();
    }
    [Serializable]
    public class KeyData
    {
        public string name;
        public string keyCode;
    }
    [Serializable]
    public class ValueKeyData
    {
        public string name;
        public string keyCode;
    }
    [Serializable]
    public class AxisData
    {
        public string name;
        public string posKeyCode;
        public string negKeyCode;
    }
}