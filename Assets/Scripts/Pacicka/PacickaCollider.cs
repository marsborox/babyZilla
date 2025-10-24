using UnityEngine;

public class PacickaCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("colision");
        if (other.tag == "Citisen")
        {
            other.GetComponent<Citisen>().Die();
        }
        if (other.tag == "Building")
        {
            var building = other.GetComponent<Building>();
            //building.StompDetect();
            building.GetStomped();
        }
    }
}
