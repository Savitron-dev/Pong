using UnityEngine;

public class AI_Input : MonoBehaviour
{
    public Transform tr; //For Getting the Position of Ball
    private float speed;
    public float topWallY = 4.75f;                                              //For AI Prediction
    public float bottomWallY = -4.75f;                                          //For AI Prediction
    public float paddleOffset = 0.5f;                                           //For AI Prediction   
    private Rigidbody2D rb; //For AI Paddle
    float target; //For AI Paddle
    public Rigidbody2D Ballrb; //For Ball
    float timeToReach;
    float ballX;
    float ballY;
    float velocityX;
    float velocityY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position.y;
        // Read the selected difficulty.
        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);

        switch (difficulty)
        {
            case 0: // Easy
                speed = 5f;
                break;

            case 1: // Medium
                speed = 10f;
                break;

            case 2: // Hard
                speed = 20f;
                break;

            default:
                speed = 8f;
                break;
        }
        ballX = Ballrb.position.x;                                        
        ballY = Ballrb.position.y;                                                                                                               
        velocityX = Ballrb.linearVelocity.x;                                          
        velocityY = Ballrb.linearVelocity.y;                                                                                                                        
        // Time until the ball reaches the AI paddle.                                                                   
        timeToReach = (transform.position.x - ballX - paddleOffset) / velocityX;                                                              
    }

    void FixedUpdate()
    {
        //This Condition is used to move the AI Paddle only when the Ball is moving
        if (Ballrb.linearVelocity.x > 0)
        {
            target = tr.position.y;
            if (target > transform.position.y)
            {
                rb.linearVelocity = new Vector2(0, speed);
            }
            else if (target < transform.position.y)
            {
                rb.linearVelocity = new Vector2(0, -speed);
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
        else 
        {
                rb.linearVelocity = Vector2.zero;            
        }
    }
    //    float PredictBallY(float timeToReach)
    //    {
    //        float lowerWall = -4.75f;
    //        float upperWall = 4.75f;

    //        float height = upperWall - lowerWall;

    //        // Step 1: Predict position without walls
    //        float rawY = tr.position.y
    //                     + Ballrb.linearVelocity.y * timeToReach;

    //        // Step 2: Map position into the repeating reflection pattern
    //        float r = ((rawY - lowerWall) % (2f * height)
    //                   + (2f * height)) % (2f * height);

    //        // Step 3: Calculate the final reflected position
    //        if (r <= height)
    //        {
    //            return lowerWall + r;
    //        }
    //        else
    //        {
    //            return upperWall - (r - height);
    //        }
    //    }
}
