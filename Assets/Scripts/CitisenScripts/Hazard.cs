using UnityEngine;

public class Hazard : Building
{
    public GameObject hazard;
    public override void GetStomped()
    {
        Debug.Log("Building got damaged");
        if (destroyStage == 1)
        {
            buildingSpriteRenderer.sprite = buildingStage2;
            destroyStage++;
        }
        else if (destroyStage == 2)
        {
            buildingSpriteRenderer.sprite = buildingStage3;
            destroyStage++;
            hazard.SetActive(true);
        }
        else
        {
            return;
        }


    }
}
