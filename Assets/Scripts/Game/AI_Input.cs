using UnityEngine;

public class AI_Input : MonoBehaviour
{
    public Transform tr; //For Getting the Position of Ball
    private float speed = 5f;
    private Rigidbody2D rb; //For AI Paddle
    float target; //For AI Paddle
    public Rigidbody2D Ballrb; //For Ball
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position.y;
    }

    void FixedUpdate()
    {
        //This Condition is used to move the AI Paddle only when the Ball is moving
        if (Ballrb.linearVelocity.x > 0)
        {
            target = tr.position.y;
            //timer = timer + Time.fixedDeltaTime;
            //if (timer >= reactionDelay)
            //{
            //    target = tr.position.y;
            //    timer = 0f;
            //}
            //These Condition are used to make AI paddle Follow the Ball
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
}
