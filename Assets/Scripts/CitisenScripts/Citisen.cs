using System.Collections;
using UnityEngine;
using UnityEngine.Apple;

public class Citisen : MonoBehaviour
{
    public int health = 1;
    public Sprite[] deathSprites;
    public SpriteRenderer citisenSprite;
    public float movementSpeed =0.1f;
    //public MyGlobalEventHandler myGlobalEventHandler;
    public float scaredMovementTime = 3f;
    public int score=1;
    public bool isMovingRight = true;
    public GameObject deathParticlesPrefab;

    Transform lastFrameTransform;

    public MovementVector movementVector;

    bool isScared = false;
    public bool isProtected=true;
    Coroutine runRoutine;
    Coroutine playRunAnimationCoroutine;

    private Rigidbody2D myRigidbody;
    private Collider2D collider;

    public Animator myAnimator;

    public bool isPlayingRunAnimation = false;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        FlipSprite();
        lastFrameTransform = transform;
    }

    void Update()
    {
        //FlipSprite();
        CheckDirectionFromMouse();
        
        MoveIfScared();
        //CheckDirection();
        //TurnCorrectDirection();
        //CheckMovementVector();
    }
    private void OnEnable()
    {
        MyGlobalEventHandler.instance.OnStomp += RunFromStomp;
    }
    private void OnDisable()
    {
        MyGlobalEventHandler.instance.OnStomp -= RunFromStomp;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Destroy")
        { 
            Destroy(gameObject);
        }
        if (collider.tag == "Hazard")
        {
            DieHorribly();
        }
    }
    public void Die()
    {
        ScoreKeeper.instance.AddScore(score);
        ProcessDeath();
    }
    public void DieHorribly()
    {
        int doubleScore = score * 2;
        ScoreKeeper.instance.AddScore(doubleScore);
        ProcessDeath();
    }
    void ProcessDeath()
    {
        if (!collider.enabled) return;
        collider.enabled = false;
        Destroy(myRigidbody);

        MyGlobalEventHandler.instance.InvokeCitisenDiedEvent();

        GameObject p = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(p, 0.2f);

        //Debug.Log("citisen died ya evil basterd");
        //Debug.Log("died normally with score: "+score);
        MySoundManager.instance.PlayScream();

        int deathSpriteId = Random.Range(0, 6);
        if (deathSpriteId < deathSprites.Length)
        {
            Sprite deathSprite = deathSprites[deathSpriteId];
            citisenSprite.sprite = deathSprite;
            StartCoroutine(DestroyAfterDelay(1f));
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void RunFromStomp(Vector3 inputTransform)
    {
        //runFromDirection = inputTransform;
        //Debug.Log("event processed");
        //Vector3 direction = (transform.position - inputTransform.position).normalized;
        Vector3 direction = (transform.position - inputTransform).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        angle -= 90f;
        Quaternion runDirection = Quaternion.Euler(0,0,angle);
        movementVector.transform.rotation = runDirection;
        TurnCorrectDirection();

        isScared = true;
        if (!(runRoutine == null))
        {
            StopCoroutine(runRoutine);
        }
        runRoutine = StartCoroutine(RunRoutine());
        //CheckDirectionFromStomp(inputTransform);
    }
    void MoveIfScared()
    {
        if (isScared)
        {
            Move();
            
        }
        else
        {
            //myAnimator.SetBool("Idle", false);
        }
    }
    private void Move()
    {
        if (!collider.enabled) return;

        transform.position += movementVector.transform.up * movementSpeed * Time.deltaTime;
        if (!isPlayingRunAnimation)
        {
            StartCoroutine(PlayRunAnimationRandomlyRoutine());
        }
    }
    IEnumerator PlayRunAnimationRandomlyRoutine()
    {
        isPlayingRunAnimation = true;
        float randomTime = Random.Range(0f,0.5f);
        yield return new WaitForSeconds(randomTime);
        myAnimator.SetTrigger("PlayRunAnimation");
        yield return new WaitForSeconds(0.5f);
        isPlayingRunAnimation = false;

    }
    IEnumerator RunRoutine()
    { 
        yield return new WaitForSeconds(scaredMovementTime);
        isScared = false;
    }
    void StopRunAnimation()
    { }
    void CheckDirection()
    { 
        if (transform.position.x < lastFrameTransform.position.x)
        {
            isMovingRight=true;
        }
        else if(transform.position.x > lastFrameTransform.position.x)
        {
            isMovingRight = false;
        }

            lastFrameTransform = transform;
    }
    void FlipSprite()
    {
        //this will make sure that when standing it wont flip
        //its if my speed is 0 literaly
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)//ifp layer has (some) horizontal speed
        {
            //we need that signe and dont want to change anything on axis y
            //1f because it is 1 in scale in transform
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.linearVelocity.x), 1f);
        }
    }
    void CheckMovementVector()
    {
        Debug.Log("checkingMovement");
        if (movementVector.transform.rotation.y < 90 && movementVector.transform.rotation.y > -90)
        {
            isMovingRight = true;
        }
        else if(movementVector.transform.rotation.y > 90 || movementVector.transform.rotation.y < -90)
        {
            isMovingRight = false;
        }
    }
    void CheckDirectionFromStomp(Vector3 inputTransform)
    {
        if (inputTransform.y > transform.position.x)
        {
            isMovingRight = false;
        }
        else
        {
            isMovingRight = true;
        }
    }
    void CheckDirectionFromMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mouse.x;
        float charX = transform.position.x;
        if (mouseX > charX)
        { isMovingRight = true; }
        else if (mouseX < charX)
        {
            isMovingRight = false;
        }
        else { }

    }
    public void TurnCorrectDirection()
    {
        var visual = this.transform.rotation;
        float yRotation;
        if (isMovingRight)
        {
            yRotation = 180f;
        }
        else
        {
            yRotation = 0f;
        }
        Quaternion quaternion = Quaternion.Euler(visual.x, yRotation, visual.z);
        citisenSprite.transform.rotation = quaternion;
    }
}
