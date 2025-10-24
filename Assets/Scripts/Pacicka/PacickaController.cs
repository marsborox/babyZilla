using UnityEngine;

public class PacickaController : MonoBehaviour
{

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float maxY = 1.8f;

    Vector2 currentVelocity = new Vector2();

    private Pacicka pacicka;

    void Start()
    {
        pacicka = GetComponentInChildren<Pacicka>();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (pacicka.IsStomping()) { return; }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x != mousePosition.x || transform.position.y != mousePosition.y)
        {
            Vector2 targetPosition = new Vector2(mousePosition.x, Mathf.Clamp(mousePosition.y, float.MinValue, maxY));
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        }
    }
}
