using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ball_Input : MonoBehaviour
{
    private float speed = 8f;
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
    }
    public void RestartBall() 
    {

        //Reset the Position
        transform.position = new Vector2(0, 0);

        //Reset Ball Velocity
        rb.linearVelocity = Vector3.zero;
        if (ballTrail != null)
        {
            //Clear the Ball Trail
            ballTrail.Clear();
        }

        //Start the Movement(Velocity) of the Ball Again
        Vector2 move = new Vector2(-1f, 1f);
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
        if (rb.linearVelocity.magnitude > 15f) 
        {
            rb.linearVelocity = rb.linearVelocity.normalized * 15f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        click.Play();
        Debug.Log(collision.gameObject.name); //Detects the Collision
        //Increases the Ball Velocity on Collision with the Paddle
        if (collision.gameObject.CompareTag("Paddle")) 
        {
            rb.linearVelocity *= 1.1f;
        }
    }
}
