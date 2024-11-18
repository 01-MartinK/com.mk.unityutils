using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTickRate
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;
    public static event EventHandler<OnTickEventArgs> OnTick_Double;

    private const float TICK_TIMER_MAX = 3f;

    private static GameObject timeTickSystemGameObject;
    private static int tick;

    public static void Create()
    {
        if (timeTickSystemGameObject == null)
        {
            timeTickSystemGameObject = new GameObject("TimeTickSystem");
            timeTickSystemGameObject.AddComponent<TimeTickSystemObject>();
        }
    }

    private class TimeTickSystemObject : MonoBehaviour
    {
        private float tickTimer;

        private void Awake()
        {
            tick = 0;
        }

        private void Update()
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= TICK_TIMER_MAX )
            {
                tickTimer -= TICK_TIMER_MAX;
                tick++;
                if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });

                if (tick % (TICK_TIMER_MAX * 2) == 0)
                {
                    if (OnTick_Double != null) OnTick_Double(this, new OnTickEventArgs { tick = tick });
                }
            }
        }
    }
}
