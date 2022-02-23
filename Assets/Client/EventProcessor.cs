using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client
{
    public class EventProcessor : MonoBehaviour
    {
        private static System.Object m_queueLock = new System.Object();
        private static List<Action> m_queuedEvents = new List<Action>();
        private static List<Action> m_executingEvents = new List<Action>();

        private volatile static bool noActionQueueToExecuteUpdateFunc = true;

        void Awake()
        {
        }

        void Update()
        {

            if (noActionQueueToExecuteUpdateFunc)
            {
                return;
            }

            MoveQueuedEventsToExecuting();

            while (m_executingEvents.Count > 0)
            {
                Action e = m_executingEvents[0];
                m_executingEvents.RemoveAt(0);
                e();
            }

            noActionQueueToExecuteUpdateFunc = true;
        }

        public static void QueueEvent(Action action)
        {
            lock (m_queueLock)
            {
                m_queuedEvents.Add(action);
                noActionQueueToExecuteUpdateFunc = false;
            }
        }

        private void MoveQueuedEventsToExecuting()
        {
            lock (m_queueLock)
            {
                while (m_queuedEvents.Count > 0)
                {
                    Action e = m_queuedEvents[0];
                    m_executingEvents.Add(e);
                    m_queuedEvents.RemoveAt(0);
                }
            }
        }
    }
}
