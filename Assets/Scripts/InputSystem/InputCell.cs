using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace RPG.InputSystem
{
    public class InputCell : MonoBehaviour,IPointerClickHandler
    {
        public string keyName;
        public KeyType type;
        private Text keyCodedText;
        private Image keyCodeImage;
        private Action<KeyCode> setKey;

        

        private void Awake()
        {
            InputCellManager.AddCell(this);
            keyCodeImage = transform.Find("KeyBG_Image").GetComponent<Image>();
            keyCodedText = keyCodeImage.GetComponentInChildren<Text>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            keyCodedText.text = "Press key";
            switch (type)
            {
                case KeyType.Key:
                    setKey = key => InputManager.SetKey(keyName,key);
                    break;
                case KeyType.ValueKey:
                    setKey = key => InputManager.SetValueKey(keyName, key);
                    break;
                case KeyType.AxisPosKey:
                    setKey = key => InputManager.SetAxisPosKey(keyName, key);
                    break;
                case KeyType.AxisNegKey:
                    setKey = key => InputManager.SetAxisNegKey(keyName, key);
                    break;
                default:
                    break;
            }
            InputManager.StartSetKey(setKey,SetKeyText);
        }

        public void SetKeyText(KeyCode _keyCode)
        {
            keyCodedText.text = _keyCode.ToString();
        }
    }
}