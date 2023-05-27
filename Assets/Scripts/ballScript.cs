using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
    public int speed;
    private int yAxis,xAxis ,player1_score, player2_score;
    private bool goingRight, goingUp;
    public Text scoreBoard, playerWinText;
    private SpriteRenderer sprite;
    public GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        yAxis = 0; //as default
        xAxis = 1; //as default

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement of the ball
        if (goingRight)
            transform.position -= new Vector3(xAxis, yAxis, 0) * (speed * Time.deltaTime);
        else
            transform.position += new Vector3(xAxis, yAxis, 0) * (speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //make the ball goes randomly upward or downward
        int random = Random.Range(-1, 1);
        yAxis = random;


        //after making collision to paddle ball will go to the opposite site like bouncing effect
        if (collision.gameObject.tag == "paddles")
        {
            if (goingRight)
            {
                sprite.flipX = false;
                goingRight = false;
            }
            else
            {
                sprite.flipX = true;
                goingRight = true;
            }        
                
        }
        else
        {
            //change the y-axis if the ball goes to the wall
            if (goingUp)
            {
                goingUp = false;
                yAxis = -1;
                transform.rotation = Quaternion.Euler(0, 0, -41.6f);
            }
            else if(yAxis==0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
            {
                yAxis = 1;
                goingUp = true;
                transform.rotation = Quaternion.Euler(0, 0, 19);
            }
                
        }

        speed++;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check who need to give the point
        if (collision.gameObject.name == "Leftside")
            player2_score++;
        else
            player1_score++;

        
        scoreBoard.text = player1_score+" : "+player2_score; //change the score 
        transform.position = new Vector3(0, 0 , 0); //like a restart way
        speed = 5; //restart the speed to 5

        if(player1_score == 2 || player2_score == 2)
        {
            showDialog();
        }
    }

    private void showDialog()
    {
        //to make it pause
        xAxis = 0;
        yAxis = 0;

        //show the pop up dialog
        popUp.SetActive(true);

        //check who's the winner
        string playerWon = player1_score == 10 ? "Player 1 WIN!" : "Player 2 WIN!";
        playerWinText.text = playerWon;


    }
}
