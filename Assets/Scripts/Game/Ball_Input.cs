using Unity.Mathematics.Geometry;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ball_Input : MonoBehaviour
{
    private float speed = 8f;
    private float maxSpeed = 15f;
    public GameObject cts; //Calls the Click_To_Start Button
    public GameObject restart; //Calls the Restart Button
    public GameObject bg; //Calls the BG
    public GameObject pause; //Calls the Pause Button
    public GameObject Win; //For Winner Annoucemnet
    public TrailRenderer ballTrail; //Calls the Ball Trail

    public AudioSource click;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
        //Set the Position
        transform.position = new Vector2(0, 0);

        //Make Restart UI disable
        cts.SetActive(true);

        //BG becomes deactive
        bg.SetActive(true);

        click.mute = Audio_Manager.instance.isMuted;

        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);

        if (difficulty == 0)
        {
            speed = 6f;
            maxSpeed = 15f;
        }
        else if (difficulty == 1)
        {
            speed = 8f;
            maxSpeed = 20f;
        }
        else
        {
            speed = 10f;
            maxSpeed = 25f;
        }
        Debug.Log("Difficulty: " + difficulty);
        Debug.Log("Ball Starting Speed: " + speed);
        Debug.Log("Ball Maximum Speed: " + maxSpeed);
    }
    public void RestartBall() 
    {
        Debug.Log("RestartBall() was called!");

        //Reset the Position
        transform.position = new Vector2(0, 0);

        //Reset Ball Velocity
        rb.linearVelocity = Vector2.zero;
        if (ballTrail != null)
        {
            //Clear the Ball Trail
            ballTrail.Clear();
        }

        // Random horizontal direction: left or right
        float randomX = Random.value < 0.5f ? -1f : 1f;

        // Random vertical direction: up or down
        float randomY = Random.value < 0.5f ? -1f : 1f;

        //Start the Movement(Velocity) of the Ball Again
        Vector2 move = new Vector2(randomX, randomY);       
        rb.linearVelocity = move.normalized * speed;

        //Hiding the Continue Button again after Reset
        cts.SetActive(false);

        //Hiding the Restart Button again after Reset
        restart.SetActive(false);

        //Hiding the Pause Button
        pause.SetActive(true);

        //BG becomes deactive
        bg.SetActive(false);
    }
    void FixedUpdate()
    {
        //Sets the Maximum value of Speed, so that the ball does not ByPass the Wall
        if (rb.linearVelocity.magnitude > maxSpeed) 
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        click.Play();
        Debug.Log(collision.gameObject.name); //Detects the Collision
        //Increases the Ball Velocity on Collision with the Paddle
        if (collision.gameObject.CompareTag("Paddle")) 
        {
            //rb.linearVelocity *= 2f;

            Vector2 direction = rb.linearVelocity.normalized;

            //Sets a Threshold Y-direction of Ball
            if (Mathf.Abs(direction.y) < 0.25f) 
            {
                direction.y = 0.25f * Mathf.Sign(direction.y == 0 ? 1 : direction.y);
                direction.Normalize();
            }

            float newSpeed = Mathf.Min(rb.linearVelocity.magnitude * 1.1f , maxSpeed);

            rb.linearVelocity = direction * newSpeed;
        }
    }
}
