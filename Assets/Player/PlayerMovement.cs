using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;

    public float timeToSurvive;
    public GameObject goTime;
    public GameObject goScore;
    public GameObject goReset;

    public GameObject goResetScore;
    public GameObject goResetHighScore;

    private Text time;
    private Text score;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        time = goTime.GetComponent<Text>();
        score = goScore.GetComponent<Text>();

        goTime.SetActive(true);
        goScore.SetActive(true);
        goReset.SetActive(false);

    }

    public void Reset()
    {
        if (Globals.socialStatus > Globals.highScore) Globals.highScore = Globals.socialStatus;
        Globals.inventory = new List<int>();
        Globals.socialStatus = 0;
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void updateScreen()
    {
        timeToSurvive -= Time.deltaTime;
        score.text = "Social Status: " + Globals.socialStatus;
        time.text = "Time Left: " + (int)timeToSurvive;

        if (timeToSurvive <= 0)
        {
            goTime.SetActive(false);
            goScore.SetActive(false);
            goReset.SetActive(true);

            goResetScore.GetComponent<Text>().text = "You finished with a score of: " + Globals.socialStatus;
            goResetHighScore.GetComponent<Text>().text = "High Score: " + Globals.highScore;

            Time.timeScale = 0;
        }
    }

    void Update()
    {
        updateScreen();

        //user input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x > 0)
        {
            sr.flipX = false;
        }
        else if(movement.x <0)
        {
            sr.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
   
}
    

