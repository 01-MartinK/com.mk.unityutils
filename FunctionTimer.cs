using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    public static FunctionTimer Create(Action action, float maxTime, bool destroySelf)
    {
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));

        FunctionTimer functionTimer = new FunctionTimer(action, maxTime, destroySelf, gameObject);

        gameObject.GetComponent<MonoBehaviourHook>().OnUpdate = functionTimer.Update;

        return functionTimer;
    }

    public static FunctionTimer Create(Action action, float maxTime, bool destroySelf, Transform parent)
    {
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        gameObject.transform.parent = parent;

        FunctionTimer functionTimer = new FunctionTimer(action, maxTime, destroySelf, gameObject);

        gameObject.GetComponent<MonoBehaviourHook>().OnUpdate = functionTimer.Update;

        return functionTimer;
    }

    // Dummy class for MonoBehaviour functions
    private class MonoBehaviourHook : MonoBehaviour
    {
        public Action OnUpdate;
        private void Update()
        {
            if (OnUpdate != null) OnUpdate();
        }
    }

    private Action action;
    private float maxTime;
    private float timer;
    private GameObject gameObject;
    private bool isDestroyed;
    private bool destroySelf;

    private FunctionTimer(Action action, float maxTime, bool destroySelf, GameObject gameObject)
    {
        this.action = action;
        this.maxTime = maxTime;
        this.destroySelf = destroySelf;
        this.gameObject = gameObject;
        
        timer = maxTime;
        isDestroyed = false;
    }

    public void Update()
    {
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                // Trigger the action
                action();
                if (destroySelf)
                    DestroySelf();
                else
                    timer = maxTime;
            }
        }
    }

    public void DestroyTimer()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
    }
    private void DestroySelf()
    {
        isDestroyed = true; 
        UnityEngine.Object.Destroy(gameObject);
    }
}
