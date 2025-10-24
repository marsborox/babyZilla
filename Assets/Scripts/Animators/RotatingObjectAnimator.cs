using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotatingObjectAnimator : MonoBehaviour
{
    public float duration = 0.5f;
    public float startRotation = 0;
    public float targetRotation = 0;

    public AnimationCurve rotationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private void Start()
    {
        StartCoroutine(RotateLoop());
    }

    private IEnumerator RotateLoop()
    {
        while (true)
        {
            yield return RotateOverTime(startRotation, targetRotation, duration);
            yield return RotateOverTime(targetRotation, startRotation, duration);
        }
    }

    private IEnumerator RotateOverTime(float fromZ, float toZ, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);
            float curveT = rotationCurve.Evaluate(t);
            float z = Mathf.Lerp(fromZ, toZ, curveT);

            transform.localEulerAngles = new Vector3(0f, 0f, z);
            yield return null;
        }
    }
}