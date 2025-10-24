using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float magnitude = 0.1f;
    public float duration = 0.2f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(Shake(magnitude, duration));
    }

    private IEnumerator Shake(float magnitude, float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = transform.localPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPosition;
    }
}
