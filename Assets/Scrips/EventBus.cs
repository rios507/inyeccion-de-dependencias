using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<string, List<Delegate>> events = new();

    public static void Subscribe(string eventName, Action action)
    {
        if(!events.ContainsKey(eventName))
        {
            events.Add(eventName, new List<Delegate>());
        }

        events[eventName].Add(action);
    }
    public static void Subscribe<T>(string eventName, Action<T> action)
    {
        if (!events.ContainsKey(eventName))
        {
            events.Add(eventName, new List<Delegate>());
        }

        events[eventName].Add(action);
    }
    public static void Unsubscribe(string eventName, Action action)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName].Remove(action);
        }
    }
    public static void Unsubscribe<T>(string eventName, Action<T> action)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName].Remove(action);
        }
    }
    public static void InvokeEvent(string eventName)
    {
        foreach(Action item in events[eventName])
        {
           item.Invoke();
        }
    }
    public static void InvokeEvent<T>(string eventName, T value)
    {
        foreach (Action<T> item in events[eventName])
        {
            item.Invoke(value);
        }
    }
}
