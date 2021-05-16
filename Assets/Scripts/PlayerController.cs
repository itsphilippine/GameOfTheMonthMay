using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public int line = 1;
    
    public bool starting = false;

    public float rayonTaille = 0.1f;

    private RaycastHit hitInfo;
    public bool touchingGround;

    public float jumpVelocity = 2;

    

    public Rigidbody rB;

    public GameObject player;
    public GameObject gameOverMenu;
    public GameObject infoInGame;

    public float score = 0f;

    public GameObject gameManager;

    private float deplacement = 0;

    public Vector3 position;

    public GameObject DeathFX;

    // Start is called before the first frame update

    private void OnEnable()
    {
        ButtonManager.GameLaunched += Starting;
    }

    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            
        if(starting)
        {
            
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("GO TO LEFT");
                if(line > 0)
                {
                    FindObjectOfType<AudioManager>().Play("SlideSnd");
                    StartCoroutine(SlideMove(-1f));
                    line -= 1;
                    //StartCoroutine(Move(-1));
                    //transform.position -= new Vector3(0.3f, 0, 0);
                    
                    //Move(-0.3f);
                    deplacement = -1;
                }
            }  

            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("GO TO RIGHT");
                if(line < 2)
                {
                    FindObjectOfType<AudioManager>().Play("SlideSnd");
                    StartCoroutine(SlideMove(1f));
                    line += 1;
                    //transform.position += new Vector3(0.3f, 0, 0);
                    
                    //Move(0.3f);
                    deplacement = 1;
                }
            } 

            if(Input.GetButtonDown("Jump") && touchingGround)
            {
                
                Jump();
            }

            AutoMove();

            Move(deplacement);
            position = transform.position;

            score += transform.position.z * Time.deltaTime;
 
        }

        CheckDeath();
        CheckGround();
    }

    void AutoMove()
    {
        transform.position += new Vector3(0, 0, 1.5f * Time.deltaTime);
    }

    void Starting()
    {
        Debug.Log("GAME IS STARTING");
        StartCoroutine(Delay());
    }
    private void OnDisable()
    {
        ButtonManager.GameLaunched -= Starting;
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        starting = true;
    }

    public void StartDelay()
    {
        StartCoroutine(Delay());
    }

    void CheckDeath()
    {
        Ray rayon = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(rayon, out hitInfo, rayonTaille))
        {
            Debug.Log("MORT");
            starting = false;
            Instantiate(DeathFX, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            //Destroy(player);
            gameOverMenu.SetActive(true);
            infoInGame.SetActive(false);
            player.SetActive(false);
            gameManager.GetComponent<GameManager>().ScoreArrondi(score);
            Debug.DrawLine(rayon.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(rayon.origin, rayon.origin + rayon.direction * rayonTaille, Color.yellow);
        }
    }

    void CheckGround()
    {
        Ray rayon = new Ray(transform.position, -transform.up);
        if(Physics.Raycast(rayon, out hitInfo, rayonTaille))
        {
            touchingGround = true;
        }
        else 
        {
            touchingGround = false;
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        Debug.Log("JUMP");

        FindObjectOfType<AudioManager>().Play("JumpSnd");
    }

    void Move(float maxMove)
    {
        
    }

    IEnumerator SlideMove(float direction)
    {
        switch(line)
        {
            case 0 :
                while(transform.position.x <= -0.1f)
                {
                    transform.Translate(new Vector3(0.1f, 0, 0));
                    Debug.Log("LEFT GO TO CENTER");
                    yield return null;
                }
            break;

            case 1 :
                if(direction > 0)
                {
                    while(transform.position.x < 0.3f)
                    {
                        transform.Translate(new Vector3(0.1f, 0, 0));
                        Debug.Log("CENTER GO TO RIGHT");
                        yield return null;
                    }
                }
                if(direction < 0)
                {
                    while(transform.position.x > -0.3f)
                    {
                        transform.Translate(new Vector3(-0.1f, 0, 0));
                        Debug.Log("CENTER GO TO LEFT");
                        yield return null;
                    }
                }
            break;

            case 2 :
                while(transform.position.x > 0)
                {
                    transform.Translate(new Vector3(-0.1f, 0, 0));
                    Debug.Log("RIGHT GO TO CENTER");
                    yield return null;
                }
            break;
        }

        
    }

    /*IEnumerator Move(float direction)
    {
        transform.Translate(new Vector3(direction,0,0));
        Debug.Log("MOVE");
        yield return new WaitForSeconds(2);
    }*/
}
