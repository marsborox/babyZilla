using UnityEngine;
using System.Collections;

public class TransformAnimator : MonoBehaviour
{
    public AnimationCurve curve;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Coroutine animationRoutine;

    void Start()
    {
        startPosition = transform.localPosition;
        startScale = transform.localScale;
    }

    public void ResetAnimation()
    {
        transform.localPosition = startPosition;
        transform.localScale = startScale;
    }

    public void StartMoveAnimation(Vector3 newPosition, float time)
    {
        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(AnimateTo(newPosition, transform.localScale, time));
    }

    public void StartScaleAnimation(Vector3 newScale, float time)
    {
        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        animationRoutine = StartCoroutine(AnimateTo(transform.localPosition, newScale, time));
    }

    public void StartAnimation(Vector3 newPosition, Vector3 newScale, float time)
    {
        if (animationRoutine != null)
            StopCoroutine(animationRoutine);

        if (time > 0)
        {
            animationRoutine = StartCoroutine(AnimateTo(newPosition, newScale, time));
        } else
        {
            transform.localPosition = newPosition;
            transform.localScale = newScale;
        }
    }

    private IEnumerator AnimateTo(Vector3 newPosition, Vector3 newScale, float time)
    {
        Vector3 startPosition = transform.localPosition;
        Vector3 startScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / time;
            transform.localPosition = Vector3.Lerp(startPosition, newPosition, t);
            transform.localScale = Vector3.Lerp(startScale, newScale, t);
            yield return null;
        }

        transform.localPosition = newPosition;
        transform.localScale = newScale;
    }
}