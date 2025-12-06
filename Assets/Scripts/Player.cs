using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    

    public float Velocity = 10;
    private Rigidbody2D rb;
    public GameObject playerBody;
 
    public Collider2D spikeCollider;

    public bool doubleJumpActive;
    public int doubleJumpUsed;
    public float doubleJumpTimer;

    public GameObject boomCyan; 
    public GameObject boomGreen; 
    public GameObject boomGold; 

    public bool goldPower;
    public float goldPowerTimer;


    public TextMeshProUGUI TimeText;
    public float timer;
   

    public bool isGrounded;



   
    public Player player;
    
    public GameObject playButton;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;



    }



    // Update is called once per frame
    void Update()
    {
        
       
            timer += Time.deltaTime;
            DisplayTime(timer);

            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

          



            if (Input.GetMouseButtonDown(0) && isGrounded)
                {
                    rb.velocity = Vector2.up * Velocity;
                }
            else if (doubleJumpActive)
            {
                if (Input.GetMouseButtonDown(0) )
                {
                    rb.velocity = Vector2.up * Velocity;
                   
                        doubleJumpUsed++;
                    
                }
            }
           
           
        } 
        


    public void OnTriggerEnter2D(Collider2D collision)
    {

        
         if(collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("outOfBound"))
        {

            GameOver();
        }
      
        if(collision.gameObject.CompareTag("ground"))
        {
          
            doubleJumpUsed=0;
        }
        if(collision.gameObject.CompareTag("hole"))
        {
            Collider2D playerCollider = GetComponent<Collider2D>();
            if(playerCollider != null)
            {
                playerCollider.isTrigger= true;

            }
            
        }

        if(collision.gameObject.CompareTag("green"))
        {
           playerBody.GetComponent<SpriteRenderer>().color = Color.green;
            doubleJumpActive=true;
            goldPower=false;
            StartCoroutine(powerGreen());
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("gold"))
        {
            Collider2D spikeCollider = GetComponent<Collider2D>();
            goldPower=true;
            StartCoroutine(powerGold());
            Destroy(collision.gameObject);
        }

       

        // if(collision.gameObject.CompareTag("Spike") && goldPower == false || collision.gameObject.CompareTag("outOfBounds"))
        // {
        //     if(doubleJumpActive == true)
        //     {
        //         Instantiate(boomGreen , transform.position,Quaternion.Euler(new Vector3(0,0,0)));
        //         gameOver = true;
        //     }else if (goldPower == true)
        //     {
        //         Instantiate(boomGold , transform.position,Quaternion.Euler(new Vector3(0,0,0)));
        //         gameOver = true;
        //     }else if (gameOver == false)
        //     {
        //         Instantiate(boomCyan , transform.position,Quaternion.Euler(new Vector3(0,0,0)));
        //         gameOver = true;
        //     }
        //     StartCoroutine(setGameOver());
        //     playerBody.SetActive(false);

        // }
   
    }

    

    IEnumerator powerGold()
    {

        Debug.Log("gold");

        spikeCollider.isTrigger = false;
        yield return new WaitForSeconds(5);
        
        goldPower =false;
        GetComponent<CircleCollider2D>().enabled=false;
        GetComponent<CircleCollider2D>().enabled=true;

    }
     IEnumerator powerGreen()
    {
        yield return new WaitForSeconds(15);
        doubleJumpActive =false;
         playerBody.GetComponent<SpriteRenderer>().color = Color.white;


    }
    //   IEnumerator setGameOver()
    // {
    //     yield return new WaitForSeconds(1);
    //     Time.timeScale=0;

    // }

    private void DisplayTime(float timeToDisplay)
    {
        if(PlayerPrefs.GetFloat("highscore")< timeToDisplay)
        {
            PlayerPrefs.SetFloat("highscore",timeToDisplay);

        }
        var t0 = (int)timeToDisplay;
        var m = t0 / 60;
        var s = (t0 - m *60);
        var ms = (int)((timeToDisplay - t0) * 100);

        TimeText.text = $"{m:00}:{s:00}:{ms:00}";
    }


    


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Play()
    {
    

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        if(player.enabled)
        { 
      
            SceneManager.LoadScene(1);

        }
       
    }
     public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();

      
    }
}
