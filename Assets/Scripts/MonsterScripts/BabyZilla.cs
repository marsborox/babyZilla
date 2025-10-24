using System.Collections.Generic;
using UnityEngine;

public class BabyZilla : MonoBehaviour
{
    public SimpleSpriteAnimator animator;
    public int smileWhenStompedAtLeast = 20;

    private float stompSmileTimeThreshold = 1f;
    private readonly Queue<float> callTimestamps = new Queue<float>();

    void Start()
    {
        MyGlobalEventHandler.instance.OnCitisenDied += SmileOnStomp;
    }

    private void SmileOnStomp()
    {
        float now = Time.time;
        callTimestamps.Enqueue(now);

        // Remove timestamps older than the window
        while (callTimestamps.Count > 0 && callTimestamps.Peek() < now - stompSmileTimeThreshold)
            callTimestamps.Dequeue();

        if (callTimestamps.Count > smileWhenStompedAtLeast)
        {
            animator.Play();
        }
    }
}
