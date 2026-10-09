using UnityEngine;

public class Touch_Player_Input : MonoBehaviour
{
    public enum TouchSide
    {
        Left, Right
    }
    public TouchSide touchSide;
    public Rigidbody2D rb; //For Player_Paddle
    float minY = -3.75f; //Giving Minimum Y-axis Value
    float maxY = 3.75f; //Giving Maximum Y-axis Value
    float targetY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0) { }   //Giving Finger touch count to be more than one
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            //Left Side Touch
            if (touchSide == TouchSide.Left && touch.position.x < Screen.width / 2)
            {
                MovePaddle(touch);
            }

            //Right Side Touch
            if (touchSide == TouchSide.Right && touch.position.x >= Screen.width / 2)
            {
                MovePaddle(touch);
            }
        }
    }
    void MovePaddle(Touch touch)
    { 
        //Coverting the Screen Position to World Position
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));

        //Setting Minimum and Maximum Value to Y-Position
        targetY = Mathf.Clamp(touchPosition.y, minY, maxY);

        //Moving the Paddle w.r.t Touch movement
        rb.position = new Vector2(rb.position.x, targetY);
    }
}
