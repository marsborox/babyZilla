using UnityEngine;
using System.Collections;

public class SimpleSpriteAnimator : MonoBehaviour
{
    public Sprite[] frames;
    public float frameRate = 0.1f;    // Seconds per frame

    public SpriteRenderer spriteRenderer;

    private bool isAnimating = false;

    public void Play()
    {
        StartCoroutine(PlayAnimation());
    }
   
    private IEnumerator PlayAnimation()
    {
        Debug.Log("Play babyzilla!");

        if (isAnimating) yield break;
        isAnimating = true;

        for (int i = 0; i < frames.Length; i++)
        {
            spriteRenderer.sprite = frames[i];
            yield return new WaitForSeconds(frameRate);
        }

        // Optionally return to the first frame
        spriteRenderer.sprite = null;

        isAnimating = false;
    }
}
