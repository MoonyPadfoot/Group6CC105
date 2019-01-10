using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public static PlayerC instance;

    [SerializeField]
    private float xLimit = 8.66f;

    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private Animator anim;
    private bool movingLeft = true;
    private int direction = 1;
    private bool startMoving = false;

    //time duration
    float timerLength = 10.0f;//The length of time in seconds.
    float timerTimePassed = 0.0f;//The variable that will store the time passed while the timer is going.
    bool runTimer = false;
    public bool Runtimer {get{return runTimer;}}//duration effect

    bool runTimer2 = false;
    public bool Runtimer2 {get{return runTimer2;}}//duration effect
    private int life = 3;
    public int Life{get {return life;}}
    private int score;
    public int Score{get {return score;}}
    public bool StartMoving{get {return startMoving;}set {startMoving = value;}}
    // Start is called before the first frame 
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        startMoving = true;
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButton(0) && startMoving == false)
        // {
        //     startMoving = true;
        // }
        if (runTimer)
        {
            timerTimePassed += Time.deltaTime;//clock

            if (timerTimePassed >= timerLength)
            {
                timerTimePassed = 0f;
                runTimer = false;
                MenuManager.instance.RemoveStatusEffect();
                //Put code here to be triggered when timer fires.
            }
        }
        if (runTimer2)
        {
            timerTimePassed += Time.deltaTime;//clock

            if (timerTimePassed >= timerLength)
            {
                timerTimePassed = 0f;
                runTimer2 = false;
                
                //Put code here to be triggered when timer fires.
            }
        }

        if (Input.GetMouseButton(0))
        {
            if(!PauseMenu.pauseMenuActive)
            {
                movingLeft = !movingLeft;
                direction = -direction;
                transform.localScale = new Vector3(direction,1,1);
            }
        }

        if (startMoving == false)return;
        ChangeDirection();

        transform.position += Vector3.left * moveSpeed * Time.deltaTime * direction;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xLimit, xLimit),transform.position.y, transform.position.z);

        anim.SetBool("Start", startMoving);
    }
    void ChangeDirection()
    {
        if(movingLeft && transform.position.x <= -xLimit)
        {
            movingLeft = false;
            direction = -1;
            transform.localScale = new Vector3(direction,1,1);
        }
        if(!movingLeft && transform.position.x >= xLimit)
        {
            movingLeft = true;
            direction = 1;
            transform.localScale = new Vector3(direction,1,1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Point1"))
        {
            SoundManager.instance.PlayPoint();
            Debug.Log("1");
            score = 1;
            MenuManager.instance.IncreaseScore();
        }
        else if (other.CompareTag("Point2"))
        {
            SoundManager.instance.PlayPoint();
            score = 2;
            MenuManager.instance.IncreaseScore();
            Debug.Log("2");
        }
        else if(other.CompareTag("Point3"))
        {
            SoundManager.instance.PlayPoint();
            score = 3;
            MenuManager.instance.IncreaseScore();
            Debug.Log("3");
        }
        
        else if (other.CompareTag("Enemy"))
        {   
             SoundManager.instance.PlayDeath();
            Debug.Log("Hit enemy");
            Health.health -= 1;
        }
        else if (other.CompareTag("Power1"))
        {   
            SoundManager.instance.PlayPoint();
            Debug.Log("Hit enemy");
            if (Health.health < 3) 
                Health.health += 1;
        }
        else if (other.CompareTag("Power2"))
        {   
            SoundManager.instance.PlayPoint();
            runTimer2 = true;
        }
        else if (other.CompareTag("Power3"))
        {   
            SoundManager.instance.PlayPoint();
            runTimer = true;
            MenuManager.instance.ShowStatusEffect(); 
        }
        // else if (other.CompareTag("Points2")){ Debug.Log("Point1");}
        // else if (other.CompareTag("Points3")){ Debug.Log("Point1");}
    }
}
