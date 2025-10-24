using System.Collections;
using UnityEngine;

public class Pacicka : MonoBehaviour
{
    public Collider2D pacickaCollider;
    public SpriteRenderer pacickaRenderer;
    public TransformAnimator stompAnimation;
    public CameraShake cameraShake;

    //public MyGlobalEventHandler myGlobalEventHandler;
    public float tempPreSmashTime=0.5f;
    public float postSmashTime = 0.1f;

    void Start()
    {
    }

    public void Stomp(bool stompDown)
    {
        //Debug.Log("You stomped you Stomperr");
        if (stompDown && !IsStomping())
        {
            StartCoroutine(StompRoutine());
        } else if (!stompDown && IsStomping())
        {
            pacickaCollider.gameObject.SetActive(false);
            stompAnimation.ResetAnimation();
            MyGlobalEventHandler.instance.InvokePostStomp();
            //Debug.Log("postStomping");
        }
    }
    public bool IsStomping()
    {
        return pacickaCollider.gameObject.activeInHierarchy;
        //return pacickaCollider.gameObject.activeSelf;
    }
    IEnumerator StompRoutine()
    {
        stompAnimation.StartMoveAnimation(new Vector3(0, -1f, 0), 0); 
        yield return new WaitForSeconds(0.1f);
        stompAnimation.StartAnimation(pacickaRenderer.transform.localPosition, pacickaRenderer.transform.localScale, 0.1f);

        //Debug.Log("soon stopming");
        yield return new WaitForSeconds(tempPreSmashTime - 0.1f);
        MySoundManager.instance.PlaySmash();
        pacickaCollider.gameObject.SetActive(true);
        cameraShake.Shake();

        MyGlobalEventHandler.instance.InvokeStompEvent(this.transform.position);
        //Debug.Log("doing stomping");
    }
    void HitDone()
    { 
        
    }
}
