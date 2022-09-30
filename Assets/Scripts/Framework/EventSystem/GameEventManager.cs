using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Framework.EventSystem
{
    public class GameEventManager
    {
        private static GameEventGroup m_root;
        public static GameEventGroup RootGroup
        {
            get
            {
                return m_root;
            }
            set
            {
                m_root = value;
            }
        }

        static GameEventManager()
        {
            Init();
        }
        //初始化
        private static void Init()
        {
            m_root = new GameEventGroup("Root");

            GameEvent evnet_1 = new GameEvent("Event1");
            GameEvent event_2 = new GameEvent("Event2");
            GameEventGroup group_1 = new GameEventGroup("Group1");
            group_1.AddEvent(evnet_1);
            group_1.AddEvent(event_2);

            m_root.AddEvent(group_1);
            m_root.enable = true;
            m_root.EnableAllEvent(true);
        }

        public static void RegisterEvent(string _eventName,GameEvent.CheckHandle _check)
        {
            GameBaseEvent gameEvent = m_root?.GetEvent(_eventName);
            if(gameEvent is GameEvent temp)
            {
                temp.AddCheckHandle(_check);
            }
        }

        public static void SubScribeEvent(string _eventName,GameEvent.ResponseHandle _response)
        {
            GameBaseEvent gameEvent = m_root?.GetEvent(_eventName);
            if(gameEvent is GameEvent temp)
            {
                temp.AddResponseHandle(_response);
            }
        }

        public static void EnableEvent(string _eventName,bool _enable)
        {
            GameBaseEvent gameEvent = m_root?.GetEvent(_eventName);
            if (gameEvent is GameEvent temp)
            {
                temp.enable = _enable;
            }
        }

        public static void EnableAllEvent(string _eventName,bool _enable)
        {
            var gameEvent = m_root?.GetEvent(_eventName) as GameEventGroup;
            if(gameEvent!=null)
            {
                gameEvent.EnableAllEvent(_enable);
            }
        }

        public static void Update()
        {
            if (m_root == null) return;
            m_root.Update();
        }
    }
}
