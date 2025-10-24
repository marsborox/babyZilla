using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingImage : MonoBehaviour
{
    public Image image;
    public float blinkingInterval = 0.5f;

    private void Start()
    {
        if (image != null)
            StartCoroutine(BlinkRoutine());
        else
            Debug.LogWarning("BlinkImage: No Image assigned!");
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            image.enabled = !image.enabled;
            yield return new WaitForSeconds(blinkingInterval);
        }
    }
}
