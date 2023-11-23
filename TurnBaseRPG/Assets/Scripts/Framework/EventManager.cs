using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MyEvent : UnityEvent {}
public class MyEvent1<T> : UnityEvent<T> { }
public class MyEvent2<T1,T2> : UnityEvent<T1,T2> { }
public class MyEvent3<T1,T2,T3> : UnityEvent<T1,T2,T3> { }

public class EventManager : MonoSingleton<EventManager> {

    private Dictionary<string, List<UnityEventBase>> eventDictionary = new Dictionary<string, List<UnityEventBase>>();

    public void AddListener(string eventName, UnityAction listener) {
        if (!eventDictionary.ContainsKey(eventName)) {
            eventDictionary.Add(eventName, new List<UnityEventBase>());
        }

        var listEvent = eventDictionary[eventName];
        MyEvent myEvent = null;
        if (listEvent.Count == 0) {
            myEvent = new MyEvent();
            listEvent.Add(myEvent);
        }
        else {
            foreach (var unityEventBase in listEvent) {
                if (unityEventBase is MyEvent storageEvent) {
                    myEvent = storageEvent;
                }
            }

            if (myEvent == null) {
                myEvent = new MyEvent();
                listEvent.Add(myEvent);
            }
        }

        myEvent.AddListener(listener);
    }

    public void RemoveListener(string eventName, UnityAction listener) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent myEvent) {
                    myEvent.RemoveListener(listener);
                }
            }
        }
    }

    public void TriggerEvent(string eventName) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent myEvent) {
                    myEvent.Invoke();
                }
            }
        }
    }

    public void AddListener<T>(string eventName, UnityAction<T> listener) {
        if (!eventDictionary.ContainsKey(eventName)) {
            eventDictionary.Add(eventName, new List<UnityEventBase>());
        }

        var listEvent = eventDictionary[eventName];
        MyEvent1<T> myEvent = null;
        if (listEvent.Count == 0)
        {
            myEvent = new MyEvent1<T>();
            listEvent.Add(myEvent);
        }
        else
        {
            foreach (var unityEventBase in listEvent)
            {
                if (unityEventBase is MyEvent1<T> storageEvent)
                {
                    myEvent = storageEvent;
                }
            }

            if (myEvent == null)
            {
                myEvent = new MyEvent1<T>();
                listEvent.Add(myEvent);
            }
        }

        myEvent.AddListener(listener);
    }

    public void RemoveListener<T>(string eventName, UnityAction<T> listener) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName])
            {
                if (eventListener is MyEvent1<T> myEvent)
                {
                    myEvent.RemoveListener(listener);
                }
            }

        }
    }

    public void TriggerEvent<T>(string eventName,T parameter1) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent1<T> myEvent) {
                    myEvent.Invoke(parameter1);
                }
            }

        }
    }

    public void AddListener<T1, T2>(string eventName, UnityAction<T1, T2> listener) {
        if (!eventDictionary.ContainsKey(eventName)) {
            eventDictionary.Add(eventName, new List<UnityEventBase>());
        }

        var listEvent = eventDictionary[eventName];
        MyEvent2<T1,T2> myEvent = null;
        if (listEvent.Count == 0) {
            myEvent = new MyEvent2<T1, T2>() ;
            listEvent.Add(myEvent);
        }
        else {
            foreach (var unityEventBase in listEvent) {
                if (unityEventBase is MyEvent2<T1, T2> storageEvent) {
                    myEvent = storageEvent;
                }
            }

            if (myEvent == null) {
                myEvent = new MyEvent2<T1, T2>();
                listEvent.Add(myEvent);
            }
        }

        myEvent.AddListener(listener);
    }

    public void RemoveListener<T1, T2>(string eventName, UnityAction<T1, T2> listener) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent2<T1,T2> myEvent) {
                    myEvent.RemoveListener(listener);
                }
            }
            
        }
    }

    public void TriggerEvent<T1, T2>(string eventName,T1 parameter1, T2 parameter2) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent2<T1, T2> myEvent) {
                    myEvent.Invoke(parameter1, parameter2);
                }
            }
        }
    }

    // 添加更多重载方法以支持不同数量的泛型参数
    public void AddListener<T1, T2, T3>(string eventName, UnityAction<T1, T2, T3> listener) {
        if (!eventDictionary.ContainsKey(eventName)) {
            eventDictionary.Add(eventName, new List<UnityEventBase>());
        }

        var listEvent = eventDictionary[eventName];
        MyEvent3<T1, T2,T3> myEvent = null;
        if (listEvent.Count == 0) {
            myEvent = new MyEvent3<T1, T2, T3>();
            listEvent.Add(myEvent);
        }
        else {
            foreach (var unityEventBase in listEvent) {
                if (unityEventBase is MyEvent3<T1, T2, T3> storageEvent) {
                    myEvent = storageEvent;
                }
            }

            if (myEvent == null) {
                myEvent = new MyEvent3<T1, T2, T3>();
                listEvent.Add(myEvent);
            }
        }

        myEvent.AddListener(listener);
    }

    public void RemoveListener<T1, T2, T3>(string eventName, UnityAction<T1, T2, T3> listener) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent3<T1, T2, T3> myEvent) {
                    myEvent.RemoveListener(listener);
                }
            }

        }
    }

    public void TriggerEvent<T1, T2, T3>(string eventName,T1 parameter1, T2 parameter2, T3 parameter3) {
        if (eventDictionary.ContainsKey(eventName)) {
            foreach (var eventListener in eventDictionary[eventName]) {
                if (eventListener is MyEvent3<T1, T2,T3> myEvent) {
                    myEvent.Invoke(parameter1, parameter2,parameter3);
                }
            }
        }
    }
}