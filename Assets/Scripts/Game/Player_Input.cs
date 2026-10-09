using UnityEngine;
using UnityEngine.UIElements;

public class Player_Input : MonoBehaviour
{
    public Rigidbody2D rb; //For Player_Paddle
    private float speed = 5f;
    float _v;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Input from the keyboard
        _v = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        //Giving Velocity to the Ball
        rb.linearVelocity = new Vector2(0, _v * speed);
    }
}
