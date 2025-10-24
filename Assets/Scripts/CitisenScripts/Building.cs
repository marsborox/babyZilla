using System.Collections;

using UnityEngine;

public class Building : MonoBehaviour
{
    
    public Sprite buildingStage2;
    public Sprite buildingStage3;

    public Sprite currentBuildingSprite;
    public SpriteRenderer buildingSpriteRenderer;


    public int destroyStage = 1;
    bool isStompedRecently = false;

    private void Start()
    {
        MyGlobalEventHandler.instance.OnPostStomp += PostStompClear;
    }
    private void Update()
    {
        
    }

    private void OnEnable()
    {
        
        
    }
    private void OnDisable()
    {
        MyGlobalEventHandler.instance.OnPostStomp -= PostStompClear;
    }
    public virtual void GetStomped()
    {
        if (isStompedRecently)
        {
            Debug.Log("Building got stomped recently");
            
        }
        else
        {
            StompDetect();
            Debug.Log("Building got hit");
            if (destroyStage == 1)
            {
                //isStompedRecently=true;
                buildingSpriteRenderer.sprite = buildingStage2;
                destroyStage++;
            }
            else if (destroyStage == 2)
            {
                //isStompedRecently = true;
                buildingSpriteRenderer.sprite = buildingStage3;
                destroyStage++;
            }
            else
            {
                return;
            }
        }
        
    }
    public void StompDetect()
    {
        isStompedRecently = true;
        Debug.Log("Building got stomped recently");
    }
    public void PostStompClear()
    {
        isStompedRecently = false;
        //Debug.Log("Building can be stomped again");
    }
    
    /*IEnumerator PostStompClearRoutine()
    {
        yield return new WaitForSeconds(1f);
        isStompedRecently = false;
    }*/
}
