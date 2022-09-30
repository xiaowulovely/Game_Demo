using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Framework.EventSystem
{
    public class GameEvent : GameBaseEvent
    {
        public delegate bool CheckHandle(out object[] args);
        private CheckHandle m_CheckHandle;

        public delegate void ResponseHandle(params object[] args);
        private ResponseHandle m_ResponseHandle;

        //订阅事件接受的参数
        protected object[] args;

        public GameEvent(string _eventName)
        {
            name = _eventName;
        }

        public override void Update()
        {
            if (!enable) return;

            if(m_CheckHandle!=null&& m_CheckHandle(out args))
            {
                if(m_ResponseHandle!=null)
                {
                    m_ResponseHandle(args);
                }
            }
        }
        //添加检测方法
        public void AddCheckHandle(CheckHandle _checkHandle)
        {
            m_CheckHandle += _checkHandle;
        }
        //移除检测方法
        public void RemoveCheckHandle(CheckHandle _checkHandle)
        {
            m_CheckHandle -= _checkHandle;
        }
        //添加订阅事件
        public void AddResponseHandle(ResponseHandle _responseHandle)
        {
            m_ResponseHandle += _responseHandle;
        }
        //移除订阅事件
        public void RemoveResponseHandle(ResponseHandle _responseHandle)
        {
            m_ResponseHandle -= _responseHandle;
        }
    }
}