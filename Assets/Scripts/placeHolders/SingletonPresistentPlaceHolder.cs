using UnityEngine;

public class SingletonPresistentPlaceHolder : SingletonPersistent<SingletonPresistentPlaceHolder>
{
    public static new SingletonPresistentPlaceHolder instance => SingletonPersistent<SingletonPresistentPlaceHolder>.instance;
    //necessary the instance thing and base.Awake
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
