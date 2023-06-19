using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EventManager
{
    private static EventManager m_Instance;
    private Dictionary<string, List<Action>> m_EventMap;

    /// <summary>
    /// Adds the key to the eventmap
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="observer"></param>
    public void Register(string eventName, Action observer)
    {
        if (observer == null) return;
        if (string.IsNullOrEmpty(eventName)) return;

        if (m_EventMap.ContainsKey(eventName))
        {
            m_EventMap[eventName].Add(observer);
        }
        else
        {
            m_EventMap.Add(eventName, new List<Action>());
        }
    }

    /// <summary>
    /// remove a key from the eventmap
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="observer"></param>
    public void Unregister(string eventName, Action observer)
    {
        if (observer == null) return;
        if (string.IsNullOrEmpty(eventName)) return;
        if (!m_EventMap.ContainsKey (eventName)) return;

        List<Action> eventObserver = m_EventMap[eventName];
        eventObserver.Remove(observer);
    }

    /// <summary>
    /// triggers the event
    /// </summary>
    /// <param name="eventName"></param>
    public void TriggerEvent(string eventName)
    {
        if (m_EventMap.ContainsKey(eventName))
        {
            List<Action> eventObserver = m_EventMap[eventName];

            foreach (Action action in eventObserver)
            {
                action?.Invoke();
            }
        }
    }

    /// <summary>
    /// instanciate the eventmanager
    /// </summary>
    public static EventManager Instance
    {
        get
        {
            lock (m_Instance)
            {
                if (m_Instance == null)
                    m_Instance = new EventManager();
            }
            return m_Instance;
        }
    }

    /// <summary>
    /// intance the eventmap
    /// </summary>
    private EventManager() 
    {
        m_EventMap = new Dictionary<string, List<Action>>();
    }
}
