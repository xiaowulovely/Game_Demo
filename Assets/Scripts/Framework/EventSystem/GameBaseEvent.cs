using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Framework.EventSystem
{
    public class GameBaseEvent
    {
        #region 事件名称
        private string m_EventName;
        public string name
        {
            get { return m_EventName; }
            protected set { m_EventName = value; }
        }
        #endregion

        #region 事件状态
        private bool m_Enable;
        public bool enable
        {
            get { return m_Enable; }
            set { m_Enable = value; }
        }
        #endregion
        public virtual void Update() { }
    }
}