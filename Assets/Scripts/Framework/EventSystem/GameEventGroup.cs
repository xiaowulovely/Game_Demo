using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Framework.EventSystem
{
    public class GameEventGroup : GameBaseEvent
    {
        protected List<GameBaseEvent> m_Events;

        public GameEventGroup(string _eventName)
        {
            name = _eventName;
        }
        //向事件组中添加事件
        public void AddEvent(GameBaseEvent _event)
        {
            if(m_Events==null)
            {
                m_Events = new List<GameBaseEvent>();
            }
            //确保事件不会重复
            if(m_Events.Find(e=>e.name== _event.name)!=null)
            {
                return;
            }    
            m_Events.Add(_event);
        }
        //获取事件对象
        public GameBaseEvent GetEvent(string _eventName)
        {
            //BFS 广度优先搜索
            Queue<GameBaseEvent> que = new Queue<GameBaseEvent>();
            que.Enqueue(this);
            while(que.Count>0)
            {
                GameEventGroup temp = que.Dequeue() as GameEventGroup;
                if(temp!=null&&temp.m_Events!=null&&temp.m_Events.Count>0)
                {
                    var children = temp.m_Events;
                    foreach (GameBaseEvent eventItem in children)
                    {
                        if(eventItem.name == _eventName)
                        {
                            return eventItem;
                        }
                        que.Enqueue(eventItem);
                    }
                }
            }
            return null;
        }
        //启用/禁用所有事件
        public void EnableAllEvent(bool _enable)
        {
            enable = _enable;
            if (m_Events == null) return;

            foreach (GameBaseEvent eventItem in m_Events)
            {
                if(eventItem is GameEventGroup group)
                {
                    group.EnableAllEvent(_enable);
                }
                else
                {
                    eventItem.enable = _enable;
                }
            }
        }
        //移除事件
        public void RemoveEvent(string _eventName)
        {
            if (m_Events == null|| m_Events.Count==0) return;
            foreach (GameBaseEvent eventitem in m_Events)
            {
                if(eventitem.name == _eventName)
                {
                    m_Events.Remove(eventitem);
                    return;
                }
                else
                {
                    if(eventitem is GameEventGroup group)
                    {
                        group.RemoveEvent(_eventName);
                    }
                }
            }
        }

        public override void Update()
        {
            if (!enable|| m_Events == null || m_Events.Count == 0) return;

            for(int i=0;i< m_Events.Count;i++)
            {
                m_Events[i]?.Update();
            }
        }
    }
}